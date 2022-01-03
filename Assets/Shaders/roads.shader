Shader "Custom/roads"
{
    Properties
    {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normal ("Normal", 2D) = "bump" {}
        _NormalAmount("Bump Amount", Range(0,1)) = 1
		_SmoothnessTex ("Smoothness Tex", 2D) = "white" {}
        _SmoothAmount("Smooth Amount", Range(0,1)) = 0.5
    }
    SubShader
    {

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _Diffuse;
        sampler2D _Normal;
        sampler2D _SmoothnessTex;

        half _NormalAmount;
        half _SmoothAmount;

        struct Input
        {
            float2 uv_Diffuse;
            float2 uv_Normal;
            float2 uv_SmoothnessTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = tex2D(_Diffuse, IN.uv_Diffuse).rgb;
            o.Normal = UnpackNormal(tex2D(_Normal, IN.uv_Normal));
            				o.Normal *= float3(_NormalAmount,_NormalAmount, 1);
                            o.Smoothness = tex2D (_SmoothnessTex, IN.uv_SmoothnessTex).rgb * _SmoothAmount;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
