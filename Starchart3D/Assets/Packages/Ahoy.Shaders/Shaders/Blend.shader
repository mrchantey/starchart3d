Shader "Ahoy/Blend"
{
    Properties
    {
		_Color1 ("Color 1",Color) = (0,1,1,1)
		_Color2 ("Color 2",Color) = (1,0,1,1)
		// [Enum(One,0,Zero,1,SrcColor,2,SrcAlpha,3,DstColor,4,DstAlpha,5,OneMinusSrcColor,6,OneMinusSrcAlpha,7,OneMinusDstColor,8,OneMinusDstAlpha,9)] _SrcBlend ("This Pixel",int) = 0
		// [Enum(One,0,Zero,1,SrcColor,2,SrcAlpha,3,OneMinusSrcColor,6,OneMinusSrcAlpha,7)] _SrcBlend ("This Pixel",int) = 3
		// [Enum(One,0,Zero,1,SrcColor,2,SrcAlpha,3,OneMinusSrcColor,6,OneMinusSrcAlpha,7)] _DstBlend ("Existing Pixel",int) = 7
		// [Enum(One,0,Zero,1,SrcColor,2,SrcAlpha,3,DstColor,4,DstAlpha,5,OneMinusSrcColor,6,OneMinusSrcAlpha,7,OneMinusDstColor,8,OneMinusDstAlpha,9)] _SrcBlend ("This Pixel",int) = 0
		// [Enum(Add,0,Sub,1,RevSub,2,Min,3,Max,4)] _BlendOp ("Blend Operation",int) = 0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent"}
		// Blend [_SrcBlend] [_DstBlend]
		Blend SrcAlpha OneMinusSrcAlpha
		BlendOp [_BlendOp]

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
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
				o.normal = v.normal;
                return o;
            }


			fixed4 _Color1;
			fixed4 _Color2;

            fixed4 frag (v2f i) : SV_Target
            {
				float t = clamp(length((i.uv - 0.5) * 2),0,1);
				fixed4 col = lerp(_Color1,_Color2,t);
                return col;
            }
            ENDCG
        }
    }
}
