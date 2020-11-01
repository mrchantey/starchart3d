#ifndef AHOY_COMPUTE_UTILITY
#define AHOY_COMPUTE_UTILITY
#include "UnityCG.cginc"

// #include "../../Ahoy.Shaders/Shaders/utility.cginc"

float4x4 Ahoy_M, Ahoy_V, Ahoy_P, Ahoy_MV, Ahoy_VP, Ahoy_MVP;
float4 Ahoy_ScreenParams;
int 
Ahoy_NumThreads, 
Ahoy_NumThreadsX, 
Ahoy_NumThreadsY, 
Ahoy_NumThreadsZ,
_ScreenSpace;


float 
Ahoy_Time,
Ahoy_DeltaTime,
_Size,
_ScaleDivisor,
_ScaleRange,
_ScaleMax;

StructuredBuffer<float3> positions;
StructuredBuffer<int> indices;
RWStructuredBuffer<float4> vertices;


int GetThreadIndex(uint3 id){
	int i = id.x + id.y * Ahoy_NumThreadsX + id.z * Ahoy_NumThreadsX * Ahoy_NumThreadsY;
	if(i >= Ahoy_NumThreads)
		return -1;
	return i;
}


float GetPixelScale(float4 pos_V){
	float projD = Ahoy_P[1][1];
    float frustrumHeight = 2 * -pos_V.z * (1/projD);
    float metersPerPixel = frustrumHeight / Ahoy_ScreenParams.y;
    return metersPerPixel;
}

float GetScreenScale(float4 pos_V){
	float pixelScale = GetPixelScale(pos_V);
	float avgWidth = (Ahoy_ScreenParams.x + Ahoy_ScreenParams.y) / 2.0;
	return pixelScale * avgWidth;
}

float GetScale(float4 pos_V){
	if(_ScreenSpace == 1)
		return GetScreenScale(pos_V) * _Size * 0.1;
	return _Size;
}

float3 GetModelPosition(float3 pos){
	float3 scaled = pos / _ScaleDivisor;
	float3 normalized = normalize(pos);
    return lerp(scaled,normalized,_ScaleRange) * _ScaleMax;
}


void PointsToQuad(int pi, int vi){
	float3 pos_M = GetModelPosition(positions[pi]);
	float4 pos_V = mul(Ahoy_MV,float4(pos_M,1));

	float scale = GetScale(pos_V);

	float3 posOff0 = pos_V + float3(1, 1, 0)  * scale;
	float3 posOff1 = pos_V + float3(1, -1, 0) * scale;
	float3 posOff2 = pos_V + float3(-1, -1, 0) * scale;
	float3 posOff3 = pos_V + float3(-1, 1, 0) * scale;

	vertices[vi] = mul(Ahoy_P,float4(posOff0,1));
	vertices[vi+1] = mul(Ahoy_P,float4(posOff1,1));
	vertices[vi+2] = mul(Ahoy_P,float4(posOff2,1));
	vertices[vi+3] = mul(Ahoy_P,float4(posOff3,1));
}


// void PointsToLine(float3 pos0_M, float3 pos1_M, out float4 vertices[4]){
void PointsToLine(int pi0, int pi1, int vi){
	float3 pos0_M = GetModelPosition(positions[pi0]);
	float3 pos1_M = GetModelPosition(positions[pi1]);

	float4 pos0_V = mul(Ahoy_MV,float4(pos0_M,1));
	float4 pos1_V = mul(Ahoy_MV,float4(pos1_M,1));



	float scale0 = GetScale(pos0_V);
	float scale1 = GetScale(pos1_V);


	float3 dirFwd = (pos0_V + pos1_V)/2;
	float3 dirRight = pos1_V.xyz - pos0_V.xyz;
	float3 dirUp = normalize(cross(dirFwd,dirRight));

	if(_ScreenSpace == 0)
		dirUp *= -1;

	float3 posOff0 = pos1_V + dirUp * scale1;
	float3 posOff1 = pos1_V - dirUp * scale1;
	float3 posOff2 = pos0_V - dirUp * scale0;
	float3 posOff3 = pos0_V + dirUp * scale0;

	vertices[vi] = mul(Ahoy_P,float4(posOff0,1));
	vertices[vi+1] = mul(Ahoy_P,float4(posOff1,1));
	vertices[vi+2] = mul(Ahoy_P,float4(posOff2,1));
	vertices[vi+3] = mul(Ahoy_P,float4(posOff3,1));
}

#endif
