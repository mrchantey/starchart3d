using UnityEngine;
using System;

namespace Starchart3D
{

	[Serializable]
	public struct CartesianCoords
	{
		public double x;
		public double y;
		public double z;
		public CartesianCoords(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static CartesianCoords operator +(CartesianCoords a, CartesianCoords b)
		{
			return new CartesianCoords(
				a.x + b.x,
				a.y + b.y,
				a.z + b.z
			);
		}
		public static CartesianCoords operator -(CartesianCoords a, CartesianCoords b)
		{
			return new CartesianCoords(
				a.x - b.x,
				a.y - b.y,
				a.z - b.z
			);
		}

		public Vector3 ToVector3()
		{
			return new Vector3((float)x, (float)y, (float)z);
		}

		public Vector3 EquatorialCartToUnityVector3()
		{
			return new Vector3((float)-y, (float)z, (float)x);
		}

		public EquatorialCoords ToEquatorialSpherical()
		{
			return new EquatorialCoords(
				Math.Atan2(y, x) * StarMath.rad2hours,//HOURS
				Math.Atan2(z, Math.Sqrt(x * x + y * y)) * StarMath.rad2deg,
					Math.Sqrt(x * x + y * y + z * z));
		}

		public EclipticCoords ToEclipticSpherical()
		{
			var ecl = new EclipticCoords(
					Math.Atan2(z, Math.Sqrt(x * x + y * y)) * StarMath.rad2deg,
					Math.Atan2(y, x) * StarMath.rad2deg,
				Math.Sqrt(x * x + y * y + z * z));
			ecl.longitude = StarMath.WrapDeg(ecl.longitude);//nesecary?
			return ecl;
		}

		public static CartesianCoords EclipticToEquatorialCartesian(CartesianCoords ecliptic, double obl_ecl)
		{
			return new CartesianCoords(
			ecliptic.x,
		 ecliptic.y * StarMath.Cos_d(obl_ecl) - ecliptic.z * StarMath.Sin_d(obl_ecl),
		 ecliptic.y * StarMath.Sin_d(obl_ecl) + ecliptic.z * StarMath.Cos_d(obl_ecl)
			);
		}

		public static CartesianCoords EquatorialToEclipticCartesian(CartesianCoords equatorial, double obl_ecl)
		{
			return new CartesianCoords(
			equatorial.x,
				y: equatorial.y * StarMath.Cos_d(-obl_ecl) - equatorial.z * StarMath.Sin_d(-obl_ecl),
				z: equatorial.y * StarMath.Sin_d(-obl_ecl) + equatorial.z * StarMath.Cos_d(-obl_ecl));
		}

		public override string ToString()
		{
			return $"{x} , {y} , {z}";
		}
	}

}