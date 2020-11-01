using UnityEngine;

using Ahoy;
using Ahoy.Shaders;

namespace Starchart3D
{
	[CreateAssetMenu(fileName = "ConstellationShaderProperties", menuName = "Starchart3D/ConstellationShaderProperties", order = 0)]
	public class ConstellationShaderProperties : StarchartShaderProperties
	{
		// [Range(-4, 4f)]
		// public float glowX = 0.5f;
		// [Range(-4, 4f)]
		// public float glowY = 0.5f;

		public override void Apply(ComputeShader shader, int kernelIndex)
		{
			base.Apply(shader, kernelIndex);
			// shader.SetFloat("_GlowX", glow);
			// shader.SetFloat("_GlowY", glow);
		}
		public override void Apply(Material shader)
		{
			base.Apply(shader);
			// shader.SetFloat("_GlowX", glowX);
			// shader.SetFloat("_GlowY", glowY);
		}
	}
}