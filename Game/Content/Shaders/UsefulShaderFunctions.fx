
/* --- Color Fomat Conversion --- */
float Epsilon = 1e-10;

float3 RGBtoHCV(in float3 RGB)
{
	// Based on work by Sam Hocevar and Emil Persson
	float4 P = (RGB.g < RGB.b) ? float4(RGB.bg, -1.0, 2.0/3.0) : float4(RGB.gb, 0.0, -1.0/3.0);
	float4 Q = (RGB.r < P.x) ? float4(P.xyw, RGB.r) : float4(RGB.r, P.yzx);
	float C = Q.x - min(Q.w, Q.y);
	float H = abs((Q.w - Q.y) / (6 * C + Epsilon) + Q.z);
	return float3(H, C, Q.x);
}

float3 HUEtoRGB(in float H)
{
	float R = abs(H * 6 - 3) - 1;
	float G = 2 - abs(H * 6 - 2);
	float B = 2 - abs(H * 6 - 4);
	return saturate(float3(R,G,B));
}

float3 RGBtoHSV(in float3 RGB)
{
	float3 HCV = RGBtoHCV(RGB);
	float S = HCV.y / (HCV.z + Epsilon);
	return float3(HCV.x, S, HCV.z);
}

float3 HSVtoRGB(in float3 HSV)
{
	float3 RGB = HUEtoRGB(HSV.x);
	return ((RGB - 1) * HSV.y + 1) * HSV.z;
}



float4 ApplyRedChannelBlur(float4 col, float2 uv)
{

	const float convolution[5][5] = 
	{
		{0.0030, 0.0133, 0.0219, 0.0133, 0.0030},
		{0.0133, 0.0596, 0.0983, 0.0596, 0.0133},
		{0.0219, 0.0983, 0.1621, 0.0983, 0.0219},
		{0.0133, 0.0596, 0.0983, 0.0596, 0.0133},
		{0.0030, 0.0133, 0.0219, 0.0133, 0.0030}
	};

	const int n = 5;
	const int2 center = int2(2, 2);
	col.r *= convolution[center.x][center.y];

	for (int row = 0; row < n; row++)
	{
		for (int colm = 0; colm < n; colm++)
		{
			if (row == center.y && colm == center.x) continue;
			float guassKernel = convolution[row][colm];
			float2 pos = float2(row, colm);

			//col.r += tex2D(SpriteTextureSampler, uv + float2(pos.y / RESOLUTION_X, pos.x / RESOLUTION_Y)).r * guassKernel * 2;
		}
	}


	/*
	const float offsets[] = { 0.0, 1.0, 2.0, 3.0, 4.0 };
	const float weights[] = {
		0.2270270270, 0.1945945946, 0.1216216216,
		0.0540540541, 0.0162162162
	};
	const float2 onesVector = float2(1, 1);

	col.r *= weights[0];

	for (int i = 1; i < 5; i++)
	{
        col.r += tex2D(SpriteTextureSampler, uv + float2(0.0, offsets[i] / RESOLUTION_Y)).r * weights[i] / 2.0;
        col.r += tex2D(SpriteTextureSampler, uv - float2(0.0, offsets[i] / RESOLUTION_Y)).r * weights[i] / 2.0;

		col.r += tex2D(SpriteTextureSampler, uv + float2(offsets[i] / RESOLUTION_Y, 0.0)).r * weights[i] / 2.0;
        col.r += tex2D(SpriteTextureSampler, uv - float2(offsets[i] / RESOLUTION_Y, 0.0)).r * weights[i] / 2.0;
		
	}*/

	return col;
}

