Shader "StarChart/Constellation"
{
    Properties
    {
		_ScaleOffset ("Scale Offset",Range(0,1000)) = 0
	    _ScaleRange ("Scale Range",Range(0,1)) = 1
        _LineWidth("LineWidth",range(0,0.01))= 0.005
        _Color ("Color",Color) = (1,1,1,1)

    }

    SubShader
    {
        Tags{"Queue"="Transparent"}
        ZWrite off
        

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma geometry geom
            #pragma fragment frag

            #include "UnityCG.cginc"
			// #include "../../Packages/Ahoy.Shaders/Shaders/utility.cginc"
			#include "utility.cginc"
            #include "star_utility.cginc"


            struct appdata
            {
                float4 pos : POSITION;
                float4 vel : NORMAL;
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
                o.pos = GetNextPos(i.pos,i.vel);
                return o;
            };


            float _LineWidth;
            [maxvertexcount(4)]
            void geom(line v2g IN[2], inout TriangleStream<g2f> triStream)
            {
                float3 fwd0 = WorldSpaceViewDir(IN[0].pos);
                float3 fwd1 = WorldSpaceViewDir(IN[1].pos);
                float3 dirFwd = (fwd0 + fwd1) / 2;

                float3 dirRight = (IN[1].pos - IN[0].pos);
                float3 dirUp = normalize(cross(dirFwd,dirRight));

                float screenScale0 = GetScreenScale(IN[0].pos,_LineWidth);
                float screenScale1 = GetScreenScale(IN[1].pos,_LineWidth);

                float3 offUp0 = dirUp * screenScale0;
                float3 offUp1 = dirUp * screenScale1;

                g2f OUT;
                OUT.pos = Object2OffsetClipPos(IN[1].pos,-offUp1);
                triStream.Append(OUT);
                OUT.pos = Object2OffsetClipPos(IN[0].pos,-offUp0);
                triStream.Append(OUT);
                OUT.pos = Object2OffsetClipPos(IN[1].pos,offUp1);
                triStream.Append(OUT);
                OUT.pos = Object2OffsetClipPos(IN[0].pos,offUp0);
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