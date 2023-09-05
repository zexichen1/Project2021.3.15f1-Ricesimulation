Shader "Unlit/NewUnlitShader"
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

            sampler2D _Sourcetex;
            float4 _Pos;

            struct v2f
            {
                float2 uv : TEXCOORD0;
                
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                
                 float2 uv = i.uv;
               // return length(uv-_Pos.xy)/_Pos.z + tex2D(_SourceTex,uv).x;//画点移动，非连续性
                 return max(_Pos.z - length(uv-_Pos.xy)/_Pos.z,0) + tex2D(_Sourcetex,uv).x;
                //return max (_Pos. z - length(uv-_Pos. xy)_Pos. z, 0)+ tex2D(_SourceTex, uv). x:

            }
            ENDCG
        }
    }
}
