Shader "Skybox/SKYGradient"
{
Properties
{
_Color ("Top Color", Color) = (1,1,1,1)
_Color1 ("Bottom Color", Color) = (1,1,1,1)
_MainTex ("Albedo (RGB)", 2D) = "white" {}
}
SubShader
{
Tags { "RenderType"="Opaque" "Queue"="Background" }
LOD 200

Pass
    {
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        #pragma multi_compile_skybox

        uniform sampler2D _MainTex;
        uniform float4 _Color;
        uniform float4 _Color1;

        struct appdata
        {
            float4 vertex : POSITION;
            float3 uv : TEXCOORD0;
        };

        struct v2f
        {
            float3 uv : TEXCOORD0;
            float4 vertex : SV_POSITION;
        };

        v2f vert (appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = v.uv;
            return o;
        }

        float4 frag (v2f i) : SV_Target
        {
            float2 screenUV = i.uv.xy;
            float4 c = tex2D (_MainTex, i.uv) * lerp(_Color, _Color1, screenUV.y);
            return c;
        }
        ENDCG
    }
}
FallBack "Diffuse"
}