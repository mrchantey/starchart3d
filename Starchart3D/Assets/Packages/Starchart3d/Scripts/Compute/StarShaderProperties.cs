using UnityEngine;

using Ahoy;
using Ahoy.Shaders;

namespace Starchart3D
{

	public abstract class StarchartShaderProperties : DefaultShaderProperties
	{

		[Range(0, 0.1f)]
		public float glow = 0.01f;
		// public FloatVariable j2000Offset;


		public override void Apply(ComputeShader shader, int kernelIndex)
		{
			base.Apply(shader, kernelIndex);
			shader.SetFloat("_Glow", glow);
		}

		public override void Apply(Material shader)
		{
			base.Apply(shader);
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