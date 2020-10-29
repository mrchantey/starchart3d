Shader "StarChart/Star - Pretty"
{
  Properties{
	[MaterialToggle] _FixedSize("Fixed Size (requires enabled post processing on camera)", Float) = 0
    _ScaleOffset ("Scale Offset",Range(0,1000)) = 0
    _ScaleRange ("Scale Range",Range(0,1)) = 1
    _Radius ("Star Radius",Range(0,10)) = 0.015
    _MagDelta ("Delta Magnitude",Range(1,3)) = 2.5 
    _MagMax ("Maximum Magnitude",Range(0,0.2)) = 0.03
    _TwinkleSpeed ("Twinkle Speed",Range(0,5)) = 0.1
    _TwinkleMax ("Twinkle Amount",Range(0,1)) = 0.5
    _Glow ("Glow",Range(0,0.1)) = 0.015
    _FlareMagMin ("Flare Count",Range(0.00001,0.2)) = 0.1
    _Flare1Weight ("Flare 1 Weight",Range(0,1000)) = 0.1
    _Flare1Opacity ("Flare 1 Opacity",Range(0,1)) = 1
    _Flare2Weight ("Flare 2 Weight",Range(0,1000)) = 0.1
    _Flare2Opacity ("Flare 2 Opacity",Range(0,1)) = 1

  }
  SubShader{
    Tags{"Queue"="Transparent+1"}
	// ZTest Always
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
        float2 mag: TEXCOORD0;
        float2 uv: TEXCOORD1;
        float2 misc: TEXCOORD2;//x=twinkle
        float4 color: COLOR;
      };

	
      v2g vert (appdata v){ 
        v2g o;
		o.pos = GetNextPos(v.pos,v.vel);
        o.mag= v.mag;
        o.color  = v.color;
        return o;
      }

      float 
	  _FixedSize,
	  _Radius,
	  _TwinkleSpeed,
	  _TwinkleMax,
	  _Glow,
	  _MagDelta,
	  _MagMax,
	  _FlareMagMin,
	  _Flare1Opacity,
	  _Flare1Weight,
	  _Flare2Opacity,
	  _Flare2Weight
	  ;

	float hash31(float3 p){
		p = frac(p * float3(123.45,678.93,987.75));
		p += dot(p,p+12.34);
		return frac(p.x * p.y * p.z);
	}


	float getTwinkle(float3 pos){
			float id = hash31(pos);
			float theta = _Time.w * _TwinkleSpeed * id + id * 6.2831;
			float t = sin(theta) * 0.5 + 0.5;
			return lerp(1-_TwinkleMax,1,t);
	}

      [maxvertexcount(4)]
      void geom(point v2g IN[1], inout TriangleStream<g2f> triStream){


		  	//the magic bit, Dad
          float magLog = clamp(IN[0].mag.x,0, 10);
          float magLinear = pow(_MagDelta, -magLog);
          float magClamped = clamp(magLinear,0, _MagMax);

          float scale;
		  if(_FixedSize == 0){
			float screenScale = GetScreenScale(IN[0].pos,_Radius);
			scale = screenScale * magClamped;
		  }else{
			  scale = _Radius * magClamped * 10;
		  }

          float4 verts[4];
          WorldPoint2ClipBillboard(IN[0].pos, scale, verts);

          g2f OUT;

		  OUT.misc = float2(getTwinkle(IN[0].pos),0);
		  OUT.mag = float2(IN[0].mag.x,magClamped);
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


	float getFlare(float2 uv, float opacity, float weight){
		float directionScalar = abs(uv.x * uv.y);
		float flare  = 1- directionScalar * (1000-weight);		
		flare *= opacity;
		return clamp(flare,0,1);
	}

	float2 rotateUV(float2 uv, float rotation)
	{
    	return float2(
        	cos(rotation) * uv.x + sin(rotation) * uv.y,
        	cos(rotation) * uv.y - sin(rotation) * uv.x);
	}


      fixed4 frag(g2f i): SV_TARGET{

		float2 uv2 = i.uv * 2 - float2(1,1);
        float dist = length(uv2);
        float falloff = clamp(dist,0,1);


		float glow = _Glow/falloff;
		uv2 *= 4;
		float2 uv3 = rotateUV(uv2,3.14/4);
		float flare1 = getFlare(uv2,_Flare1Opacity,_Flare1Weight);
		float flare2 = getFlare(uv3,_Flare2Opacity,_Flare2Weight);
		float flare = (flare1 + flare2) * smoothstep(_MagMax-_FlareMagMin,_MagMax,i.mag.y);





		float a = clamp(glow + flare,0,1)* (1-falloff) * i.misc.x;

          return fixed4(i.color.rgb,a);
      }

      ENDCG

    }



  }




}