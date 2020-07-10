#ifndef UTILITY

#define UTILITY

#include "UnityCG.cginc"

    float J2000Offset;

    float4 GetJ2000Offset(float4 pos, float4 velocity){
        return pos + velocity * J2000Offset;
    }



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

  float GetScreenScale(float4 vertex, float fraction){
      float pixelScale = GetPixelScale(vertex);
      float avgWidth = (_ScreenParams.x + _ScreenParams.y) / 2.0;
      return pixelScale * fraction * avgWidth;
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