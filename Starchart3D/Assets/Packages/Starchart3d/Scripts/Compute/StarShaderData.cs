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

		public StarInfo[] stars;
		public bool skipSol = true;

		void OnEnable()
		{
			if (starsJson == null) return;
			stars = JsonArrayUtility.ArrayFromJson<StarInfo>(starsJson.text);
			if (skipSol)
				stars = stars.Skip(1).ToArray();
		}

		public override int numPositions { get { return stars.Length; } }
		public override Vector3[] GetPositions() { return stars.Select(s => s.position).ToArray(); }

	}
}