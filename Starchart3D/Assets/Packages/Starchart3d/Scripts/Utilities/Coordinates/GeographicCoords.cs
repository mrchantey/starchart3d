using UnityEngine;
using System;
namespace Starchart3D
{
	[Serializable]
	public struct GeographicCoords
	{
		[Range(-90, 90)]
		public double latitude;
		[Range(-180, 180)]
		public double longitude;

		public GeographicCoords(double latitude, double longitude)
		{
			this.latitude = latitude;
			this.longitude = longitude;
		}
	}
}