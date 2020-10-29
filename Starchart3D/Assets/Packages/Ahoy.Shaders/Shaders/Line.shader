Shader "Ahoy/Line"
{
    Properties
    {
        _LineWidth("Line Width",range(0,0.5))= 0.005
        _Color ("Color",Color) = (1,1,1,1)
        [MaterialToggle] _FixedSize("Fixed Size (Requires enabled post processing on camera)", Float) = 0
    }

    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        // Tags {"DisableBatching"="True" "Queue"="Transparent" "RenderType"="Transparent"}
        ZWrite off        
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma geometry geom
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Utility.cginc"

            struct appdata
            {
                float4 pos : POSITION;
            };

            struct v2g 
            {
                float4 pos : SV_POSITION;
            };

            struct g2f
            {
                float4 pos : SV_POSITION;
            };

            v2g vert (appdata i)
            {
                v2g o;
                // o.pos = UnityObjectToClipPos(i.pos);
                o.pos = i.pos;
                return o;
            };

            float _LineWidth;
            float _FixedSize;
            [maxvertexcount(4)]
            void geom(line v2g IN[2], inout TriangleStream<g2f> triStream)
            {
                // float3 fwd0 = WorldSpaceViewDir(IN[0].pos);
                // float3 fwd1 = WorldSpaceViewDir(IN[1].pos);
                float3 fwd0 = ObjSpaceViewDir(IN[0].pos);
                float3 fwd1 = ObjSpaceViewDir(IN[1].pos);
                float3 dirFwd = (fwd0 + fwd1) / 2;

                float3 dirRight = (IN[1].pos - IN[0].pos);
                float3 dirUp = normalize(cross(dirFwd,dirRight));


                float3 offUp0;
                float3 offUp1;
                if(_FixedSize == 0){
                    offUp0 = dirUp * _LineWidth;
                    offUp1 = dirUp * _LineWidth;
                }else{
                    float screenScale0 = GetScreenScale(IN[0].pos,_LineWidth);
                    float screenScale1 = GetScreenScale(IN[1].pos,_LineWidth);
                    offUp0 = dirUp * screenScale0;
                    offUp1 = dirUp * screenScale1;
					if (_ProjectionParams.x < 0){
						//flip for dx11, this should probably be in getscreenscale
						//https://docs.unity3d.com/Manual/SL-PlatformDifferences.html
						offUp0 *= -1;
						offUp1 *= -1;
					}
                }


                g2f OUT;
                OUT.pos = Object2OffsetClipPos(IN[1].pos,offUp1);
                triStream.Append(OUT);
                OUT.pos = Object2OffsetClipPos(IN[0].pos,offUp0);
                triStream.Append(OUT);
                OUT.pos = Object2OffsetClipPos(IN[1].pos,-offUp1);
                triStream.Append(OUT);
                OUT.pos = Object2OffsetClipPos(IN[0].pos,-offUp0);
                triStream.Append(OUT);
            }

            fixed4 _Color;

            fixed4 frag(g2f i) : SV_TARGET
            {
                return _Color;
            }
            ENDCG
        }


    }
}