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

#define BLUR_OFFSET 0.005
#define BLUR_MULTIPLIER 1.05
#define BLUR_STRENGTH 0.5

float TimePassage;

static const float3 LuminanceWeights = float3(0.299, 0.587, 0.114);
static const float BlurWeights[9] = { 0.0, 0.092, 0.081, 0.071, 0.061, 0.051, 0.041, 0.031, 0.021 };

matrix WorldViewProjection;
Texture2D SpriteTexture;
SamplerState Sampler;

sampler2D SpriteTextureSampler = sampler_state 
{
	Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
	float4 Position : SV_POSITION;
	float4 Color : COLOR0;
	float2 TextureCoordinates : TEXCOORD0;
};

float Rand1(float2 n)
{ 
    return frac(sin(dot(n, float2(12.9898, 4.1414) + TimePassage)) * 43758.545);
}

float Rand2(float2 n)
{
    float2 K1 = float2(
		23.14069263277926, // e^pi
		2.665144142690225 // 2^sqrt(2)
    );
    return frac(cos(dot(n, K1 + TimePassage)) * 12345.6789);
}

float2 CreateCurve(float2 uv) {
	uv -= 0.5;
	float ratio = (uv.x * uv.x + uv.y * uv.y) * 1; // the higher the number multiplied, the more curve
	uv *= 4.2 + ratio;
	uv *= 0.23;
	uv += 0.5;

	return uv;
}

float2 AddOverscan(float2 uv)
{
	if (any(uv < 0.0) || any(uv > 1.0))
	{
		uv = float2(0, 0);  // set to black if out of bounds
	}
	
	return uv;
}

float2 RoundCorners(float2 uv) : COLOR0
{
	float radius = 0.05;
	float2 size = float2(1, 1);

    // Calculate distance to edge
	float2 centerPos = uv - (size / 2.0);
	float distance = length(max(abs(centerPos) - (size / 2) + radius, 0)) - radius;

	if (distance > 0) 
	{
		return float2(0, 0); // set to black if out of the rounded corner rect
	}
	else
	{
		return uv;
	}
}

float3 AddBloom(float3 color, float2 uv)
{
	float strength = 0.1;
	float offset = 0.005;

	float3 bloomRight = color + tex2D(SpriteTextureSampler, uv + float2(-offset, 0)).rgb;
	float3 bloomLeft = color + tex2D(SpriteTextureSampler, uv + float2(offset, 0)).rgb;
	float3 bloomTop = color + tex2D(SpriteTextureSampler, uv + float2(0, -offset)).rgb;
	float3 bloomBottom = color + tex2D(SpriteTextureSampler, uv + float2(0, offset)).rgb;

	float3 bloomMask = ((bloomRight + bloomLeft + bloomTop + bloomBottom) / 4.0) * strength;
	return saturate(color + bloomMask);
}

float3 AddChromaticAberration(float3 color, float2 uv)
{
	float offset = 0.002;

	// sample textures for each color channel with offset UVs
    float3 rightSample = tex2D(SpriteTextureSampler, uv + float2(offset, 0)).rgb;
    float3 center = tex2D(SpriteTextureSampler, uv).rgb;
    float3 leftSample = tex2D(SpriteTextureSampler, uv - float2(offset, 0)).rgb;

    float3 finalColor = float3(rightSample.r, center.g, leftSample.b);
    return finalColor;
}

float3 SetSaturation(float3 color, float value)
{
	float luminance = dot(color, LuminanceWeights);
	float3 saturatedColor = lerp(luminance, color, value);
	return saturatedColor;
}

float3 BlurH(float3 c, float2 uv)
{
	float3 screen = tex2D(SpriteTextureSampler, uv).rgb * 0.102;
	for (int i = 1; i < 9; i++)
	{
		screen += tex2D(SpriteTextureSampler, uv + float2(i * BLUR_OFFSET, 0)).rgb * BlurWeights[i];
	}
	for (int j = 1; j < 9; j++) 
	{
		screen += tex2D(SpriteTextureSampler, uv + float2(-j * BLUR_OFFSET, 0)).rgb * BlurWeights[j];
	}
	return screen * BLUR_MULTIPLIER;
}

float3 BlurV(float3 c, float2 uv)
{
	float3 screen = tex2D(SpriteTextureSampler, uv).rgb * 0.102;
	for (int i = 1; i < 9; i++) 
	{
		screen += tex2D(SpriteTextureSampler, uv + float2(0,  i * BLUR_OFFSET)).rgb * BlurWeights[i];
	}
	for (int j = 1; j < 9; j++)
	{
		screen += tex2D(SpriteTextureSampler, uv + float2(0, -j * BLUR_OFFSET)).rgb * BlurWeights[j];
	}
	return screen * BLUR_MULTIPLIER;
}

float3 AddBlur(float3 color, float2 uv)
{
	float3 blur = (BlurH(color, uv) + BlurV(color, uv)) / 2 - color;
	float3 blurMask = blur * BLUR_STRENGTH;
	//return blur_mask;
	return saturate(color + blurMask);
}

float4 AddApertureGrille(float4 colRgba, float2 uv)
{
	float3 agColor = float3(0, 0, 0);

	int row = int(uv.y * RESOLUTION_Y) % 4;
	int col = int(uv.x * RESOLUTION_X) % 2;

	if (row == 0 || row == 2)
	{
		colRgba = saturate(colRgba - 0.2);
	}
	else if (row == 1)
	{
		colRgba = float4(0, 0, 0, 1);
	}

	if (col == 0)
	{
		colRgba = float4(colRgba.r, 0, colRgba.b, colRgba.a);
	}

	return colRgba;
}

float GetNoiseFactor(float2 uv, float noiseScale)
{
	float2 p = uv * noiseScale;
    float2 ip = floor(p);
    float2 u = frac(p);
    u = u * u * (3.0 - 2.0 * u);

    float res = lerp(
        lerp(Rand1(ip), Rand1(ip + float2(1.0, 0.0)), u.x),
        lerp(Rand2(ip+float2(0.0,1.0)), Rand2(ip + float2(1.0,1.0)), u.x), u.y);
    return res * res;
}


float3 ApplyNoise(float3 col, float2 uv)
{
	float noiseFactor = GetNoiseFactor(uv, 500);
	col += noiseFactor * col;
	return col;
}


float4 MainPS(VertexShaderOutput input) : COLOR
{
	
    float2 transformedUV = CreateCurve(input.TextureCoordinates);
	transformedUV = RoundCorners(transformedUV);

    float4 col = tex2D(SpriteTextureSampler, transformedUV) * input.Color;
	col.rgb = AddChromaticAberration(col.rgb, transformedUV);
	col.rgba = AddApertureGrille(col.rgba, transformedUV);
	col.rgb = AddBloom(col.rgb, transformedUV);
	col.rgb = AddBlur(col.rgb, transformedUV);
	col.rgb = SetSaturation(col.rgb, 0.8);
	col.rgb = ApplyNoise(col.rgb, transformedUV);
    return col;
}

technique BasicColorDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};