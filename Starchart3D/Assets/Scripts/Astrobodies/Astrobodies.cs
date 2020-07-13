
namespace Starchart3D
{

	public class Astrobodies
	{
		public Astrobody sun;
		public Astrobody moon;
		public Astrobody mercury;
		public Astrobody venus;
		public Astrobody earth;
		public Astrobody mars;
		public Astrobody jupiter;
		public Astrobody saturn;
		public Astrobody uranus;
		public Astrobody neptune;

		public Astrobody[] allBodies, helioBodies, geoBodies;

		public Astrobodies()
		{
			sun = new Astrobody(AstrobodyConstants.sun);
			moon = new Astrobody(AstrobodyConstants.moon);
			mercury = new Astrobody(AstrobodyConstants.mercury);
			venus = new Astrobody(AstrobodyConstants.venus);
			earth = new Astrobody(AstrobodyConstants.earth);
			mars = new Astrobody(AstrobodyConstants.mars);
			jupiter = new Astrobody(AstrobodyConstants.jupiter);
			saturn = new Astrobody(AstrobodyConstants.saturn);
			uranus = new Astrobody(AstrobodyConstants.uranus);
			neptune = new Astrobody(AstrobodyConstants.neptune);
			allBodies = new Astrobody[]
				{sun,moon,mercury,venus,earth,mars,jupiter,saturn,uranus,neptune};
			helioBodies = new Astrobody[]
				{mercury,venus,earth,mars,jupiter,saturn,uranus,neptune};
			geoBodies = new Astrobody[]
				{sun,moon};
		}



		public void UpdateBodies(double day)
		{
			allBodies.ForEach(b => OrbitalElements.UpdateElements(b, day));
			OrbitalPertubations.UpdateEclipticCarts(this);
			AstrobodyPositions.UpdatePositions(this, day);
		}

	}

}