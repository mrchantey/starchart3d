Shader "Starchart3D/Constellation Compute"
{
Properties{ 
    _Color ("Color",Color) = (1,1,1,1)
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
	};

	v2f vert (uint vId : SV_VERTEXID){ 
        v2f o;
		o.pos = vertices[vId];
		uint qi = vId % 4;
		o.uv = float2(floor(qi/2.0),ceil((qi % 3)*0.5));
	  	return o;
	}

	fixed4 _Color;


	fixed4 frag(v2f i): SV_TARGET{
		float a = GetAlpha2D(i.uv);
		return fixed4(_Color.rgb,_Color.a * a);
		// return fixed4(_Color.rgba);
		// return fixed4(abs(i.uv * 2 - float2(1,1)),0,1);	
    }
    ENDCG
    }
  }
}