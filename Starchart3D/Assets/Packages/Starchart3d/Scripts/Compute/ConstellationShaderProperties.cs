using UnityEngine;

using Ahoy;
using Ahoy.Shaders;

namespace Starchart3D
{
	[CreateAssetMenu(fileName = "ConstellationShaderProperties", menuName = "Starchart3D/ConstellationShaderProperties", order = 0)]
	public class ConstellationShaderProperties : StarchartShaderProperties
	{

		public override void Apply(ComputeShader shader, int kernelIndex)
		{
			base.Apply(shader, kernelIndex);
		}
		public override void Apply(Material shader)
		{
			base.Apply(shader);
		}
	}
}