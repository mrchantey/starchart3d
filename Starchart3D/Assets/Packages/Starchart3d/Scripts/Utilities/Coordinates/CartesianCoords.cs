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

		public double Length()
		{
			return Math.Sqrt(x * x + y * y + z * z);
		}

		public Vector3 ToVector3()
		{
			return new Vector3((float)x, (float)y, (float)z);
		}
		/*
		my system
		RA 	Dec Direction
		0 	0 	Fwd
		0	90	Up
		6	0	Right

		Cartesian X Position - Vernal Equinox
		Cartesian Y Position - R.A. 6 hours; dec 0 degrees
		Cartesian Z Position - North Celestial Pole

		stars, x = fwd, y = left, z = up

		current star settings
		rotation: x-90,y-180,z90
		scale: y-1


		x = fwd, y = left, z = up

		TODO USE COORDINATE CONVERSION INFO INSTEAD
		*/
		public Vector3 EquatorialCartToUnityVector3()
		{
			return new Vector3((float)-y, (float)z, (float)x);
		}
		public Vector3 EclipticCartToUnityVector3Untested()
		{
			return new Vector3((float)-y, (float)z, (float)x);
		}

		public EquatorialCoords ToEquatorialSpherical()
		{
			return new EquatorialCoords(
				Math.Atan2(y, x) * StarMath.rad2hours,//HOURS
				Math.Atan2(z, Math.Sqrt(x * x + y * y)) * StarMath.rad2deg,
					this.Length());
		}

		public EclipticCoords ToEclipticSpherical()
		{
			var ecl = new EclipticCoords(
					Math.Atan2(z, Math.Sqrt(x * x + y * y)) * StarMath.rad2deg,
					Math.Atan2(y, x) * StarMath.rad2deg,
				this.Length());
			ecl.longitude = StarMath.WrapDeg(ecl.longitude);//nesecary?
			return ecl;
		}

		public CartesianCoords EclipticToEquatorialCartesian(double obl_ecl)
		{
			return new CartesianCoords(
			x,
			y * StarMath.Cos_d(obl_ecl) - z * StarMath.Sin_d(obl_ecl),
			y * StarMath.Sin_d(obl_ecl) + z * StarMath.Cos_d(obl_ecl)
			);
		}

		public CartesianCoords EquatorialToEclipticCartesian(double obl_ecl)
		{
			return new CartesianCoords(
			x,
			y * StarMath.Cos_d(-obl_ecl) - z * StarMath.Sin_d(-obl_ecl),
			y * StarMath.Sin_d(-obl_ecl) + z * StarMath.Cos_d(-obl_ecl));
		}

		public override string ToString()
		{
			return $"{x} , {y} , {z}";
		}
	}

}