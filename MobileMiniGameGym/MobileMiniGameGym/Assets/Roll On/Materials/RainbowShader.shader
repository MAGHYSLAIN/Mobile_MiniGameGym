Shader "Custom/Rainbow" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Speed ("Speed", Range(0, 10)) = 1
        _Emission ("Emission", Range(0, 1)) = 0
    }
    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Opaque"}
        LOD 100
        
        Blend SrcAlpha OneMinusSrcAlpha
        
        CGPROGRAM
        #pragma surface surf Standard
        
        sampler2D _MainTex;
        float _Speed;
        float _Emission;
        
        struct Input {
            float2 uv_MainTex;
        };
        
        void surf (Input IN, inout SurfaceOutputStandard o) {
            float timeFactor = _Time.y * _Speed;
            o.Albedo.r = sin(timeFactor * 2 * 3.141592) * 0.5 + 0.5;
            o.Albedo.g = sin(timeFactor * 2 * 3.141592 + 2.094395) * 0.5 + 0.5;
            o.Albedo.b = sin(timeFactor * 2 * 3.141592 + 4.188790) * 0.5 + 0.5;
            o.Alpha = 1;
            o.Metallic = 0;
            o.Smoothness = 0.5;
            o.Normal = float3(0, 0, 1);
            o.Emission = o.Albedo * _Emission;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
