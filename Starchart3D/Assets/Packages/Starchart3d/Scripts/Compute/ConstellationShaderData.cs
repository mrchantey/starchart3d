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

		public ConstellationInfo[] constellations;
		public StarInfo[] stars;

		void OnEnable()
		{
			if (constellationsJson == null) return;
			constellations = JsonArrayUtility.ArrayFromJson<ConstellationInfo>(constellationsJson.text);
			stars = constellations.SelectMany(c => c.stars).ToArray();
		}

		public override int numPositions { get { return stars.Length; } }
		public override Vector3[] GetPositions() { return stars.Select(s => s.position).ToArray(); }

	}
}