using UnityEngine;
using System;
namespace Starchart3D
{

	public enum EcliptEquHoriz
	{
		Ecliptic,
		Equatorial,
		Horizontal
	}

	public enum CelestialCoordinatesType
	{
		Equatorial,
		Horizontal
	}

	[Serializable]
	public struct EclipticCoords
	{
		public double radius;
		[Range(-90, 90)]
		public double latitude;
		[Range(-180, 180)]
		public double longitude;
		public EclipticCoords(double latitude, double longitude, double radius)
		{
			this.latitude = latitude;
			this.longitude = longitude;
			this.radius = radius;
		}


		public CartesianCoords ToCartesian()
		{
			return new CartesianCoords(
				radius * StarMath.Cos_d(longitude) * StarMath.Cos_d(latitude),
				radius * StarMath.Sin_d(longitude) * StarMath.Cos_d(latitude),
				radius * StarMath.Sin_d(latitude)
			);
		}


		public override string ToString()
		{
			return $"latitude: {latitude}\t longitude: {longitude}";
		}
	}
}