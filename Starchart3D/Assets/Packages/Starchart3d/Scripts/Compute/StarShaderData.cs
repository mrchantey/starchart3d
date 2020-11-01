using UnityEngine;

using Ahoy;
using Ahoy.Compute;
using System.Linq;

namespace Starchart3D
{
	[CreateAssetMenu(fileName = "Star Shader Data", menuName = "Starchart3D/Star Shader Data", order = 0)]
	public class StarShaderData : PositionData
	{

		public TextAsset starsJson;
		public bool skipSol = true;

		ComputeBuffer starsCompute;
		StarInfo[] stars;

		public override void ApplyToShaders(ComputeInstance computeInstance, MaterialInstance materialInstance)
		{
			base.ApplyToShaders(computeInstance, materialInstance);
			computeInstance.SetBuffer("stars", starsCompute);
			materialInstance.SetBuffer("stars", starsCompute);
		}

		protected override Vector3[] GetPositions()
		{
			if (starsJson == null) return null;
			stars = JsonArrayUtility.ArrayFromJson<StarInfo>(starsJson.text);
			if (skipSol)
				stars = stars.Skip(1).ToArray();

			starsCompute = new ComputeBuffer(stars.Length, StarInfoShader.stride);
			var infos = stars.Select(s => new StarInfoShader(s)).ToArray();
			starsCompute.SetData(infos);
			return stars.Select(s => s.position).ToArray();
		}

		protected override void Cleanup()
		{
			base.Cleanup();
			if (starsCompute != null)
				starsCompute.Dispose();
		}


	}
}