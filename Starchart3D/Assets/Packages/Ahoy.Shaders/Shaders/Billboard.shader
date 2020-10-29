Shader "Ahoy/Billboard"
{
  Properties{
 
    _Radius ("Radius",Range(0,1)) = 0.1
    _Color ("Color",Color) = (1,1,1,1)
	[MaterialToggle] _FixedSize("Fixed Size (requires enabled post processing on camera)", Float) = 0
  }
  SubShader{
	Tags {"Queue"="Transparent" "RenderType"="Transparent"}
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
        // o.color = v.color;
        return o;
      }

      float _Radius;
	float _FixedSize;

      [maxvertexcount(4)]
      void geom(point v2g IN[1], inout TriangleStream<g2f> triStream){

		  float scale;
		  if(_FixedSize == 0){
          float screenScale = GetScreenScale(IN[0].pos,_Radius);
          scale = screenScale;
		  }else{
			  scale = _Radius;
		  }


          float4 verts[4];
          WorldPoint2ClipBillboard(IN[0].pos, scale, verts);

          g2f OUT;
          // OUT.color = IN[0].color;
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

    fixed4 _Color;

      fixed4 frag(g2f i): SV_TARGET{
		  float a = clamp(length(i.uv * 2 - 1),0,1);
		  return lerp(_Color,fixed4(1,1,1,0),a);
        //   return _Color;
          // return fixed4(i.color.rgb,a);
      }

      ENDCG

    }



  }




}