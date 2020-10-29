Shader "Ahoy/Pulse"
{
    Properties
    {
		[Header(General)][Space(10)]
		_MainTex ("Texture", 2D) = "white" {}
        _Color ("Color 1",Color) = (0,1,1,0.5)
        _Color2 ("Color 2",Color) = (0,1,1,0)
		_Scale ("Scale",Range(-10,10)) = 1
		_Speed ("Speed",Range(0,60)) = 1

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
            #include "./utility.cginc"

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
			float _Scale,_Speed;

            v2f vert (appdata v)
            {
                v2f o;
				float4 scaledVert = float4(v.vertex.xyz * _Scale,v.vertex.w);
                o.vertex = UnityObjectToClipPos(scaledVert);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 _Color,_Color2;


            fixed4 frag (v2f i) : SV_Target
            {
				
				fixed4 col = tex2D(_MainTex, i.uv);
				float t = sin(_Time.y * _Speed * PI) * 0.5 + 0.5;
				col *= lerp(_Color,_Color2,t);
                return col;
            }
            ENDCG
        }
    }
}

