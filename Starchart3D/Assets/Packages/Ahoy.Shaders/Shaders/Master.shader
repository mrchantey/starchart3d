Shader "Ahoy/Master"
{
    Properties
    {
		[Header(General)][Space(10)]
		_MainTex ("Texture", 2D) = "white" {}
        _Color ("Color",Color) = (0,1,1,0.5)
		_Scale ("Scale",Range(-10,10)) = 1

		[Header(Blending)][Space(10)]
		[Enum (UnityEngine.Rendering.BlendMode)] _BlendSource("Blend Source",Float) =  5		//srcAlpha
		[Enum (UnityEngine.Rendering.BlendMode)] _BlendDestin("Blend Destination",Float) =  10	//OneMinusSrcAlpha

		[Header(Culling)][Space(10)]
		[Enum(Off,0,On,1)]_ZWrite ("ZWrite", Float) = 0
		[Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Float) = 4 				//LessEqual
		[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 0

		// [Header(Stencils)][Space(10)]
		// _StencilRef("Stencil Ref", Int) = 0
		// [Enum(UnityEngine.Rendering.CompareFunction)] _StencilTest("Stencil Test", Float) = 3	//Equal
		// [Enum(UnityEngine.Rendering.StencilOp)] _StencilPass("Stencil Pass Op", Float) = 0		//Keep
		// [Enum(UnityEngine.Rendering.StencilOp)] _StencilFail("Stencil Fail Op", Float) = 0		//Keep
		// [Enum(UnityEngine.Rendering.StencilOp)] _StencilZFail("Stencil ZFail Op", Float) = 0	//Keep
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent"}
        Blend [_BlendSource] [_BlendDestin]
        ZWrite [_ZWrite]
        ZTest [_ZTest]
        Cull [_Cull]

		// Stencil{
		// 	Ref [_StencilRef]
		// 	Comp [_StencilTest]
		// 	Pass [_StencilPass]
		// 	Fail [_StencilFail]
		// 	ZFail [_StencilZFail]
		// }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
            };

			sampler2D _MainTex;
            float4 _MainTex_ST;
			float _Scale;

            v2f vert (appdata v)
            {
                v2f o;
				float4 scaledVert = float4(v.vertex.xyz * _Scale,v.vertex.w);
                o.vertex = UnityObjectToClipPos(scaledVert);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 _Color;


            fixed4 frag (v2f i) : SV_Target
            {
				
				fixed4 col = tex2D(_MainTex, i.uv);
				col *= _Color;
                return col;
            }
            ENDCG
        }
    }
}



/*
    public enum BlendMode
    {
        Zero = 0,
        One = 1,
        DstColor = 2,
        SrcColor = 3,
        OneMinusDstColor = 4,
        SrcAlpha = 5,
        OneMinusSrcColor = 6,
        DstAlpha = 7,
        OneMinusDstAlpha = 8,
        SrcAlphaSaturate = 9,
        OneMinusSrcAlpha = 10
    }

    public enum CompareFunction
    {
        Disabled = 0,
        Never = 1,
        Less = 2,
        Equal = 3,
        LessEqual = 4,
        Greater = 5,
        NotEqual = 6,
        GreaterEqual = 7,
        Always = 8
    }

	    public enum StencilOp
    {
        Keep = 0,
        Zero = 1,
        Replace = 2,
        IncrementSaturate = 3,
        DecrementSaturate = 4,
        Invert = 5,
        IncrementWrap = 6,
        DecrementWrap = 7
    }

*/