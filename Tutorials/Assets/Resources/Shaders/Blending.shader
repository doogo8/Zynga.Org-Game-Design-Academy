Shader "Custom/Blending" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
}

SubShader {
	Tags {"Queue"="Transparent"}
	ZWrite Off
	
// Blend modes equation:
//		SrcFactor * fragment_output + DstFactor * pixel_color_in_framebuffer;
//		(SrcFactor above could be fragment_output.a)
// Blend (code for SrcFactor) (code for DstFactor)	
	
//Blend SrcAlpha OneMinusSrcAlpha	// alpha blending
//Blend One OneMinusSrcAlpha		// premultiplied alpha blending
//Blend One One						// additive
//Blend SrcAlpha One				// additive blending
//Blend OneMinusDstColor One		// soft additive
//Blend DstColor Zero				// multiplicative
//Blend DstColor SrcColor			// 2x multiplicative
//Blend Zero SrcAlpha				// multiplicative blending for attenutation by fragment's alpha	
	
	
Pass {
CGPROGRAM
#pragma exclude_renderers ps3 xbox360
#pragma fragmentoption ARB_precision_hint_fastest
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

uniform fixed4 _Color;

struct vertexInput {
	float4 vertex : POSITION;	// position in object coordinates
	float4 tangent : TANGENT;	// orthogonal to surface normal
	float3 normal : NORMAL;		// surface normal in object coordinates
	float4 texcoord : TEXCOORD0;	// uv
	float4 texcoord1 : TEXCOORD1;	// uv
	float4 color : COLOR;			// vertex color
};

struct fragmentInput {
	float4 pos : SV_POSITION;
	float4 color : COLOR0;
};

fragmentInput vert(vertexInput i) {
	fragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.color = _Color;
	
	//o.color = i.texcoord;
	//o.color = i.texcoord1;
	//o.color = i.vertex;
	//o.color = i.vertex * float4(0.5, 0.5, 0.5, 0.0);
	//o.color = i.tangent;
	//o.color = float4(i.normal * 0.5 + 0.5, 1.0);
	//o.color = i.color();
}

half4 frag(fragmentInput i) : COLOR {
	return i.color;
}

ENDCG
} // end Pass
} // end SubShader

FallBack "Diffuse"
}

