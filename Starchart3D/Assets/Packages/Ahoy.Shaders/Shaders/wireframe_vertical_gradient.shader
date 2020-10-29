Shader "Ahoy/Wireframe - Vertical Gradient"
{
    Properties
    {
        _Fill ("Fill",Color) = (0,0,0,0)
        _Edge1 ("Edge 1",Color) = (0,0,0,1)
        _Edge2 ("Edge 2",Color) = (1,1,1,0)
		_GradientStep1 ("GradientStep 1",Float) = 0
		_GradientStep2 ("GradientStep 2",Float) = 1
        _WireSize ("Wire Cutoff",Range(0.5,1)) = 0.9
        _WireSmoothness ("Wire Smoothness",Range(0,0.2)) = 0.001
		[MaterialToggle] _Hypotenuse("Include Hypotenuse", Float) = 0

		//For Face Cull = Off on transparent convex objects, write another shader with two passes, one culling front the other culling back
		[Enum(Back,2,Front,1,Off,0)] _FaceCull ("Face Cull",int) = 0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent"}
        ZWrite Off
        // ZWrite [_ZWrite]
        Blend SrcAlpha OneMinusSrcAlpha
        Cull [_FaceCull]

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #pragma geometry geom
            #pragma target 4.0

            #include "UnityCG.cginc"

            struct appdata
            {
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
                float4 vertex : POSITION;
            };

            struct v2g
            {
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
				float3 vertObj : TANGENT;
                float4 vertex : SV_POSITION;
            };
            struct g2f
            {
                float2 uv : TEXCOORD0;
                float3 bary : TEXCOORD1;
				float3 vertWorld : TANGENT;
                float3 normal : NORMAL;
                float4 vertex : SV_POSITION;
            };

            v2g vert (appdata v)
            {
                v2g o;
				o.vertObj = v.vertex;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.normal = v.normal;
                return o;
            }


            [maxvertexcount(3)]
            void geom(triangle v2g IN[3], inout TriangleStream<g2f> triStream)
            {
                g2f OUT;

                int iA,iB,iC;//iC = hypotenuse vert

                float3 dirAB = IN[1].vertObj - IN[0].vertObj;
                float3 dirAC = IN[2].vertObj - IN[0].vertObj;
                float3 dirBC = IN[2].vertObj - IN[1].vertObj;
                
                float lenAB = length(dirAB);
                float lenAC = length(dirAC);
                float lenBC = length(dirBC);
                
                if(lenAB > lenAC && lenAB > lenBC)
					{iC = 2;iA = 0;iB = 1;}
				else if(lenAC > lenBC)
					{iC = 1;iA = 2;iB = 0;}
				else
					{iC = 0;iA = 1;iB = 2;}
                
                float3 normal = normalize(cross(dirAB.xyz,dirAC.xyz));
                OUT.normal = normal;
            
                OUT.uv = IN[iA].uv;
                OUT.bary = float3(1,0,0);
                // OUT.normal = IN[0].normal;
                OUT.vertex = IN[iA].vertex;
				OUT.vertWorld = mul(unity_ObjectToWorld, IN[iA].vertObj);
                triStream.Append(OUT);
                OUT.uv = IN[iB].uv;
                OUT.bary = float3(0,1,0);
                // OUT.normal = IN[1].normal;
                OUT.vertex = IN[iB].vertex;
				OUT.vertWorld = mul(unity_ObjectToWorld, IN[iB].vertObj);
                triStream.Append(OUT);
                OUT.uv = IN[iC].uv;
                // OUT.bary = float3(1,1,0);
                OUT.bary = float3(0,0,1);
                // OUT.normal = IN[2].normal;
                OUT.vertex = IN[iC].vertex;
				OUT.vertWorld = mul(unity_ObjectToWorld, IN[iC].vertObj);
                triStream.Append(OUT);
            }


            fixed4 _Fill,_Edge1,_Edge2;
            float _WireSize, _WireSmoothness, _Hypotenuse, _GradientStep1, _GradientStep2;

            fixed4 frag (g2f i) : SV_Target
            {
				float edgeColT = smoothstep(_GradientStep1,_GradientStep2,i.vertWorld.y);
				fixed4 edgeCol = lerp(_Edge1,_Edge2,edgeColT);


				float furthest = _Hypotenuse == 0 ? min(i.bary.x,i.bary.y) : min(min(i.bary.x,i.bary.y),i.bary.z);
                float colT = smoothstep(_WireSize,_WireSize + _WireSmoothness,1-furthest);
				fixed4 color = lerp(_Fill,edgeCol,colT);
                return color;
            }
            ENDCG
        }
    }
}
 