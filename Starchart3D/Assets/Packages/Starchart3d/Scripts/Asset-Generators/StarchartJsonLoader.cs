


using System;
using System.Linq;
using UnityEngine;
using Ahoy;
using Ahoy.Compute;

namespace Starchart3D
{

	[CreateAssetMenu(fileName = "StarchartJsonLoader", menuName = "Starchart3D/StarchartJsonLoader", order = 0)]
	public class StarchartJsonLoader : InvocableSO
	{

		public TextAsset starsAsset;
		public TextAsset constellationsAsset;

		public Vector3Data starsData;
		public Vector3Data constellationsData;

		public override void Invoke()
		{
			var stars = JsonArrayUtility.ArrayFromJson<StarInfo>(starsAsset.text);
			var constellations = JsonArrayUtility.ArrayFromJson<ConstellationInfo>(constellationsAsset.text);

			starsData.data = stars.Select(s => s.position).ToArray();
			constellationsData.data = constellations.SelectMany(c => c.stars.Select(s => s.position)).ToArray();
		}

	}
}