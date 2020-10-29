//https://forum.unity.com/threads/getting-normals-relative-to-camera-view.452631/?_ga=2.77722132.149337910.1594102751-187590989.1593480001#post-2933684

/*
No. It was the same normal using the old method because the normal and "view direction" (camera forward vector) are both constant across the screen. 
With the perspective correction the "view direction" varies across the screen as it's now the angle from the camera position to that vertex position. 
The normal being constant was the reason it looked funny before!

The issue you're seeing now is the calculations are being done at the vertex level and not per-pixel (again, because it's cheaper). 
However for something like a box you see this break down in a way the old method didn't. 
You'd have to modify the shader I posted to pass both the viewNorm and viewPos (not viewDir!) to the fragment shader and do lines 42 - 51 in the fragment shader.

*/

Shader "Unlit/Matcap"
{
    Properties
    {
        _Matcap ("Matcap", 2D) = "white"
        [Toggle] _PerspectiveCorrection ("Use Perspective Correction", Float) = 1.0
    }
 
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
 
            #include "UnityCG.cginc"
 
            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 cap : TEXCOORD0;
            };
 
            sampler2D _Matcap;
            bool _PerspectiveCorrection;
 
            v2f vert (appdata_full v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                           
                float3 worldNorm = UnityObjectToWorldNormal(v.normal);
                float3 viewNorm = mul((float3x3)UNITY_MATRIX_V, worldNorm);
 
                if (_PerspectiveCorrection)
                {
                    // get view space position of vertex
                    float3 viewPos = UnityObjectToViewPos(v.vertex);
                    float3 viewDir = normalize(viewPos);
 
                    // get vector perpendicular to both view direction and view normal
                    float3 viewCross = cross(viewDir, viewNorm);
                   
                    // swizzle perpendicular vector components to create a new perspective corrected view normal
                    viewNorm = float3(-viewCross.y, viewCross.x, 0.0);
                }
           
                o.cap = viewNorm.xy * 0.5 + 0.5;
                return o;
            }
 
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_Matcap, i.cap);
                return col;
            }
 
            ENDCG
        }
    }
}