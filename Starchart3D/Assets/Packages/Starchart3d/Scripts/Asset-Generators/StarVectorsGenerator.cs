using UnityEngine;
using System.Linq;
using Ahoy;
using Ahoy.Compute;

namespace Starchart3D
{



	[CreateAssetMenu(menuName = "Starchart3D/Asset Generators/Star Vectors")]
	public class StarVectorsGenerator : InvocableSO
	{

		public StarDatabaseLoader database;
		public Vector3Data vector3Data;
		public bool skipSun;

		public override void Invoke()
		{
			vector3Data.data = database.stars.Select(s => s.position).ToArray();
			if (skipSun)
				vector3Data.data = vector3Data.data.Skip(1).ToArray();
		}

	}

}