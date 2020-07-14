using System.Linq;
using System;


namespace Starchart3D
{

	public class OrbitalElements
	{
		//primary elements
		public double N;
		public double i;
		public double w;
		public double a;
		public double e;
		public double M;

		//secondary elements
		public double L;
		public double E;
		public double x;
		public double y;
		public double r;
		public double v;

		public CartesianCoords unpertubatedEclitpticCart;


		public OrbitalElements()
		{
			unpertubatedEclitpticCart = new CartesianCoords();
		}

		public static void UpdateElements(Astrobody body, double day)
		{
			var el = body.orbitalElements;

			el.N = StarMath.WrapDeg(body.constants.N_offset + body.constants.N_scalar * day);
			el.i = StarMath.WrapDeg(body.constants.i_offset + body.constants.i_scalar * day);
			el.w = StarMath.WrapDeg(body.constants.w_offset + body.constants.w_scalar * day);
			el.a = StarMath.WrapDeg(body.constants.a_offset + body.constants.a_scalar * day);
			el.e = StarMath.WrapDeg(body.constants.e_offset + body.constants.e_scalar * day);
			el.M = StarMath.WrapDeg(body.constants.M_offset + body.constants.M_scalar * day);
			//CALCULATE SECONDARY ELEMENTS


			el.L = StarMath.WrapDeg(el.N + el.w + el.M);

			double E0 = el.M + StarMath.rad2deg * el.e * StarMath.Sin_d(el.M) * (1 + el.e * StarMath.Cos_d(el.M));
			double E1 = 0;
			do
			{
				double temp = E0;
				E0 = E1;
				E1 = temp - (temp - StarMath.rad2deg * el.e * StarMath.Sin_d(temp) - el.M) / (1 - el.e * StarMath.Cos_d(temp));
				// console.log(`${planetType} ecc diff: ${Math.abs(E1 - E0)}`);
			}
			while (Math.Abs(E1 - E0) > 0.005);
			el.E = E1;

			el.x = el.a * (StarMath.Cos_d(el.E) - el.e);
			el.y = el.a * Math.Sqrt(1 - el.e * el.e) * StarMath.Sin_d(el.E);
			el.r = Math.Sqrt(el.x * el.x + el.y * el.y);
			el.v = StarMath.WrapDeg(StarMath.Atan2_d(el.y, el.x));//is StarMath.WrapDeg nessecary? ie is negative bad?

			el.unpertubatedEclitpticCart.x =
				el.r * (StarMath.Cos_d(el.N) * StarMath.Cos_d(el.v + el.w) - StarMath.Sin_d(el.N) * StarMath.Sin_d(el.v + el.w) * StarMath.Cos_d(el.i));
			el.unpertubatedEclitpticCart.y =
				el.r * (StarMath.Sin_d(el.N) * StarMath.Cos_d(el.v + el.w) + StarMath.Cos_d(el.N) * StarMath.Sin_d(el.v + el.w) * StarMath.Cos_d(el.i));
			el.unpertubatedEclitpticCart.z =
				el.r * StarMath.Sin_d(el.v + el.w) * StarMath.Sin_d(el.i);
			// el.eclipticSphere = el.eclitpticCart.ToEcliptic();
			// el.eclipticSphere.longitude = StarMath.WrapDeg(el.eclipticSphere.longitude)//nesecary?
		}

	}
}