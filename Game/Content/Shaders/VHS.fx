#if OPENGL
	#define SV_POSITION POSITION
	#define VS_SHADERMODEL vs_3_0
	#define PS_SHADERMODEL ps_3_0
#else
	#define VS_SHADERMODEL vs_4_0_level_9_1
	#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

#define RESOLUTION_X 768
#define RESOLUTION_Y 696

matrix WorldViewProjection;

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float TimePassage;

sampler2D SpriteTextureSampler = sampler_state 
{
	Texture = <SpriteTexture>;
};

static const float3 LuminanceWeights = float3(0.299, 0.587, 0.114);

float4 GaussianBlur(float2 uv, float size)
{
	float Pi = 6.28318530718; // Pi*2
    
    float directions = 16.0; // BLUR DIRECTIONS (Default 16.0 - More is better but slower)
    float quality = 3.0; // BLUR QUALITY (Default 4.0 - More is better but slower)
   
    float2 radius = size / RESOLUTION_X;
    
    // pixel colour
    float4 color = tex2D(SpriteTextureSampler, uv);
    
    // Blur calculations
    for (float d = 0.0; d < Pi; d += Pi / directions)
    {
		for (float i = 1.0 / quality; i <= 1.0; i += 1.0 / quality)
        {
			color += tex2D(SpriteTextureSampler, uv + float2(cos(d),sin(d)) * radius * i);		
        }
    }
    
    color /= quality * directions - 15.0;
	return color;
}


//-----------------------------
// Noise function
float Rand1(float2 n)
{ 
    return frac(sin(dot(n, float2(12.9898, 4.1414) + TimePassage)) * 43758.545);
}

float Rand2(float2 n)
{
    float2 K1 = float2(
		23.14069263277926, // e^pi (Gelfond's constant)
		2.665144142690225 // 2^sqrt(2) (Gelfondâ€“Schneider constant)
    );
    return frac(cos(dot(n, K1 + TimePassage)) * 12345.6789);
}

float Rand3(float2 n)
{
	return (Rand1(n) + Rand2(n)) / 2.0;
}

float GetNoiseFactor1(float2 uv, float noiseScale)
{
	float2 p = uv * noiseScale;
    float2 ip = floor(p);
    float2 u = frac(p);
    u = u * u * (3.0 - 2.0 * u);

    float res = lerp(
        lerp(Rand1(ip), Rand1(ip + float2(1.0, 0.0)), u.x),
        lerp(Rand1(ip+float2(0.0,1.0)), Rand1(ip + float2(1.0,1.0)), u.x), u.y);
    return res * res;
}

float GetNoiseFactor2(float2 uv, float noiseScale)
{
	float2 p = uv * noiseScale;
    float2 ip = floor(p);
    float2 u = frac(p);
    u = u * u * (3.0 - 2.0 * u);

    float res = lerp(
        lerp(Rand2(ip), Rand2(ip + float2(1.0, 0.0)), u.x),
        lerp(Rand3(ip+float2(0.0,1.0)), Rand2(ip + float2(1.0,1.0)), u.x), u.y);
    return res * res;
}

float GetNoiseFactor3(float2 uv, float noiseScale)
{
	float2 p = uv * noiseScale;
    float2 ip = floor(p);
    float2 u = frac(p);
    u = u * u * (3.0 - 2.0 * u);

    float res = lerp(
        lerp(Rand1(ip), Rand2(ip + float2(1.0, 0.0)), u.x),
        lerp(Rand3(ip + float2(0.0,1.0)), Rand3(ip + float2(1.0,1.0)), u.x), u.y);
    return res * res;
}

