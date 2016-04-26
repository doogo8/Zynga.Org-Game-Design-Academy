// Upgrade NOTE: replaced 'PositionFog()' with multiply of UNITY_MATRIX_MVP by position
// Upgrade NOTE: replaced 'V2F_POS_FOG' with 'float4 pos : SV_POSITION'

Shader "Custom/Velvet" { 
     Properties { 
          _Color ("Main Color", Color) = (1,1,1,0.5) 
          _MainTex ("Base (RGB) Rim-Light Ramp (A)", 2D) = "white" {} 
     } 
     SubShader { 
          //For Velvet look, Make Self-Illumination Depend on Facig Ration 
          Pass { 
               Tags {"LightMode" = "Always" /* Upgrade NOTE: changed from PixelOrNone to Always */} 
               Color [_PPLAmbient] 
          
               CGPROGRAM 
               // profiles arbfp1 
               // vertex vert 

               #include "UnityCG.cginc" 

               sampler2D _MainTex : register(s0); 

               struct v2f { 
                    float4 pos : SV_POSITION; 
                    float2  uv : TEXCOORD0; 
                    float2  uv1 : TEXCOORD1; 
               }; 

               v2f vert (appdata_base v) 
               { 
                    v2f o; 
                    o.pos = mul (UNITY_MATRIX_MVP, v.vertex); 
                    o.uv = TRANSFORM_UV(0); 
             
                    float3 viewDir = normalize(ObjSpaceViewDir(v.vertex)); 
                
                    o.uv1.x = dot(viewDir,v.normal); 
                    o.uv1.y = 0.5; 
                
                    return o; 
               } 
          
               ENDCG 
          
               SetTexture [_MainTex] { 
                    constantColor [_Color] 
                    combine constant * texture 
               } 
               SetTexture [_MainTex] { 
                    constantColor (0,0,0,1) 
                    combine previous lerp(texture) constant 
               } 
          
          } 
       
          UsePass " Diffuse/PPL" 
     } 
    
     FallBack "Normal-Diffuse", 1 
}