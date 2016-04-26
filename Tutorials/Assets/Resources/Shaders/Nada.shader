Shader "Custom/Nada" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
}

SubShader {
	Tags {"Queue"="Transparent"}
	Blend SrcAlpha OneMinusSrcAlpha
	
Pass {
CGPROGRAM
#pragma exclude_renderers ps3 xbox360
#pragma fragmentoption ARB_precision_hint_fastest
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

uniform fixed4 _Color;

struct vertexInput {
	float4 vertex : POSITION
};

struct fragmentInput {
	float4 pos : SV_POSITION;
	float4 color : COLOR0;
};

fragmentInput vert(vertexInput i) {
	fragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.color = _Color;
}

half4 frag(fragmentInput i) : COLOR {
	return i.color;
}

ENDCG
} // end Pass
} // end SubShader

FallBack "Diffuse"
}

