Shader "Shaders/Prime31/JustColor" {
	Properties {
		_Color ("Tint Color", Color) = (1.0, 1.0, 1.0, 1.0)
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

uniform fixed4 _Color;

struct vertexInput {
	float4 vertex : POSITION; // position (in object coordinates)
};

struct fragmentInput {
	float4 pos : SV_POSITION;
	float4 color : COLOR0;
};

fragmentInput vert(vertexInput i) {
	fragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.color = _Color;
	return o;
}

half4 frag(fragmentInput i):Color {
	return i.color;
}

ENDCG
		}
	}
}