Shader "zz_deprecated/Star"
{
  Properties{
 
    _ScaleOffset ("Scale Offset",Range(0,1000)) = 0
    _ScaleRange ("Scale Range",Range(0,1)) = 1
    _Radius ("Star Radius",Range(0,1)) = 0.015
    _MagDelta ("Delta Magnitude",Range(1,3)) = 2.5 
    _MagMax ("Maximum Magnitude",Range(0,0.2)) = 0.03

  }
  SubShader{
    Tags{"Queue"="Transparent+1"} 
    ZWrite Off

    Blend SrcAlpha OneMinusSrcAlpha

    Pass
    {
      CGPROGRAM

      #pragma vertex vert
      #pragma geometry geom
      #pragma fragment frag

      #include "UnityCG.cginc"
    //   #include "../../Packages/Ahoy.Shaders/Shaders/utility.cginc"
      #include "utility.cginc"
      #include "star_utility.cginc"

      struct appdata{
        float4 pos: POSITION; //mesh.vertices
        float4 vel: NORMAL;
        float2 mag: TEXCOORD0; //mesh.uv // x=apparentMag, y=absMag
        float4 color : TANGENT;
      };

      struct v2g{
        float4 pos: SV_POSITION;
        float2 mag: TEXCOORD0;
        float4 color: COLOR;
      };

      struct g2f{
        float4 pos: SV_POSITION;
        float2 uv: TEXCOORD0;
        float4 color: COLOR;
      };

	
      v2g vert (appdata v){ 
        v2g o;
		o.pos = GetNextPos(v.pos,v.vel);
        o.mag= v.mag;
        o.color  = v.color;
        return o;
      }

      float _Radius;
      float _MagDelta;
      float _MagMax;


      [maxvertexcount(4)]
      void geom(point v2g IN[1], inout TriangleStream<g2f> triStream){


		  	//the magic bit, Dad
          float magLog = clamp(IN[0].mag.x,0, 10);
          float magLinear = pow(_MagDelta, -magLog);
          float magClamped = clamp(magLinear,0, _MagMax);

          float screenScale = GetScreenScale(IN[0].pos,_Radius);          
          float scale = screenScale * magClamped;


          float4 verts[4];
          WorldPoint2ClipBillboard(IN[0].pos, scale, verts);


          g2f OUT;
          OUT.color = IN[0].color;
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
          // return fixed4(0,1,1,a);
          return fixed4(i.color.rgb,a);
      }

      ENDCG

    }



  }




}