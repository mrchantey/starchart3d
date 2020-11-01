using UnityEngine;

using Ahoy;
using Ahoy.Compute;
using System.Linq;

namespace Starchart3D
{
	[CreateAssetMenu(fileName = "Constellation Shader Data", menuName = "Starchart3D/Constellation Shader Data", order = 0)]
	public class ConstellationShaderData : PositionData
	{
		public TextAsset constellationsJson;
		ConstellationInfo[] constellations;

		ComputeBuffer starIds;

		protected override Vector3[] GetPositions()
		{
			if (constellationsJson == null) return null;
			constellations = JsonArrayUtility.ArrayFromJson<ConstellationInfo>(constellationsJson.text);
			var ids = constellations.SelectMany(c => c.stars).Select(s => s.hygId).ToArray();
			var positions = constellations.SelectMany(c => c.stars).Select(s => s.position).ToArray();
			starIds = new ComputeBuffer(ids.Length, sizeof(uint));
			starIds.SetData(ids);
			return positions.ToArray();
		}

		protected override void Cleanup()
		{
			base.Cleanup();
			if (starIds != null)
				starIds.Dispose();
		}

	}
}