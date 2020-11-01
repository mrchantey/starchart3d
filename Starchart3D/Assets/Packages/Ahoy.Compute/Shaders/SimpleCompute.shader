Shader "Ahoy.Compute/Simple Compute"
{
Properties{ 
    _Color ("Color",Color) = (1,1,1,1)
	[Header(Blending)][Space(10)]
	[Enum (UnityEngine.Rendering.BlendMode)] _BlendSource("Blend Source",Float) =  5		//srcAlpha
	[Enum (UnityEngine.Rendering.BlendMode)] _BlendDestin("Blend Destination",Float) =  10	//OneMinusSrcAlpha

	[Header(Culling)][Space(10)]
	[Enum(Off,0,On,1)]_ZWrite ("ZWrite", Float) = 0
	[Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Float) = 4 				//LessEqual
	[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 0
}
  SubShader{
    Tags { "Queue"="Transparent" "RenderType"="Transparent"}
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

	struct v2f{
		float4 pos: SV_POSITION;
	};

	StructuredBuffer<float4> vertices;

	// v2f vert (appdata v, uint iId : SV_INSTANCEID, uint vId : SV_VERTEXID){ 
	v2f vert (uint vId : SV_VERTEXID){ 
        v2f o;
		o.pos = vertices[vId];
	  	return o;
	}
	
	fixed4 _Color;
    
	fixed4 frag(v2f i): SV_TARGET{
		return _Color;
    }

    ENDCG
    }
  }
}