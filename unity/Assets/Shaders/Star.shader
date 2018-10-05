Shader "StarChart/Star"
{
  Properties{

      _Radius ("Star Radius",Range(0,10)) =2
  }
  SubShader{
    Tags{"Queue"="Transparent"} 
    ZWrite Off

    Blend SrcAlpha OneMinusSrcAlpha

    Pass
    {
      CGPROGRAM

      #pragma vertex vert
      #pragma geometry geom
      #pragma fragment frag

      #include "UnityCG.cginc"
      #include "Utility.cginc"

      struct appdata{
        float4 pos: POSITION;
      };

      struct v2g{
        float4 pos: SV_POSITION;
      };

      struct g2f{
        float4 pos: SV_POSITION;
        float2 uv: TEXCOORD0;
      };

      v2g vert (appdata v){ 
        v2g o;
        o.pos = v.pos;
        return o;
      }

      float _Radius;

      [maxvertexcount(4)]
      void geom(point v2g IN[1], inout TriangleStream<g2f> triStream){


          float4 verts[4];
          WorldPoint2ClipBillboard(IN[0].pos, _Radius, verts);


          g2f OUT;
          OUT.pos = verts[0];
          OUT.uv = float2(0,1);
          triStream.Append(OUT);

          OUT.pos = verts[1];
          OUT.uv = float2(1,1);
          triStream.Append(OUT);
          
          OUT.pos = verts[2];
          OUT.uv = float2(0,0);
          triStream.Append(OUT);
          
          OUT.pos = verts[3];
          OUT.uv = float2(1,0);
          triStream.Append(OUT);
      }


      fixed4 frag(g2f i): SV_TARGET{
          float dist = length(i.uv - float2(0.5,0.5)) * 2;
          float clampedDist = clamp(dist,0,1);
          float a = 1-clampedDist;
          return fixed4(0,1,1,a);
      }

      ENDCG

    }



  }




}