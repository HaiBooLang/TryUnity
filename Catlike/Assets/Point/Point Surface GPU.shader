Shader"Graph/Point Surface GPU" {

	Properties {
		_Smoothness ("Smoothness", Range(0,1)) = 0.5
	}

	SubShader {
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows addshadow
		#pragma instancing_options assumeuniformscaling procedural:ConfigureProcedural
		#pragma editor_sync_compilation
		#pragma target 4.5
		#include "PointGPU.hlsl"

		struct Input
		{
			float3 worldPos;
		};
		
		float _Smoothness;
		void ConfigureSurface(Input input, inout SurfaceOutputStandard surface)
		{
			surface.Albedo = saturate(input.worldPos * 0.5 + 0.5);
			surface.Smoothness = _Smoothness;
		}

void ShaderGraphFunction_float(float3 In, out float3 Out)
{
    Out = In;
}

void ShaderGraphFunction_half(half3 In, out half3 Out)
{
    Out = In;
}
		ENDCG
	}

	FallBack"Diffuse"
}