Shader "Ahoy/Click Ripple"
{
    Properties
    {
        _Frequency ("Frequency", Range(0,100)) = 10
        _Amplitude ("Amplitude", Range(0,2)) = 1
        _Duration ("Duration", Range(0,30)) = 2
        _Radius ("Radius", Range(0,30)) = 0.5
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        blend SrcAlpha OneMinusSrcAlpha

        GrabPass
        {
            "_BackgroundTexture"
        }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "./easingFunctions.cginc"

            #define MAX_RIPPLES 1000

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 grabPos : TEXCOORD1;
                float4 worldPos : TEXCOORD2;
                float4 pos : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v) {
                v2f o;
                o.worldPos = mul(unity_ObjectToWorld,v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                o.grabPos = ComputeGrabScreenPos(o.pos);
                return o;
            }

            sampler2D _BackgroundTexture;
            float _Frequency;
            float _Amplitude;
            float _Duration;
            float _Radius;

            struct RippleInfo{
                float3 position;
                float timeStamp;
            };

            struct polar{
                float radius;
                float theta;
            };

            polar ToPolar(float2 xy){
                polar pol;
                pol.radius = length(xy);
                pol.theta = atan2(xy.y,xy.x);
                return pol;
            }

            uniform fixed4 rippleObjects[MAX_RIPPLES];
            uniform int rippleObjectCount;
            uniform float timeStamp;

            float GetRippleAmount(polar pol,float dTime){
                float timeNorm  = dTime / _Duration;
                float lenNorm = pol.radius / _Radius;
                if(lenNorm / timeNorm > 1)
                return 0;
                float pi = 3.14159265359;
                if(lenNorm > 1)
                return 0;
                float distDiminish = 1-EaseOutCubic(lenNorm);
                float timeDiminish = 1- EaseOutCubic(timeNorm);
                float amp = distDiminish * timeDiminish * _Amplitude;

                float theta = lenNorm * pi * 2 * _Frequency;
                float phase = timeNorm * _Frequency * pi * 2 + pi;
                float val = sin(theta - phase) * amp;
                return val;
                // return amp;
            }


            half4 frag(v2f IN) : SV_Target
            {
            uint numStructs = rippleObjectCount;
            float4 offsetPos= float4(0,0,0,0);
            for(uint i = 0; i < numStructs; i++){
                // float dTime = _Time.y - rippleObjects[i].w;//webgl time seems to run approx 2 seconds slower than unity time
                float dTime = timeStamp - rippleObjects[i].w;
                if(dTime >  _Duration || dTime <= 0)
                continue;
                float3 dpos = rippleObjects[i].xyz - IN.worldPos;
                polar pol = ToPolar(dpos);
                float val = GetRippleAmount(pol,dTime);
                // if(val == 1)
                // valSum += val * 0.5 + 0.5;
                offsetPos.xy += float2(cos(pol.theta),sin(pol.theta)) * val * _Amplitude;
            }

            fixed4 bgcolor = tex2Dproj(_BackgroundTexture, IN.grabPos + offsetPos);
            return bgcolor;
            }

            ENDCG
        }

    }
}
