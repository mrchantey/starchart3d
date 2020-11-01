using UnityEngine;
using Ahoy.Compute;
using System.Linq;
namespace Starchart3D
{

	public class StarComputeRenderer : ComputeRenderer<StarShaderData>
	{

		protected override int numVerts { get { return numPositions * 4; } }
		protected override int numThreads { get { return numPositions; } }

		ComputeBuffer stars;

		protected override int[] GetIndices()
		{
			return GenerateQuadIndices(numPositions);
		}

		public override void Invoke()
		{
			base.Invoke();

			stars = new ComputeBuffer(shaderData.stars.Length, StarInfoShader.stride);

			var infos = shaderData.stars.Select(s => new StarInfoShader(s)).ToArray();
			stars.SetData(infos);
			computeInstance.SetBuffer("stars", stars);
			materialInstance.SetBuffer("stars", stars);
		}


		protected override void Cleanup()
		{
			base.Cleanup();
			if (stars != null)
				stars.Dispose();
		}


	}
}