Shader "Ahoy.Compute/Simple Compute"
{
Properties{ 
    _Color ("Color",Color) = (1,1,1,1)
}
  SubShader{
	Tags {"Queue"="Transparent" "RenderType"="Transparent"}
    Blend SrcAlpha OneMinusSrcAlpha
    ZWrite Off
	ZTest Always
	Cull Off

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