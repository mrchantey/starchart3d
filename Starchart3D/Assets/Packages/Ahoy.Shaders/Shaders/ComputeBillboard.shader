Shader "Ahoy/Compute Billboard - Geometry"
{
Properties{
 
    _Radius ("Radius",Range(0,1)) = 0.1
    _Color ("Color",Color) = (1,1,1,1)
	[MaterialToggle] _FixedSize("Fixed Size (requires enabled post processing on camera)", Float) = 0
}
  SubShader{
	Tags {"Queue"="Transparent" "RenderType"="Transparent"}
    // ZWrite Off
    Blend SrcAlpha OneMinusSrcAlpha

    Pass
    {
    CGPROGRAM

	#pragma vertex vert
    #pragma geometry geom
    #pragma fragment frag

    #include "UnityCG.cginc"
	#include "./utility.cginc"


    struct appdata{
        float4 pos: POSITION;
    };


	struct v2g{
		float4 vId: SV_POSITION;
	};

    struct g2f{
        float4 pos: SV_POSITION;
        float2 uv: TEXCOORD0;
    };

	int bufferOffset;
	StructuredBuffer<float3> positions;

	float _FixedSize;
	fixed4 _Color;
	float _Radius;

	v2g vert (appdata v, uint iId : SV_INSTANCEID, uint vId : SV_VERTEXID){ 
        v2g o;
		o.vId = float4(vId,0,0,0);
        return o;
      }

	[maxvertexcount(4)]
    void geom(point v2g IN[1], inout TriangleStream<g2f> triStream){

		int i = bufferOffset + IN[0].vId.x;
		float4 pos = float4(positions[i],1);
		float scale = _FixedSize == 0 ?
			GetScreenScale(pos,_Radius) :
			_Radius;

        float4 verts[4];
        WorldPoint2ClipBillboard(pos, scale, verts);

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
		return _Color;
    }

    ENDCG
    }
  }
}