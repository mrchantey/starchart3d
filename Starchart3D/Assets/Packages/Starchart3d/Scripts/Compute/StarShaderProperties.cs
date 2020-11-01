using UnityEngine;

using Ahoy;
using Ahoy.Shaders;

namespace Starchart3D
{

	public abstract class StarchartShaderProperties : ShaderPropertiesBase
	{
		public bool screenSpace;
		[Range(0, 10)]
		public float size = 1.3f;
		// public float j2000Offset;

		[Range(0, 1)]
		public float scaleRange = 0.2f;
		[Range(0, 1000)]
		public float scaleMax = 5;

		[Range(0, 0.1f)]
		public float glow = 0.01f;
		// public FloatVariable j2000Offset;


		public override void Apply(ComputeShader shader, int kernelIndex)
		{
			shader.SetBool("_ScreenSpace", screenSpace);
			shader.SetFloat("_Size", size);
			// shader.SetFloat("_J2000Offset", j2000Offset);

			shader.SetFloat("_ScaleRange", scaleRange);
			shader.SetFloat("_ScaleMax", scaleMax);

			shader.SetFloat("_Glow", glow);


		}

		public override void Apply(Material shader)
		{
			shader.SetInt("_ScreenSpace", screenSpace ? 1 : 0);
			shader.SetFloat("_Size", size);
			// shader.SetFloat("_J2000Offset", j2000Offset);

			shader.SetFloat("_ScaleRange", scaleRange);
			shader.SetFloat("_ScaleMax", scaleMax);
			shader.SetFloat("_Glow", glow);


		}


	}


	[CreateAssetMenu(fileName = "StarShaderProperties", menuName = "Starchart3D/StarShaderProperties", order = 0)]
	public class StarShaderProperties : StarchartShaderProperties
	{
		[Range(0, 10)]
		public float magDelta = 2.5f;
		[Range(0, 1)]
		public float magMax = 0.14f;
		[Range(0, 5)]
		public float twinkleFrequency = 3f;
		[Range(0, 1)]
		public float twinkleAmplitude = 0.1f;


		public override void Apply(ComputeShader shader, int kernelIndex)
		{
			base.Apply(shader, kernelIndex);

			shader.SetFloat("_MagDelta", magDelta);
			shader.SetFloat("_MagMax", magMax);

			shader.SetFloat("_TwinkleFrequency", twinkleFrequency);
			shader.SetFloat("_TwinkleAmplitude", twinkleAmplitude);


		}

		public override void Apply(Material shader)
		{
			base.Apply(shader);
			shader.SetFloat("_MagDelta", magDelta);
			shader.SetFloat("_MagMax", magMax);

			shader.SetFloat("_TwinkleFrequency", twinkleFrequency);
			shader.SetFloat("_TwinkleAmplitude", twinkleAmplitude);
		}

	}
}