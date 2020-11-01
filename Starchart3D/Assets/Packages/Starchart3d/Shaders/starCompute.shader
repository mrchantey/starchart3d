Shader "Starchart3D/Star Compute"
{
Properties{ 
    _Color ("Color",Color) = (1,1,1,1)
	[MaterialToggle] _UseStarColors("Use Star Colors", Float) = 0
	[Header(Culling)][Space(10)]
	[Enum(Off,0,On,1)]_ZWrite ("ZWrite", Float) = 0
	[Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Float) = 4 				//LessEqual
	[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 0
	[Header(Blending)][Space(10)]
	[Enum (UnityEngine.Rendering.BlendMode)] _BlendSource("Blend Source",Float) =  5		//srcAlpha
	[Enum (UnityEngine.Rendering.BlendMode)] _BlendDestin("Blend Destination",Float) =  10	//OneMinusSrcAlpha
}
  SubShader{
    Tags{"Queue"="Transparent+1"}
	Blend [_BlendSource] [_BlendDestin]
	ZWrite [_ZWrite]
    ZTest [_ZTest]
    Cull [_Cull]

    Pass
    {
    CGPROGRAM

	#pragma vertex vert
    #pragma fragment frag
    #include "UnityCG.cginc"
    #include "./starUtilityRender.cginc"


	struct v2f{
		float4 pos: SV_POSITION;
		float2 uv: TEXCOORD0;
		uint id: TEXCOORD1;
		float twinkle: TEXCOORD2;
	};

	v2f vert (uint vId : SV_VERTEXID){ 
        v2f o;
		o.pos = vertices[vId];
		uint qi = vId % 4;
		o.uv = float2(floor(qi/2.0),ceil((qi % 3)*0.5));
		o.id = floor(vId / 4.0);
		o.twinkle = GetTwinkle(stars[o.id].position);
	  	return o;
	}

	fixed4 _Color;
	float _UseStarColors;

	fixed4 frag(v2f i): SV_TARGET{
		float a = GetAlpha(i.uv) * i.twinkle;
		fixed4 col = _UseStarColors ? fixed4(stars[i.id].color.xyz,a) : fixed4(1,1,1,a);
		return col * _Color;
    }

    ENDCG
    }
  }
}