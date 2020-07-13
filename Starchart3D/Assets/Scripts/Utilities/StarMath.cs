using System;
using UnityEngine;

namespace Starchart3D
{

	public static class StarMath
	{

		public static readonly double deg2rad = Math.PI / 180;
		public static readonly double rad2deg = 180 / Math.PI;
		public static readonly double rad2hours = 12 / Math.PI;
		public static readonly double hours2rad = Math.PI / 12;
		public static readonly double deg2hours = (float)1 / 15;
		public static readonly double hours2deg = 15;
		public static readonly double earthTiltDeg = 23.4393;
		public static double Sin_d(double v) { return Math.Sin(v * deg2rad); }
		public static double Cos_d(double v) { return Math.Cos(v * deg2rad); }
		public static double Tan_d(double v) { return Math.Tan(v * deg2rad); }
		public static double Asin_d(double v) { return Math.Asin(v * deg2rad); }
		public static double Acos_d(double v) { return Math.Acos(v * deg2rad); }
		public static double Atan_d(double v) { return Math.Atan(v * deg2rad); }
		public static double Atan2_d(double y, double x) { return Math.Atan2(y * deg2rad, x * deg2rad) * rad2deg; }


		public static double metersPerAU = 1.4959787e+11;
		public static double metersPerEarthRadii = 6378140.0;
		public static double earthRadiiPerAU = metersPerAU / metersPerEarthRadii;      // 23454.779920164812


		// public static double Wrap(double x, double minmax)
		// {
		// 	return x - Math.Floor(x / minmax) * minmax;
		// }
		public static double WrapDeg(double x)
		{
			return x - Math.Floor(x / 360.0) * 360.0;
		}
		public static double WrapHours(double x)
		{
			return x - Math.Floor(x / 24) * 24;
		}
		public static double Cbrt(double x)
		{
			if (x > 0.0)
				return Math.Exp(Math.Log(x) / 3.0);
			else if (x < 0.0)
				return -Cbrt(-x);
			else /* x == 0.0 */
				return 0.0;
		}

		public static double ObliquityOfEcliptic(double day)
		{
			return earthTiltDeg - 3.563E-7 * day;//very slowly decreasing
		}


		public static readonly int millisInDay = 1000 * 60 * 60 * 24;
		//I THINK THIS SHOULD BE 1999, and not add one when get days from y20000 millis
		public static readonly long y2000Millis = new DateTimeOffset(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)).ToUnixTimeMilliseconds();//I THINK THIS SHOULD BE 1999, and not add one when get days from y20000 millis
		public static double UTCDateTimeToY2KDay(DateTime date)
		{
			double utcMillis = new DateTimeOffset(date).ToUnixTimeMilliseconds();
			return 1 + (utcMillis - y2000Millis) / millisInDay;
			// return (utcMillis - y2000Millis) / millisInDay;
			// add 1 because point of origin is 31st december 1999
		}

		public static double LocalSiderealTime(Astrobodies bodies, GeographicCoords geographicCoords, double day)
		{
			double sunL = bodies.sun.orbitalElements.L;
			double gmst0 = StarMath.WrapDeg(sunL * StarMath.deg2hours + 12);
			double utcHour = (day % 1) * 24;
			// if (debug) Debug.Log($"Topocentric - day: {astrobodies.day.ToString("0.00")}\t utcHour: {utcHour.ToString("0.00")}");
			double lonHr = geographicCoords.longitude * StarMath.deg2hours;
			return gmst0 + utcHour + lonHr; //local siderial time
		}

		public static (double altitude, double azimuth) QuaternionToHorizontal(Quaternion rotation)
		{
			var euler = rotation.eulerAngles;
			var altitude = euler.x;
			if (altitude > 270) altitude -= 360;
			else if (altitude > 90) altitude -= 180;
			altitude = -altitude;
			var azimuth = euler.y;
			return (altitude, azimuth);
		}

		public static double DegZero360To90(double deg)
		{
			if (deg > 270) deg -= 360;
			else if (deg > 90) deg -= 180;
			return deg;
		}

	}
}
