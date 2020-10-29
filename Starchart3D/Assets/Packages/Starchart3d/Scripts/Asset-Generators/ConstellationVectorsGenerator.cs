using UnityEngine;
using System.Linq;
using Ahoy;
using Ahoy.Compute;

namespace Starchart3D
{



	[CreateAssetMenu(menuName = "Starchart3D/Asset Generators/Constellation Vectors")]
	public class ConstellationVectorsGenerator : InvocableSO
	{

		public ConstellationDatabaseLoader database;
		public Vector3Data vector3Data;

		public override void Invoke()
		{
			vector3Data.data = database
					.constellations.SelectMany(ci => ci.stars.Select(s => s.position))
					.ToArray();
		}

	}

}