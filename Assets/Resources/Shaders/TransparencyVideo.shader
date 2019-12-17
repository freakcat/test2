Shader "Unlit/TransparencyVideo"
{
     Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
 
        _F("F",Range(0,10)) = 0.1
    }
    SubShader
    {
//      Tags{"Queue" = "AlphaTest"   "RenderType" = "Transparent" }
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        Cull Off 
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha // Traditional transparency
 
//        Blend One OneMinusSrcAlpha // Premultiplied transparency
//            Blend One One // Additive
//        Blend One Zero 
//        Blend  Zero One 
 //        Blend OneMinusDstColor One  // Soft Additive
//        Blend DstColor Zero // Multiplicative
//        Blend DstColor SrcColor // 2x Multiplicative
 AlphaToMask On
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
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;          
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _F;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);             
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
 
              // if(col.r == col.g == col.b <= 0) col = float4(1,1,1,1);
          
               // else col = float4(1,1,1,1);
               clip(col.a - _F);
               
               
                return col;
            }
            ENDCG
        }
    }
}
