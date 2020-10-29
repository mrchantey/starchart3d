Shader "StarChart/Constellation"
{
    Properties
    {
		[Header(Size)][Space(10)]
			[Enum(Screen Space,0,World Space,1)]_RelativeSpace("Space", Float) = 0
		[Header(requires post processing enabled on camera)]
		_ScaleOffset ("Scale Offset",Range(0,1000)) = 0
	    _ScaleRange ("Scale Range",Range(0,1)) = 1
        _LineWidth("LineWidth",range(0,0.1))= 0.005

		[Header(Appearance)][Space(10)]
        _Color ("Color",Color) = (1,1,1,1)
		_Glow ("Glow",Range(0,0.1)) = 0.015

		[Header(Culling)][Space(10)]
		[Enum(Off,0,On,1)]_ZWrite ("ZWrite", Float) = 0
		[Enum(UnityEngine.Rendering.CompareFunction)] _ZTest("ZTest", Float) = 4 				//LessEqual
		[Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 0


		[Header(Blending)][Space(10)]
		[Enum (UnityEngine.Rendering.BlendMode)] _BlendSource("Blend Source",Float) =  5		//srcAlpha
		[Enum (UnityEngine.Rendering.BlendMode)] _BlendDestin("Blend Destination",Float) =  10	//OneMinusSrcAlpha

    }

    SubShader
    {
        Tags{"Queue"="Transparent+1"}
		Blend [_BlendSource] [_BlendDestin]
		ZWrite [_ZWrite]
        ZTest [_ZTest]
        Cull [_Cull]

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
				float2 uv: TEXCOORD0;
            };

            v2g vert (appdata i)
            {
                v2g o;
                o.pos = GetNextPos(i.pos,i.vel);
                return o;
            };


            float 
			_RelativeSpace,
			_LineWidth,
			_Glow
			;
            [maxvertexcount(4)]
            void geom(line v2g IN[2], inout TriangleStream<g2f> triStream)
            {
                float3 fwd0 = ObjSpaceViewDir(IN[0].pos);
                float3 fwd1 = ObjSpaceViewDir(IN[1].pos);
                float3 dirFwd = (fwd0 + fwd1) / 2;

                float3 dirRight = (IN[1].pos - IN[0].pos);
                float3 dirUp = normalize(cross(dirFwd,dirRight));


				float scale0,scale1;
				if(_RelativeSpace == 0){
					scale0 = GetScreenScale(IN[0].pos,_LineWidth);
					scale1 = GetScreenScale(IN[1].pos,_LineWidth);
				}else{
					scale0 = -_LineWidth * 10;
					scale1 = -_LineWidth * 10;
				}

                float3 offUp0 = dirUp * scale0;
                float3 offUp1 = dirUp * scale1;

				// if (_ProjectionParams.x < 0){
					//flip for dx11, this should probably be in getscreenscale
					//https://docs.unity3d.com/Manual/SL-PlatformDifferences.html
				// 	offUp0 *= -1;
				// 	offUp1 *= -1;
				// }

                g2f OUT;
                OUT.pos = Object2OffsetClipPos(IN[1].pos,offUp1);
				OUT.uv = float2(0,1);
                triStream.Append(OUT);
                OUT.pos = Object2OffsetClipPos(IN[0].pos,offUp0);
				OUT.uv = float2(1,1);
                triStream.Append(OUT);
                OUT.pos = Object2OffsetClipPos(IN[1].pos,-offUp1);
				OUT.uv = float2(0,0);
                triStream.Append(OUT);
                OUT.pos = Object2OffsetClipPos(IN[0].pos,-offUp0);
				OUT.uv = float2(1,0);
                triStream.Append(OUT);

            }

            fixed4 _Color;

            fixed4 frag(g2f i) : SV_TARGET
            {
				float2 uv2 = i.uv * 2 - float2(1,1);
				float dist = length(uv2);
				float falloff = clamp(dist,0,1);

				float falloff2 = abs(uv2.y);

				float glow = _Glow/falloff2;
				float a = clamp(_Color.a * glow * (1-falloff),0,1);

                return fixed4(_Color.xyz,a);
            }
            ENDCG
        }


    }
}