Shader "Custom/Texture" {
Properties {
	_MainTex ("Main Texture", 2D) = "white" {}
	_SecondTex ("Second Texture", 2D) = "white" {}
	_TextureMix("Texture mix", Range(0.0, 1.0)) = 0.5
}

SubShader {
	Tags {"Queue"="Transparent"}
	ZWrite Off
	Blend SrcAlpha OneMinusSrcAlpha
	
Pass {
CGPROGRAM
#pragma exclude_renderers ps3 xbox360
#pragma fragmentoption ARB_precision_hint_fastest
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

uniform sampler2D _MainTex;
uniform float4 _MainTex_ST;
uniform sampler2D _SecondTex;
uniform float4 _SecondTex_ST;
uniform fixed _TextureMix;

struct vertexInput {
	float4 vertex : POSITION;	// position in object coordinates
	float4 texcoord : TEXCOORD0;	// uv
};

struct fragmentInput {
	float4 pos : SV_POSITION;
	half2 uv : TEXCOORD0;
	half2 uv2 : TEXCOORD1;
};

fragmentInput vert(vertexInput i) {
	fragmentInput o;
	
	// vert distortion
	i.vertex.x += _SinTime.x * i.vertex.y; // built into unity
	
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.uv = TRANSFORM_TEX(i.texCoord, _MainTex);
	o.uv2 = TRANSFORM_TEX(i.texCoord, _SecondTex);
	return o;
}

half4 frag(fragmentInput i) : COLOR {
	fixed4 mainTexColor = tex2D(_MainTex, i.uv);
	fixed4 mainTexColor2 = tex2D(_MainTex, i.uv2);	
	return lerp(mainTexColor, secondTexColor, _TextureMix);
}

ENDCG
} // end Pass
} // end SubShader

FallBack "Diffuse"
}