float3 AddColorNoise(float3 col, float2 uv, float intensity, float gainSize)
{
	float rNoiseFactor = GetNoiseFactor1(uv, gainSize) * intensity;
	float gNoiseFactor = GetNoiseFactor2(uv, gainSize) * intensity;
	float bNoiseFactor = GetNoiseFactor3(uv, gainSize) * intensity;

	// instead of rgb color noise, let's do cmy
	float rand = Rand2(uv);
	if (rand < 0.25)
	{
		col.r = 0;
		col.g += gNoiseFactor;
		col.b += bNoiseFactor;
	}
	else if (rand < 0.50)
	{
		col.r += rNoiseFactor;
		col.g = 0;
		col.b += bNoiseFactor;
	}
	else if (rand < 0.75)
	{
		col.r += rNoiseFactor;
		col.g += gNoiseFactor;
		col.b = 0;
	}
	else
	{
		col.r += rNoiseFactor;
		col.g += gNoiseFactor;
		col.b += bNoiseFactor;
	}
	return col;
}

float3 BlendChannels(float2 uv, float redBlurRadius, float greenBlurRadius, float blueBlurRadius)
{
	float4 redBlur = GaussianBlur(uv, redBlurRadius);
	float4 greenBlur = GaussianBlur(uv, greenBlurRadius);
	float4 blueBlur = GaussianBlur(uv, blueBlurRadius);

    float3 blurredColor;
    blurredColor.r = redBlur.r;
    blurredColor.g = greenBlur.g;
    blurredColor.b = blueBlur.b;

    return blurredColor;
}

float3 SetSaturation(float3 color, float value)
{
	float luminance = dot(color, LuminanceWeights);
	float3 saturatedColor = lerp(luminance, color, value);
	return saturatedColor;
}

float4 ShiftChannels(float2 uv)
{
	float redOffset = 0.002;
	float greenOffset = 0.003;
	float blueOffset = 0.001;

	// sample textures for each color channel with offset UVs
	float4 origin = tex2D(SpriteTextureSampler, uv);
    float4 redSample = tex2D(SpriteTextureSampler, uv - float2(redOffset, 0));
    float4 greenSample = tex2D(SpriteTextureSampler, uv - float2(greenOffset, 0));
    float4 blueSample = tex2D(SpriteTextureSampler, uv - float2(0, blueOffset));

    float4 finalColor = float4(redSample.r, greenSample.g, blueSample.b, origin.a);
    return finalColor;
}

float4 ChannelShiftsPS(VertexShaderOutput input) : COLOR
{
	float offset = 0.02;
	float2 uv = input.TextureCoordinates;
	float4 color = tex2D(SpriteTextureSampler, uv);
	float4 blueSample = tex2D(SpriteTextureSampler, uv - float2(offset, 0));

	color.b += blueSample.b * 0.4;
	color.r += blueSample.b * 0.4;
	return color;
}

float3 ApplyDustStreak(float3 col, float2 uv)
{
	float randY = Rand2(float2(uv.y, uv.y));
	float randX = Rand1(float2(uv.x, uv.y));

	if (distance(randY, uv.y) < 0.01 && distance(randX, uv.x) < 0.1)
	{
		return float3(0.75, 0.75, 0.75);
	}
	return col;
}

float4 ChannelBlendPS(VertexShaderOutput input) : COLOR
{
	float4 original = tex2D(SpriteTextureSampler, input.TextureCoordinates);
	/*
	float4 blurred = GaussianBlur(input.TextureCoordinates, 3);
	original.r = blurred.r;*/
	original.rgb = BlendChannels(input.TextureCoordinates, 4, 2, 12);
	return original;
}

float4 FinalPS(VertexShaderOutput input) : COLOR
{
	float4 col = tex2D(SpriteTextureSampler, input.TextureCoordinates);

	col.rgb = SetSaturation(col.rgb, 0.3).rgb;

    col.r = floor(col.r * 7.99) * (1.0 / 8.0);
    col.g = floor(col.g * 7.99) * (1.0 / 8.0);
    col.b = floor(col.b * 3.99) * (1.0 / 3.0);
	col.a = floor(col.a * 8) / 8;

	col.rgb = AddColorNoise(col.rgb, input.TextureCoordinates, 0.35, 853);
	col.rgb = ApplyDustStreak(col.rgb, input.TextureCoordinates);
	return col;
}

technique VHS_Step1
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL ChannelShiftsPS();
	}
};

technique VHS_Step2
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL ChannelBlendPS();
	}
};

technique VHS_Step3
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL FinalPS();
	}
};
