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
static const float BlurWeights[9] = { 0.0, 0.092, 0.081, 0.071, 0.061, 0.051, 0.041, 0.031, 0.021 };
static const float3 LuminanceWeights = float3(0.299, 0.587, 0.114);

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

float2 CreateCurve(float2 uv) {
	uv -= 0.5;
	float ratio = (uv.x * uv.x + uv.y * uv.y) * 1.5; // the higher the number multiplied, the more curve
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
	float distance = length(max(abs(centerPos) - (size / 2.0) + radius, 0)) - radius;

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
	float strength = 0.2;
	float offset = 0.008;

	float3 bloomTop = color + tex2D(SpriteTextureSampler, uv + float2(0, -offset)).rgb;
	float3 bloomTopLeft = color + tex2D(SpriteTextureSampler, uv + float2(offset, -offset)).rgb;
	float3 bloomLeft = color + tex2D(SpriteTextureSampler, uv + float2(offset, 0)).rgb;
	float3 bloomBottomLeft = color + tex2D(SpriteTextureSampler, uv + float2(offset, offset)).rgb;
	float3 bloomBottom = color + tex2D(SpriteTextureSampler, uv + float2(0, offset)).rgb;
	float3 bloomBottomRight = color + tex2D(SpriteTextureSampler, uv + float2(-offset, offset)).rgb;
	float3 bloomRight = color + tex2D(SpriteTextureSampler, uv + float2(-offset, 0)).rgb;
	float3 bloomTopRight = color + tex2D(SpriteTextureSampler, uv + float2(-offset, -offset)).rgb;

	float3 bloomMask = ((
		bloomTop + bloomTopLeft + bloomLeft + bloomBottomLeft + bloomBottom + bloomBottomRight + bloomRight + bloomTopRight
	) / 8) * strength;
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

float4 AddShadowMask(float4 colRgba, float2 uv)
{
	float3 agColor = float3(0, 0, 0);

	int row = int(uv.x * RESOLUTION_X) % 2;
	int col = int(uv.y * RESOLUTION_Y) % 3;

	if (row == 1 || col == 1)
	{
		colRgba = colRgba * 0.01;
	}
	else
	{
		colRgba.r = 0;
	}
	return colRgba;
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
	
    float2 transformedUV = CreateCurve(input.TextureCoordinates);
	transformedUV = RoundCorners(transformedUV);

    float4 col = tex2D(SpriteTextureSampler, transformedUV) * input.Color;
	col.rgb = AddChromaticAberration(col.rgb, transformedUV);
	col.rgb = SetSaturation(col.rgb, 0.8);
	
	col.rgb = AddBloom(col.rgb, transformedUV);
	col.rgba = AddShadowMask(col.rgba, transformedUV);
	col.rgb = AddBlur(col.rgb, transformedUV);
    return col;
}

technique BasicColorDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL MainPS();
	}
};