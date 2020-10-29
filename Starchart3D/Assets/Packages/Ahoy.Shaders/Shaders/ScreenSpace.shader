Shader "Ahoy/Screen Space Texture"
{
    Properties
    {
		[Header(General)][Space(10)]
		_MainTex ("Texture", 2D) = "white" {}
        _Color ("Color",Color) = (0,1,1,0.5)
		_Vignette ("Scale",Range(0,1)) = 0.5

		[Header(Blending)][Space(10)]
		[Enum (UnityEngine.Rendering.BlendMode)] _BlendSource("Blend Source",Float) =  5		//srcAlpha
		[Enum (UnityEngine.Rendering.BlendMode)] _BlendDestin("Blend Destination",Float) =  10	//OneMinusSrcAlpha

		[Header(Culling)][Space(10)]
		[Enum(Off,0,On,1)]_ZWrite ("ZWrite", Float) = 0
		[Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Float) = 4 				//LessEqual
		[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 0

    }
    SubShader
    {
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

            struct appdata
            {
                float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 screenPos:TEXCOORD1;
            };

			sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }

            fixed4 _Color;
			float _Vignette;

            fixed4 frag (v2f i) : SV_Target
            {
				float2 uvScreen = i.screenPos.xy / i.screenPos.w;
				// float aspect = _ScreenParams.x / _ScreenParams.y;
				// uvScreen.x *= aspect;
				uvScreen = TRANSFORM_TEX(uvScreen,_MainTex);
				fixed4 col = tex2D(_MainTex, uvScreen);
				col *= _Color;
				float invVig = 1-_Vignette;
				float a = 
				smoothstep(0,_Vignette,i.uv.x) * 
				(1-smoothstep(invVig,1,i.uv.x))*
				smoothstep(0,_Vignette,i.uv.y) * 
				(1-smoothstep(invVig,1,i.uv.y));
				col.a *= a*a*a;
                return col;
            }
            ENDCG
        }
    }
}
