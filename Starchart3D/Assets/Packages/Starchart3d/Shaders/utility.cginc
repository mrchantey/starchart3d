#ifndef UTILITY

#define UTILITY

#include "UnityCG.cginc"

float4 Object2OffsetClipPos(float4 pos,float3 offset){
  float4 v = float4(pos + offset,1);
  return UnityObjectToClipPos(v);
}

float GetPixelScale(float4 vertex){
    float projD = UNITY_MATRIX_P[1][1];
    float dist = UnityObjectToViewPos(vertex).z;
    float frustrumHeight = 2 * -dist * (1/projD);
    float metersPerPixel = frustrumHeight / _ScreenParams.y;
    return metersPerPixel;
}

float GetFieldOfView(){
}

float GetScreenScale(float4 vertex, float fraction){
    float pixelScale = GetPixelScale(vertex);
    float avgWidth = (_ScreenParams.x + _ScreenParams.y) / 2.0;
     float fovRad = atan(1.0f / unity_CameraProjection._m11 ) * 2.0;	
	 float fovFrac = fovRad / (UNITY_PI * 2);
    return pixelScale * fraction * avgWidth * (1-fovFrac);
    // return pixelScale * fraction * _ScreenParams.y;
}

void WorldPoint2ClipBillboard(float4 pos, float scale, out float4 verts[4]){

    float3 right = normalize(UNITY_MATRIX_IT_MV[0].xyz) * scale;
    float3 up = normalize(UNITY_MATRIX_IT_MV[1].xyz) * scale;

    verts[0] = Object2OffsetClipPos(pos,-right+ up);
    verts[1] = Object2OffsetClipPos(pos, right+ up);
    verts[2] = Object2OffsetClipPos(pos,-right - up);
    verts[3] = Object2OffsetClipPos(pos, right- up);
}


void PointsToLineQuad(float4 pos0, float4 pos1, bool fixedSize, float scale, out float4 verts[4]){
	float3 fwd0 = ObjSpaceViewDir(pos0);
	float3 fwd1 = ObjSpaceViewDir(pos1);
	float3 dirFwd = (fwd0 + fwd1) / 2;

	float3 dirRight = (pos1 - pos0);
	float3 dirUp = normalize(cross(dirFwd,dirRight));

	float3 offUp0;
	float3 offUp1;
	if(fixedSize){
		offUp0 = -dirUp * scale;
		offUp1 = -dirUp * scale;
	}else{
		float screenScale0 = GetScreenScale(pos0,scale);
		float screenScale1 = GetScreenScale(pos1,scale);
		offUp0 = dirUp * screenScale0;
		offUp1 = dirUp * screenScale1;
	}
	verts[0] = Object2OffsetClipPos(pos1,-offUp1);
	verts[1] = Object2OffsetClipPos(pos0,-offUp0);
	verts[2] = Object2OffsetClipPos(pos1,offUp1);
	verts[3] = Object2OffsetClipPos(pos0,offUp0);
}


#endif