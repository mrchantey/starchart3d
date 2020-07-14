using UnityEngine;
using System;
namespace Starchart3D
{


	//http://www.zafzaf.it/coordinate/chapter7.htm
	[Serializable]
	public struct HorizontalCoords
	{
		public double altitude;
		public double azimuth;
		public double radius;



		public HorizontalCoords(double altitude, double azimuth, double radius = 1)
		{
			this.altitude = altitude;
			this.azimuth = azimuth;
			this.radius = radius;
		}

		public HorizontalCoords(Quaternion rotation)
		{
			var euler = rotation.eulerAngles;
			this.altitude = -StarMath.DegZero360To90(euler.x);
			this.azimuth = euler.y;
			this.radius = 1;
			// Debug.Log($"CoordinatesUI - e: {euler.y}\talt: {altitude}");
		}

		public Vector3 ToVector3()
		{
			var azTheta = azimuth * StarMath.deg2rad;
			var altTheta = altitude * StarMath.deg2rad;
			return new Vector3(
				(float)(Math.Sin(azTheta) * Math.Cos(altTheta)),
				(float)Math.Sin(altTheta),
				(float)(Math.Cos(azTheta) * Math.Cos(altTheta))
			) * (float)radius;
		}


		// public EquatorialCoords ToEquatorial(GeographicCoords geographicCoords, double localSiderealTime)
		// {
		// 	double x_hor = StarMath.Cos_d(azimuth) * StarMath.Cos_d(altitude);
		// 	double y_hor = StarMath.Sin_d(azimuth) * StarMath.Cos_d(altitude);
		// 	double z_hor = StarMath.Sin_d(altitude);

		// 	double x_sid = x_hor * StarMath.Sin_d(geographicCoords.latitude)
		// }

		// {
		// 	//ra = az
		// 	//dec = alt

		// 	// double ha = (localSiderealTime  - azimuth) * StarMath.hours2deg;
		// 	double ha = localSiderealTime * StarMath.hours2deg - azimuth + 90;
		// 	// double ha+ = localSiderealTime * StarMath.hours2deg - azimuth;

		// 	double x_sid = StarMath.Cos_d(ha) * StarMath.Cos_d(altitude);
		// 	double y_sid = StarMath.Sin_d(ha) * StarMath.Cos_d(altitude);
		// 	double z_sid = StarMath.Sin_d(altitude);

		// 	double x_hor = x_sid * StarMath.Sin_d(geographicCoords.latitude) - z_sid * StarMath.Cos_d(geographicCoords.latitude);
		// 	double y_hor = y_sid;
		// 	double z_hor = x_sid * StarMath.Cos_d(geographicCoords.latitude) + z_sid * StarMath.Sin_d(geographicCoords.latitude);

		// 	// double rightAscention = (StarMath.Atan2_d(y_hor, x_hor) + 180);
		// 	// double rightAscention = (StarMath.Atan2_d(y_hor, x_hor) + 180) * StarMath.deg2hours;
		// 	double rightAscention = (StarMath.Atan2_d(y_hor, x_hor) + 270) * StarMath.deg2hours;
		// 	double declination = StarMath.Atan2_d(z_hor, Math.Sqrt(x_hor * x_hor + y_hor * y_hor));

		// 	// Debug.Log($"Coordinates - ra: {rightAscention}\tra2: {ra2}");
		// 	// rightAscention = Ahoy.Math.Wrap((float)rightAscention,24);
		// 	rightAscention = Ahoy.Math.Map((float)rightAscention, -12, 12, 0, 24);
		// 	rightAscention %= 24;

		// 	return new EquatorialCoords(rightAscention, -declination);
		// 	// return new EquatorialCoords(rightAscention, declination);
		// }

		// public EquatorialCoords ToEquatorial(GeographicCoords geographicCoords, double localSiderealTime)
		// {

		// 	double declination = StarMath.Asin_d(StarMath.Sin_d(altitude) * StarMath.Sin_d(geographicCoords.latitude) + StarMath.Cos_d(altitude) * StarMath.Cos_d(geographicCoords.latitude) * StarMath.Cos_d(azimuth));
		// 	double ha = StarMath.Acos_d((StarMath.Sin_d(altitude) - StarMath.Sin_d(geographicCoords.latitude) * StarMath.Sin_d(declination)) / (StarMath.Cos_d(geographicCoords.latitude) * StarMath.Cos_d(declination)));
		// 	// if (StarMath.Sin_d(azimuth) > 0) ha = 360 - ha;
		// 	double rightAscention = localSiderealTime - ha;
		// 	// double rightAscention = localSiderealTime - (ha * StarMath.deg2hours);
		// 	// if (rightAscention < 0) rightAscention += 360;
		// 	// double rightAscention = localSiderealTime - ha * 24;
		// 	declination *= 3600;
		// 	return new EquatorialCoords(rightAscention, declination, radius);
		// }

		public override string ToString()
		{
			return $"az: {azimuth}\talt: {altitude}";
		}
	}
}