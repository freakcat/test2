// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/FilterfColor"
{
      Properties { 
        _MainTex ("Base (RGB)", 2D) = "white" {} 
        _FilterfColor("Ridof (RGB)",Color)=(0,0,0,0) 
        _F("_F",Range(0,10000)) = 1
    } 
    SubShader { 
        Tags { "RenderType"="Opaque" } 
       // ZWrite Off
        Cull Off
        Blend SrcAlpha SrcColor 
        Blend One Zero
        LOD 200
        Lighting Off
        AlphaToMask On
        pass 
        { 
            CGPROGRAM 

            #pragma vertex vertext_convert
            #pragma fragment fragment_convert
            #include "UnityCG.cginc" 

            sampler2D  _MainTex; 
            sampler2D  _MainTex1; 
            float4  _FilterfColor; 
            float _F;
            struct Inputvrite 
            { 
                float4 vertex : POSITION; 
                float4 texcoord : TEXCOORD0; 
            }; 
            struct Inputfragment 
            { 
                float4 pos : SV_POSITION; 
                float4 uv : TEXCOORD0; 
            }; 

            float ColorLerp(float3 tmp_nowcolor,float3 tmp_FilterfColor) 
            { 
                float3 dis = float3(abs(tmp_nowcolor.x - tmp_FilterfColor.x),abs(tmp_nowcolor.y - tmp_FilterfColor.y),abs(tmp_nowcolor.z - tmp_FilterfColor.z)); 
                float dis0 =sqrt(pow(dis.x,33)+pow(dis.y,33)+pow(dis.z,33)); 
                float maxdis = sqrt(3); 
                float dis1 = lerp(0,maxdis,dis0); 
                return dis1*100000; 
            } 

            Inputfragment vertext_convert(Inputvrite i) 
            { 
                Inputfragment o; 
                o.pos = UnityObjectToClipPos(i.vertex); 
                o.uv = float4(i.texcoord.xy,1,1); 
                return o; 
            } 

            float4 fragment_convert(Inputfragment o) : COLOR 
            { 
                float4 c = tex2D(_MainTex,o.uv); 
                //这个数值也是醉了，哈哈哈哈哈哈哈
                c.a *=ColorLerp(c.rgb,_FilterfColor.rgb)*_F*100000*100000*100000*100000*100000*pow(10000,22); 
               
                return c; 
            } 


        ENDCG 
        } 
    } 
    FallBack "Diffuse" 
 
}
