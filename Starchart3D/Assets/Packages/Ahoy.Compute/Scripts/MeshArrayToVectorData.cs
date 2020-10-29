using UnityEngine;
using System.Linq;

namespace Ahoy.Compute
{

	[CreateAssetMenu(fileName = "MeshArrayToVectorData", menuName = "Ahoy.Compute/MeshArrayToVectorData", order = 0)]
	public class MeshArrayToVectorData : InvocableSO
	{


		public Mesh[] meshes;
		public Vector3Data vector3Data;

		public override void Invoke()
		{
			vector3Data.data = meshes.SelectMany(m => m.vertices).ToArray();
		}

	}
}