using UnityEngine;
using Starchart3D;

namespace Starchart3D
{

	public class EquatorialTracker : MonoBehaviour
	{

		public EquatorialCoords coords;

		[Range(-24, 24)]
		public float raPerSecond = 0;
		[Range(-90, 90)]
		public float decPerSecond = 0;

	}
}