Shader "Unlit/ToonShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Brightness("Brightness", Range(0,1)) = 0.3
        _Strength("Strength", Range(0,1)) = 0.5
        _Color("Color", COLOR) = (1,1,1,1)
        _Detail("Detail", Range(0,1)) = 0.3
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineThickness ("Outline Thickness", Range(0, 0.1)) = 0.02
    }
    SubShader
    {
         Tags { "RenderType"="Opaque" }
    LOD 100
    ZWrite On
ZTest LEqual

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
            float3 normal : NORMAL;
        };

        struct v2f
        {
            float2 uv : TEXCOORD0;
            float4 vertex : SV_POSITION;
            half3 worldNormal: NORMAL;
        };

        sampler2D _MainTex;
        float4 _MainTex_ST;
        float _Brightness;
        float _Strength;
        float4 _Color;
        float _Detail;
        float4 _OutlineColor;
        float _OutlineThickness;

        float Toon(float3 normal, float3 lightDir) {
            float NdotL = max(0.0,dot(normalize(normal), normalize(lightDir)));

            return floor(NdotL / _Detail);
        }

        v2f vert (appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = TRANSFORM_TEX(v.uv, _MainTex);
            o.worldNormal = UnityObjectToWorldNormal(v.normal);
            return o;
        }

        fixed4 frag (v2f i) : SV_Target
        {
            // sample the texture
            fixed4 col = tex2D(_MainTex, i.uv);

            // Calculate the outline by checking the difference between the current pixel and its neighbors
            float2 texel = 1.0 / _ScreenParams.xy;
            float4 outl = float4(0, 0, 0, 0);
            for(int y=-1; y<=1; y++)
            {
                for(int x=-1; x<=1; x++)
                {
                    float2 uv = i.uv + texel * float2(x, y);
                    float4 samp = tex2D(_MainTex, uv);
                    outl += samp;
                }
            }
            outl /= 9.0;
            float4 diff = col - outl;
            float4 outline = _OutlineThickness * step(_OutlineThickness, length(diff.rgb));
            outline *= _OutlineColor;
            col = lerp(col, outline, outline.a);

            // Apply the toon shading to the pixel color
            col *= Toon(i.worldNormal, _WorldSpaceLightPos0.xyz) * _Strength * _Color + _Brightness;
            return col;
        }
        ENDCG
    }

        //Pass for Casting Shadows 
        Pass 
        {
            Name "CastShadow"
            Tags { "LightMode" = "ShadowCaster" }
    
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_shadowcaster
            #include "UnityCG.cginc"
    
            struct v2f 
            { 
                V2F_SHADOW_CASTER;
            };
    
            v2f vert( appdata_base v )
            {
                v2f o;
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
    
            float4 frag( v2f i ) : COLOR
            {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
}