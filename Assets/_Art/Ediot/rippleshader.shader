Shader "Unlit/rippleshader"
{
    Properties
    {
      
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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


            sampler2D _PrevRT;//上一帧
            sampler2D _CurrentRT;//当前帧
            float4 _CurrentRT_Texturesize;//贴图大小信息
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
       
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {//最小偏移单位
               float3 e =float3(_CurrentRT_Texturesize.xy,0);  
               float2 uv=i.uv;
               //获取位置
               float p10 = tex2D(_CurrentRT,uv - e.zy).x;//下
               float p01 = tex2D(_CurrentRT,uv - e.xz).x;//左
               float p21 = tex2D(_CurrentRT,uv + e.xz).x;//右
               float p12 = tex2D(_CurrentRT,uv + e.zy).x;//上
               //上一帧中心
               float p11 = tex2D(_PrevRT,uv).x;
               float d = (p10 + p01 + p21 + p12)/2 - p11 ;
               d *= 0.99;
                return d;
            }
            ENDCG
        }
    }
}
