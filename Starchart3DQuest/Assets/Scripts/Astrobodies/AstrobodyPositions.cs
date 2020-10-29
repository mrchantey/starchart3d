
namespace Starchart3D
{

	public class AstrobodyPositions
	{


		public static void UpdatePositions(Astrobodies bodies, double day)
		{


			//convert moon radius to AU
			// bodies.moon.eclipticSphere.radius /= earthRadiiPerAU
			// bodies.moon.eclipticRect = eclipticalSphereToRectangular(bodies.moon.eclipticSphere)
			//UNTESTED
			bodies.moon.eclipticCartLocal.x /= StarMath.earthRadiiPerAU;
			bodies.moon.eclipticCartLocal.y /= StarMath.earthRadiiPerAU;
			bodies.moon.eclipticCartLocal.z /= StarMath.earthRadiiPerAU;


			bodies.helioBodies.ForEach(hb =>
			{
				hb.eclipticCartHelio = hb.eclipticCartLocal;
				hb.eclipticCartGeo = hb.eclipticCartLocal + bodies.sun.eclipticCartLocal; ;
			});
			bodies.geoBodies.ForEach(gb =>
			{
				gb.eclipticCartGeo = gb.eclipticCartLocal;
				gb.eclipticCartHelio = gb.eclipticCartLocal - bodies.sun.eclipticCartLocal;
			});

			//CALCULATE EQUATORIAL POSITION
			double obl_ecl = StarMath.ObliquityOfEcliptic(day);
			bodies.allBodies.ForEach(b =>
			{
				b.ecliptic = b.eclipticCartHelio.ToEclipticSpherical();
				b.equatorialCartGeo = b.eclipticCartGeo.EclipticToEquatorialCartesian(obl_ecl);
				b.equatorial = b.equatorialCartGeo.ToEquatorialSpherical();
			});
		}
	}

}