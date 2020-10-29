#ifndef AHOY_COMPUTE_UTILITY
#define AHOY_COMPUTE_UTILITY
#include "UnityCG.cginc"

#include "../../Ahoy.Shaders/Shaders/utility.cginc"

float4x4 Ahoy_M, Ahoy_V, Ahoy_P, Ahoy_MV, Ahoy_VP, Ahoy_MVP;
int Ahoy_NumThreads, Ahoy_NumThreadsX, Ahoy_NumThreadsY, Ahoy_NumThreadsZ;
float Ahoy_Time,Ahoy_DeltaTime;


int GetThreadIndex(uint3 id){
	int i = id.x + id.y * Ahoy_NumThreadsX + id.z * Ahoy_NumThreadsX * Ahoy_NumThreadsY;
	if(i >= Ahoy_NumThreads)
		return -1;
	return i;
}

#endif
