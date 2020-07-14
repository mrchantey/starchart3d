namespace Starchart3D
{

	public static class OrbitalPertubations
	{


		static EclipticCoords ApplyMoonPertubations(OrbitalElements sun, OrbitalElements moon)
		{
			double N = moon.N, M = moon.M, L = moon.L;
			double Ms = sun.M;
			double D = L - sun.L;
			double F = L - N;

			var ecliptic = moon.unpertubatedEclitpticCart.ToEclipticSpherical();

			ecliptic.longitude +=
			-1.274 * StarMath.Sin_d(M - 2 * D)    //(Evection)
			+ 0.658 * StarMath.Sin_d(2 * D)        // (Variation)
			- 0.186 * StarMath.Sin_d(Ms)          //(Yearly equation)
			- 0.059 * StarMath.Sin_d(2 * M - 2 * D)
			- 0.057 * StarMath.Sin_d(M - 2 * D + Ms)
			+ 0.053 * StarMath.Sin_d(M + 2 * D)
			+ 0.046 * StarMath.Sin_d(2 * D - Ms)
			+ 0.041 * StarMath.Sin_d(M - Ms)
			- 0.035 * StarMath.Sin_d(D)            //(Parallactic equation)
			- 0.031 * StarMath.Sin_d(M + Ms)
			- 0.015 * StarMath.Sin_d(2 * F - 2 * D)
			+ 0.011 * StarMath.Sin_d(M - 4 * D);

			ecliptic.latitude +=
			-0.173 * StarMath.Sin_d(F - 2 * D)
			- 0.055 * StarMath.Sin_d(M - F - 2 * D)
			- 0.046 * StarMath.Sin_d(M + F - 2 * D)
			+ 0.033 * StarMath.Sin_d(F + 2 * D)
			+ 0.017 * StarMath.Sin_d(2 * M + F);

			ecliptic.radius +=
			-0.58 * StarMath.Cos_d(M - 2 * D)
			- 0.46 * StarMath.Cos_d(2 * D);

			return ecliptic;
		}

		static EclipticCoords ApplyJupiterPertubations(OrbitalElements jupiter, OrbitalElements saturn)
		{
			double Mj = jupiter.M;
			double Ms = saturn.M;
			var ecliptic = jupiter.unpertubatedEclitpticCart.ToEclipticSpherical();

			ecliptic.longitude +=
			-0.332 * StarMath.Sin_d(2 * Mj - 5 * Ms - 67.6)
			- 0.056 * StarMath.Sin_d(2 * Mj - 2 * Ms + 21)
			+ 0.042 * StarMath.Sin_d(3 * Mj - 5 * Ms + 21)
			- 0.036 * StarMath.Sin_d(Mj - 2 * Ms)
			+ 0.022 * StarMath.Cos_d(Mj - Ms)
			+ 0.023 * StarMath.Sin_d(2 * Mj - 3 * Ms + 52)
			- 0.016 * StarMath.Sin_d(Mj - 5 * Ms - 69);

			return ecliptic;

		}

		static EclipticCoords ApplySaturnPertubations(OrbitalElements jupiter, OrbitalElements saturn)
		{
			double Mj = jupiter.M;
			double Ms = saturn.M;

			var ecliptic = saturn.unpertubatedEclitpticCart.ToEclipticSpherical();
			ecliptic.longitude +=
			+0.812 * StarMath.Sin_d(2 * Mj - 5 * Ms - 67.6)
			- 0.229 * StarMath.Cos_d(2 * Mj - 4 * Ms - 2)
			+ 0.119 * StarMath.Sin_d(Mj - 2 * Ms - 3)
			+ 0.046 * StarMath.Sin_d(2 * Mj - 6 * Ms - 69)
			+ 0.014 * StarMath.Sin_d(Mj - 3 * Ms + 32);
			ecliptic.latitude +=
			-0.020 * StarMath.Cos_d(2 * Mj - 4 * Ms - 2)
			+ 0.018 * StarMath.Sin_d(2 * Mj - 6 * Ms - 49);

			return ecliptic;
		}

		static EclipticCoords ApplyUranusPertubations(OrbitalElements jupiter, OrbitalElements saturn, OrbitalElements uranus)
		{
			double Mj = jupiter.M;
			double Ms = saturn.M;
			double Mu = uranus.M;

			var ecliptic = uranus.unpertubatedEclitpticCart.ToEclipticSpherical();


			ecliptic.longitude +=
			+0.040 * StarMath.Sin_d(Ms - 2 * Mu + 6)
			+ 0.035 * StarMath.Sin_d(Ms - 3 * Mu + 33)
			- 0.015 * StarMath.Sin_d(Mj - Mu + 20);

			return ecliptic;
		}


		static void ApplyUnpertubatedEcliptic(Astrobody body)
		{
			body.eclipticCartLocal = body.orbitalElements.unpertubatedEclitpticCart;
		}

		public static void UpdateEclipticCarts(Astrobodies bodies)
		{
			ApplyUnpertubatedEcliptic(bodies.sun);

			bodies.moon.eclipticCartLocal = ApplyMoonPertubations(
				bodies.sun.orbitalElements,
				bodies.moon.orbitalElements)
				.ToCartesian();

			ApplyUnpertubatedEcliptic(bodies.mercury);
			ApplyUnpertubatedEcliptic(bodies.venus);
			ApplyUnpertubatedEcliptic(bodies.earth);
			ApplyUnpertubatedEcliptic(bodies.mars);

			bodies.jupiter.eclipticCartLocal = ApplyJupiterPertubations(
				bodies.jupiter.orbitalElements,
				bodies.saturn.orbitalElements)
				.ToCartesian();

			bodies.saturn.eclipticCartLocal = ApplySaturnPertubations(
				bodies.jupiter.orbitalElements,
				bodies.saturn.orbitalElements)
				.ToCartesian();

			bodies.uranus.eclipticCartLocal = ApplyUranusPertubations(
				bodies.jupiter.orbitalElements,
				bodies.saturn.orbitalElements,
				bodies.uranus.orbitalElements)
				.ToCartesian();

			ApplyUnpertubatedEcliptic(bodies.neptune);
		}
	}
}