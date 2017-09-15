Shader "Hidden/CameraBlendInOut" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_blendProgress("Black & White blend", Range(0, 1)) = 0
	}
		SubShader{
		Pass{
		CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag

#include "UnityCG.cginc"

	uniform sampler2D _MainTex;
	uniform float _blendProgress;

	float4 frag(v2f_img i) : COLOR {

		float4 c = tex2D(_MainTex, i.uv);

		float4 result = c;
		result = clamp(result - _blendProgress, 0, 1);
		return result;
	}
		ENDCG
	}
	}
}