#ifndef star_utility

#define star_utility

#include "UnityCG.cginc"

    float J2000Offset;

	float _ScaleRange;
	float _ScaleOffset;
	float4 GetNextPos(float4 pos, float4 velocity){

		float3 scaled = pos.xyz / 1000;		//max length is 1000
		float3 normalized = normalize(pos.xyz);
        float3 val = lerp(scaled,normalized,_ScaleRange) * _ScaleOffset;
        return float4(val,1) + velocity * J2000Offset;
	}	

#endif