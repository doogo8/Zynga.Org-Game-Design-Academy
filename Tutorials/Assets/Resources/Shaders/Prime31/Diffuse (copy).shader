Shader "Custom/Prime31DiffuseBroken" {
	Properties {
		_MainTex ("Main Texture", 2D) = "white" {}
		_Color("Diffuse Material Color", Color) = (1.0, 1.0, 1.0, 1.0)
//		_LightColor0("Light Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}
	SubShader {
		Tags { "Queue" = "Geometry" }
		
		Pass {
CGPROGRAM
#pragma exclude_renderers ps3 xbox360 flash
#pragma fragmentoption ARB_precision_hint_fastest
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"
#include "Util.cginc"

uniform sampler2D _MainTex;
uniform float4 _MainTex_ST;
uniform fixed4 _Color;
uniform fixed4 _LightColor0;

struct vertexInput {
	float4 vertex : POSITION; // position (in object coordinates)
	float3 normal : NORMAL;
	float4 texcoord : TEXCOORD0;	// 0th set of texture coordinates
};

struct fragmentInput {
	float4 pos : SV_POSITION;
	float4 color : COLOR0;
	half2 uv : TEXCOORD0;
};

fragmentInput vert(vertexInput i) {
	fragmentInput o;
//	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
//	o.uv = TRANSFORM_TEX(i.texcoord, _MainTex);
//	
//	float3 normalDirection = //NORMAL_TO_WORLD(i.normal);
//		normalize(mul(float4(i.normal, 1.0), _World2Object).xyz);
//
//	// a single directional light
//	float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
//	
//	float3 diffuse = _LightColor0.xyz * _Color.rgb * max(0.0, dot(normalDirection, lightDirection));
//	
//	o.color = half4(diffuse, 1.0);
	
	return o;
}

half4 frag(fragmentInput i):COLOR {
	return tex2D(_MainTex, i.uv) * i.color;
}

ENDCG
		} // end pass
	} // end subshader
	
	FallBack "Diffuse"
}