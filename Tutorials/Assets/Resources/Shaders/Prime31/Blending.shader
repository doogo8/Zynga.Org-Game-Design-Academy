Shader "Custom/Prime31Blending" {
	Properties {
		_Color ("Tint Color", _Color) = (1.0, 1.0, 1.0, 1.0)
	}
	SubShader {
		Tags { "Queue" = "Transparent" }
		ZWrite Off // whether to write to depth buffer
		
		// Blend modes equation: SrcFactor * fragment_output + DstFactor * pixel_color_in_framebuffer;
		// Blend {code for SrcFactor} {code for DstFactor}
		
		Blend SrcAlpha OneMinusSrcAlpha		// alpha blending
		//Blend One OneMinusSrcAlpha		// premultiplied alpha blending
		//Blend One One						// additive
		// Blend SrcAlpha One				// additive blending
		// Blend OneMinusDstColor One		// soft additive
		// Blend DstColor Zero				// multiplicative
		// Blend DstColor SrcColor			// 2x multiplicative
		// Blend Zero SrcAlpha				// multiplicative blending for attenutation by the fragment's alpha
		
		// BlendOp Min
		// BlendOp Max
		
		Pass {
CGPROGRAM
#pragma exclude_renderers ps3 xbox360 flash
#pragma fragmentoption ARB_precision_hint_fastest
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

uniform fixed4 _Color;

struct vertexInput {
	float4 vertex : POSITION; // position (in object coordinates; ie local or model coordinates)
	float4 tangent : TANGENT; // vector orthogonal to surface normal
	float3 normal : NORMAL;		// surface normal (in object coordinates; usu normalized)
	float4 texcoord : TEXCOORD0;	// 0th set of texture coordinates (aka UV between 0 and 1)
	float4 texcoord1 : TEXCOORD1;	// 1st set of texture coordinates
	float4 color : COLOR; // vertex color
};

struct fragmentInput {
	float4 pos : SV_POSITION;
	float4 color : COLOR0;
};

fragmentInput vert(vertexInput i) {
	fragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.color = _Color;
	
	// debug: uncomment to debug then return i.color directly in fragment shader
	//o.color = i.texcoord;
	//o.color = i.texcoord1;
	//o.color = i.vertex;
	//o.color = i.vertex + float4(0.5, 0.5, 0.5, 0.0);  // we add 0.5's to offset if the model vets go from -0.5 to 0.5
	//o.color = i.tangent;
	//o.color = float4(i.normal * 0.5 + 0.5, 1.0); // scale and bias the normal to get it in the range of 0 to 1
	//o.color = i.color;  // vertex colors
	
	return o;
}

half4 frag(fragmentInput i):Color {
	return i.color;
}

ENDCG
		}
	}
	
	FallBack "Diffuse"
}