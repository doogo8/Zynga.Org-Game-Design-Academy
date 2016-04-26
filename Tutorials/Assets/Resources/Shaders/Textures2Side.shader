Shader "Custom/Texture" {
Properties {
	_MainTex ("Main Texture", 2D) = "white" {}
}

SubShader {
	Tags {"Queue"="Transparent"}
	ZWrite Off
	Blend SrcAlpha OneMinusSrcAlpha
	
Pass {
	Cull Front
CGPROGRAM
#pragma exclude_renderers ps3 xbox360
#pragma fragmentoption ARB_precision_hint_fastest
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

uniform sampler2D _MainTex;
uniform float4 _MainTex_ST;

struct vertexInput {
	float4 vertex : POSITION;	// position in object coordinates
	float4 texcoord : TEXCOORD0;	// uv
};

struct fragmentInput {
	float4 pos : SV_POSITION;
	half2 uv : TEXCOORD0;
};

fragmentInput vert(vertexInput i) {
	fragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.uv = TRANSFORM_TEX(i.texCoord, _MainTex);
	return o;
}

half4 frag(fragmentInput i) : COLOR {
	return tex2D(_MainTex, i.uv);
}

ENDCG
} // end Pass
} // end SubShader


Pass {
	Cull Back
CGPROGRAM
#pragma exclude_renderers ps3 xbox360
#pragma fragmentoption ARB_precision_hint_fastest
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

uniform sampler2D _MainTex;
uniform float4 _MainTex_ST;

struct vertexInput {
	float4 vertex : POSITION;	// position in object coordinates
	float4 texcoord : TEXCOORD0;	// uv
};

struct fragmentInput {
	float4 pos : SV_POSITION;
	half2 uv : TEXCOORD0;
};

fragmentInput vert(vertexInput i) {
	fragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.uv = TRANSFORM_TEX(i.texCoord, _MainTex);
	return o;
}

half4 frag(fragmentInput i) : COLOR {
	return tex2D(_MainTex, i.uv);
}

ENDCG
} // end Pass
} // end SubShader


FallBack "Diffuse"
}

