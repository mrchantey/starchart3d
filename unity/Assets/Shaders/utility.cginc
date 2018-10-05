#ifndef UTILITY

#define UTILITY

#include "UnityCG.cginc"



  float4 Object2OffsetClipPos(float4 pos,float3 offset){
    float4 v = float4(pos + offset,1);
    return UnityObjectToClipPos(v);
  }


  void WorldPoint2ClipBillboard(float4 pos, float scale, out float4 verts[4]){

      float3 right = normalize(UNITY_MATRIX_IT_MV[0].xyz) * scale;
      float3 up = normalize(UNITY_MATRIX_IT_MV[1].xyz) * scale;

      verts[0] = Object2OffsetClipPos(pos,-right+ up);
      verts[1] = Object2OffsetClipPos(pos, right+ up);
      verts[2] = Object2OffsetClipPos(pos,-right - up);
      verts[3] = Object2OffsetClipPos(pos, right- up);
  }








#endif