using UnityEngine;

namespace Starchart3D
{

	[CreateAssetMenu(fileName = "GeographicCoordsSO", menuName = "Starchart3D/GeographicCoordsSO", order = 0)]
	public class GeographicCoordsSO : ScriptableObject
	{
		public GeographicCoords value;
	}
}