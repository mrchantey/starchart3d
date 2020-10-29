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


	[Serializable]
	public struct EclipticCoords
	{
		public double radius;
		[Range(-90, 90)]
		public double latitude;
		[Range(-180, 180)]
		public double longitude;


		public static EclipticCoords FromQuaternionUntested(Quaternion rotation, double radius = 1)
		{
			var euler = rotation.eulerAngles;
			var ecl = new EclipticCoords(0, 0);
			ecl.latitude = euler.x;
			ecl.longitude = euler.y;
			ecl.radius = radius;
			return ecl;
		}


		public EclipticCoords(double latitude, double longitude, double radius = 1)
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

		public EquatorialCoords ToEquatorial(double obl_ecl)
		{
			return this
			.ToCartesian()
			.EclipticToEquatorialCartesian(obl_ecl)
			.ToEquatorialSpherical();
		}

		public EclipticCoords ToCorrectedPrecession(double day)
		{
			return new EclipticCoords(
				this.latitude,
				this.longitude + StarMath.PrecessionEclipticLongitudeOffset(day),
				this.radius
			);
		}


		public override string ToString()
		{
			return $"latitude: {latitude}\t longitude: {longitude}";
		}
	}
}