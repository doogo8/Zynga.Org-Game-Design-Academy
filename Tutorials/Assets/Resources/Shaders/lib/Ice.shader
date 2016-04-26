Shader "Custom/Ice" {
	Properties {
		_Color ("Tint Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_MainTex ("Main Texture", 2D) = "white" {}
		_Cube ("Reflection Map", Cube) = "" {}
		_TextureMix ("Texture mix", Range(0.0, 1.0)) = 0.5
	}
	SubShader {
		Tags { "Queue" = "Transparent" }
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		
		Pass {
CGPROGRAM
#pragma exclude_renderers ps3 xbox360 flash
#pragma fragmentoption ARB_precision_hint_fastest
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

uniform fixed4 _Color;
uniform sampler2D _MainTex;
uniform float4 _MainTex_ST;
uniform samplerCUBE _Cube;
uniform float _TextureMix;

struct vertexInput {
	float4 vertex : POSITION; // position (in object coordinates)
	float3 normal : NORMAL;
	float4 texcoord : TEXCOORD0;	// 0th set of texture coordinates
};

struct fragmentInput {
	float4 pos : SV_POSITION;
	half2 uv : TEXCOORD0;
	float3 normalDir : TEXCOORD1;
	float3 viewDir : TEXCOORD2;
};

fragmentInput vert(vertexInput i) {
	fragmentInput o;
	o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
	o.uv = TRANSFORM_TEX(i.texcoord, _MainTex);
	
	float4x4 modelMatrix = _Object2World;
    float4x4 modelMatrixInverse = _World2Object; 
       // multiplication with unity_Scale.w is unnecessary 
       // because we normalize transformed vectors 

    o.viewDir = WorldSpaceViewDir(i.vertex);
    //(mul(modelMatrix, float4(i.vertex.xyz, 1)) 
    //   - float4(_WorldSpaceCameraPos.xyz, 1.0)).xyz;
    o.normalDir = normalize(
       mul(modelMatrixInverse, float4(i.normal, 0.0)).xyz);
		
	return o;
}

half4 frag(fragmentInput i):COLOR {
	// get contribution from reflection map	
	float3 reflectedDir = 
		reflect(i.viewDir, normalize(i.normalDir));

	return _Color * lerp(texCUBE(_Cube, reflectedDir),
		tex2D(_MainTex, i.uv),
		_TextureMix);
}

ENDCG
		}
	}
	
	FallBack "Diffuse"
}