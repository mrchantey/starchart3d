
namespace Starchart3D
{
	public class Astrobody
	{
		public AstrobodyConstants constants;
		public OrbitalElements orbitalElements;

		public CartesianCoords eclipticCartLocal;
		public CartesianCoords eclipticCartHelio;
		public CartesianCoords eclipticCartGeo;

		public CartesianCoords equatorialCartGeo;

		public EclipticCoords ecliptic;
		public EquatorialCoords equatorial;


		public Astrobody(AstrobodyConstants constants)
		{
			this.constants = constants;
			this.orbitalElements = new OrbitalElements();

			this.eclipticCartLocal = new CartesianCoords();
			this.eclipticCartHelio = new CartesianCoords();
			this.eclipticCartGeo = new CartesianCoords();

			this.equatorialCartGeo = new CartesianCoords();

			this.ecliptic = new EclipticCoords();
			this.equatorial = new EquatorialCoords();
		}

		public override string ToString()
		{
			return $"\nname: {constants.name}\necliptic: {ecliptic}\nequatorial: {equatorial}\nequatorial cartesian - geocentric: {equatorialCartGeo}";
		}

	}
}