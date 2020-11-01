#ifndef STARCHART3D_STAR_UTILITY
#define STARCHART3D_STAR_UTILITY

#include "../../Ahoy.Compute/Shaders/utility.cginc"
#include "./starInfo.cginc"


float _J2000Offset;

float 
_MagDelta, 
_MagMax,
_ScaleRange,
_ScaleMax,
___;

StructuredBuffer<StarInfo> stars;

float3 GetStarPosition(int si){
	float3 scaled = stars[si].position / 1000;		//max length is 1000
	float3 normalized = normalize(stars[si].position);
    float3 val = lerp(scaled,normalized,_ScaleRange) * _ScaleMax;
    return val + stars[si].velocity * _J2000Offset;
}

float GetMagnitude(int si){
	float magRaw = _ScreenSpace ? stars[si].apparentMagnitude : stars[si].absoluteMagnitude;
	float magLog = clamp(magRaw,0, 10);
	float magLinear = pow(_MagDelta, -magLog);
	float magClamped = clamp(magLinear,0, _MagMax);
	return magClamped;
}

void PointsToStar(int si, int vi){

	float3 pos_M = GetStarPosition(si);

	float4 pos_V = mul(Ahoy_MV,float4(pos_M,1));

	float magnitude = GetMagnitude(si);
	float scale = GetScale(pos_V) * magnitude;


	float3 posOff0 = pos_V + float3(1, 1, 0)  * scale;
	float3 posOff1 = pos_V + float3(1, -1, 0) * scale;
	float3 posOff2 = pos_V + float3(-1, -1, 0) * scale;
	float3 posOff3 = pos_V + float3(-1, 1, 0) * scale;

	vertices[vi] = mul(Ahoy_P,float4(posOff0,1));
	vertices[vi+1] = mul(Ahoy_P,float4(posOff1,1));
	vertices[vi+2] = mul(Ahoy_P,float4(posOff2,1));
	vertices[vi+3] = mul(Ahoy_P,float4(posOff3,1));
}


#endif