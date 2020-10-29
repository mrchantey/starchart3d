
//LIGHT CONE URP https://youtu.be/rihJzWq7sE4
//Shadergraph Forcefield https://youtu.be/NiOGWZXBg4Y
//Forcefield Shader https://youtu.be/C6lGEgcHbWc
// -- In Depth https://medium.com/@aarhed/shield-shader-85cdaf903db7
//Camera Depth Texture https://docs.unity3d.com/Manual/SL-CameraDepthTexture.html

Shader "Ahoy/Light Cone no good"
{
    Properties
    {
		_Color ("Color",Color) = (0,1,1,1)
		_Angle ("Angle",Range(0,10)) = 1
    }
    SubShader
    {
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

		Cull Front
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
                float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
				float3 viewNormal : TANGENT;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				float3 worldNorm = UnityObjectToWorldNormal(v.normal);
                float3 viewNorm = mul((float3x3)UNITY_MATRIX_V, worldNorm);
				float3 viewPos = UnityObjectToViewPos(v.vertex);
				float3 viewDir = normalize(viewPos);
				float3 viewCross = cross(viewDir, viewNorm);
				// viewNorm = float3(-viewCross.y, viewCross.x, viewNorm.z);
				viewNorm = float3(-viewCross.y, viewCross.x, viewNorm.z);
				o.viewNormal = viewNorm;
                o.uv = v.uv;
				o.normal = v.normal;
                return o;
            }

			fixed4 _Color;
			float _Angle;

            fixed4 frag (v2f i) : SV_Target
            {
				// float2 viewUV = abs(i.viewNormal.xy);
				// float angle = min(viewUV.x,viewUV.y);
				// float2 viewUV = i.viewNormal.xy * 0.5 + 0.5;
				float t = clamp(i.viewNormal.z*-1,0,1);
				float a = lerp(0,_Color.a,pow(t,_Angle));
				fixed4 col = fixed4(_Color.xyz,a);
				// fixed4 col = fixed4(viewUV.x,viewUV.y,0,1);
				// fixed4 col = fixed4(i.viewNormal * 0.5 + 0.5,1);
				// fixed4 col = _Color;	
                return col;
            }
            ENDCG
        }
    }
}
