#ifndef STARCHART3D_STAR_UTILITYRENDER
#define STARCHART3D_STAR_UTILITYRENDER

#include "./starInfo.cginc"


float 
_Glow,
_TwinkleFrequency,
_TwinkleAmplitude,
___;

StructuredBuffer<StarInfo> stars;
StructuredBuffer<float4> vertices;


float Hash31(float3 p){
	p = frac(p * float3(123.45,678.93,987.75));
	p += dot(p,p+12.34);
	return frac(p.x * p.y * p.z);
}

float GetTwinkle(float3 pos){
	float id = Hash31(pos);
	float theta = _Time.w * _TwinkleFrequency * id + id * 6.2831;
	float t = sin(theta) * 0.5 + 0.5;
	return lerp(1-_TwinkleAmplitude,1,t);
}	


float GetAlpha(float2 uv){
	float2 uv2 = uv * 2 - float2(1,1);
    float dist = length(uv2);
    float falloff = clamp(dist,0,1);
	float glow = _Glow/falloff;
	return clamp(glow * (1-falloff),0,1);
}

float GetAlpha2D(float2 uv){
	float2 uv2 = uv * 2 - float2(1,1);
	float dist = length(uv2);
	float falloff = clamp(dist,0,1);
	float falloff2 = abs(uv2.y);
	float glow = _Glow/falloff2;
	return clamp(glow * (1-falloff),0,1);
}

#endif