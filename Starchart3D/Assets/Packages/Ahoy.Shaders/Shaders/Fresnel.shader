//http://kylehalladay.com/blog/tutorial/2014/02/18/Fresnel-Shaders-From-The-Ground-Up.html
Shader "Ahoy/Fresnel"
{
    Properties
    {
		_Fill ("Fill",Color) = (0,1,1,1)
		_Edge ("Edge",Color) = (1,1,1,0.5)
		_Bias ("Bias",Range(0,1)) = 0.5
		_Scale ("Scale",Range(0,1))= 0.5
		_Exponent ("Exponent",Range(0,10)) = 1
    }
    SubShader
    {
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
			

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
				float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                // float2 uv : TEXCOORD0;
				// float3 normal : NORMAL;
				float fresnel : TEXCOORD1;
				// float3 viewNormal : TANGENT;
                float4 vertex : SV_POSITION;
            };


			float _Bias,_Scale,_Exponent;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);

				float3 posWorld = mul(unity_ObjectToWorld, v.vertex).xyz;
				float3 normWorld = normalize(mul(unity_ObjectToWorld, v.normal));

				float3 I = normalize(posWorld - _WorldSpaceCameraPos.xyz);
				o.fresnel = clamp(_Bias + _Scale * pow(1.0 + dot(I, normWorld), _Exponent),0,1);
                return o;
            }

			fixed4 _Fill,_Edge;

            fixed4 frag (v2f i) : SV_Target
            {
				return lerp(_Fill,_Edge,i.fresnel);
            }
            ENDCG
        }


    }
}
