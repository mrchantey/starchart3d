#ifndef AHOY_COMPUTE_UTILITY
#define AHOY_COMPUTE_UTILITY
#include "UnityCG.cginc"

// #include "../../Ahoy.Shaders/Shaders/utility.cginc"

float4x4 Ahoy_M, Ahoy_V, Ahoy_P, Ahoy_MV, Ahoy_VP, Ahoy_MVP;
int Ahoy_NumThreads, Ahoy_NumThreadsX, Ahoy_NumThreadsY, Ahoy_NumThreadsZ;
float Ahoy_Time,Ahoy_DeltaTime;
float4 Ahoy_ScreenParams;
float _Size;
bool _ScreenSpace;

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
	float size = _Size == 0 ? 1 : _Size;
	if(_ScreenSpace)
		return GetScreenScale(pos_V) * size * 0.1;
	return size;
}

// void PointsToQuad(float3 pos_M, out float4 vertices[4]){
void PointsToQuad(float3 pos_M, int vi){
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
void PointsToLine(float3 pos0_M, float3 pos1_M, int vi){
	float4 pos0_V = mul(Ahoy_MV,float4(pos0_M,1));
	float4 pos1_V = mul(Ahoy_MV,float4(pos1_M,1));


	float scale0 = GetScale(pos0_V);
	float scale1 = GetScale(pos1_V);


	float3 dirFwd = (pos0_V + pos1_V)/2;
	float3 dirRight = pos1_V.xyz - pos0_V.xyz;
	float3 dirUp = normalize(cross(dirFwd,dirRight));

	if(!_ScreenSpace)
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
