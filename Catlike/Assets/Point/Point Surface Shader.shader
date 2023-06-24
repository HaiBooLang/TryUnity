Shader"Graph/Point Surface GPU" {

	Properties {
		_Smoothness ("Smoothness", Range(0,1)) = 0.5
	}

	SubShader {
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows addshadow
		#pragma target 4.5
		#pragma instancing_options procedural:ConfigureProcedural

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

		#if defined(UNITY_PROCEDURAL_INSTANCING_ENABLED)
			StructuredBuffer<float3> _Positions;
		#endif
		
		void ConfigureProcedural () {
			#if defined(UNITY_PROCEDURAL_INSTANCING_ENABLED)
				float3 position = _Positions[unity_InstanceID];
			#endif
		}
		ENDCG
	}

	FallBack"Diffuse"
}