
namespace Starchart3D
{



	public struct AstrobodyConstants
	{
		public string name;
		public double N_offset;     //Longitude of asc. node, point where the body passes from negative to positive latitude on the ecliptic
		public double N_scalar;
		public double i_offset;     //Inclination
		public double i_scalar;
		public double w_offset;     //Longitude of perihelion
		public double w_scalar;
		public double a_offset;     //mean distance, a.u. or earth radii for moon
		public double a_scalar;
		public double e_offset;     //eccentricity
		public double e_scalar;
		public double M_offset;     //mean anomaly
		public double M_scalar;

		public static readonly AstrobodyConstants[] constants_all = new AstrobodyConstants[]
		{sun,moon,mercury,venus,earth,mars,jupiter,saturn,uranus,neptune};

		public static readonly AstrobodyConstants[] constants_ex_earth = new AstrobodyConstants[]
		{sun,moon,mercury,venus,mars,jupiter,saturn,uranus,neptune};

		public static readonly AstrobodyConstants[] constants_ex_sun = new AstrobodyConstants[]
		{moon,mercury,venus,mars,jupiter,saturn,uranus,neptune};

		public static readonly AstrobodyConstants sun = new AstrobodyConstants()
		{
			name = "sun",
			N_offset = 0,
			N_scalar = 0,
			i_offset = 0,
			i_scalar = 0,
			w_offset = 282.9404,
			w_scalar = 4.70935E-5,
			a_offset = 1.000000,
			a_scalar = 0,
			e_offset = 0.016709,
			e_scalar = -1.151E-9,
			M_offset = 356.0470,
			M_scalar = 0.9856002585,
		};

		public static readonly AstrobodyConstants moon = new AstrobodyConstants()
		{
			name = "moon",
			N_offset = 125.1228,
			N_scalar = -0.0529538083,
			i_offset = 5.1454,
			i_scalar = 0,
			w_offset = 318.0634,
			w_scalar = 0.1643573223,    //arg. of perigee
			a_offset = 60.2666,         //earth radii
			a_scalar = 0,
			e_offset = 0.054900,
			e_scalar = 0,
			M_offset = 115.3654,
			M_scalar = 13.0649929509,
		};

		public static readonly AstrobodyConstants mercury = new AstrobodyConstants()
		{
			name = "mercury",
			N_offset = 48.3313,
			N_scalar = 3.24587E-5,
			i_offset = 7.0047,
			i_scalar = 5.00E-8,
			w_offset = 29.1241,
			w_scalar = 1.01444E-5,
			a_offset = 0.387098,
			a_scalar = 0,
			e_offset = 0.205635,
			e_scalar = 5.59E-10,
			M_offset = 168.6562,
			M_scalar = 4.0923344368
		};




		public static readonly AstrobodyConstants venus = new AstrobodyConstants()
		{
			name = "venus",
			N_offset = 76.6799,
			N_scalar = 2.46590E-5,
			i_offset = 3.3946,
			i_scalar = 2.75E-8,
			w_offset = 54.8910,
			w_scalar = 1.38374E-5,
			a_offset = 0.723330,
			a_scalar = 0,
			e_offset = 0.006773,
			e_scalar = -1.302E-9,
			M_offset = 48.0052,
			M_scalar = 1.6021302244,
		};
		public static readonly AstrobodyConstants earth = new AstrobodyConstants()//values copied from sun with N flipped 180
		{
			name = "earth",
			N_offset = 180,
			N_scalar = 0,
			i_offset = 0,
			i_scalar = 0,
			w_offset = 282.9404,
			w_scalar = 4.70935E-5,
			a_offset = 1.000000,
			a_scalar = 0,
			e_offset = 0.016709,
			e_scalar = -1.151E-9,
			M_offset = 356.0470,
			M_scalar = 0.9856002585,
		};
		public static readonly AstrobodyConstants mars = new AstrobodyConstants()
		{
			name = "mars",
			N_offset = 49.5574,
			N_scalar = 2.11081E-5,
			i_offset = 1.8497,
			i_scalar = -1.78E-8,
			w_offset = 286.5016,
			w_scalar = 2.92961E-5,
			a_offset = 1.523688,
			a_scalar = 0,
			e_offset = 0.093405,
			e_scalar = 2.516E-9,
			M_offset = 18.6021,
			M_scalar = 0.5240207766,
		};
		public static readonly AstrobodyConstants jupiter = new AstrobodyConstants()
		{
			name = "jupiter",
			N_offset = 100.4542,
			N_scalar = 2.76854E-5,
			i_offset = 1.3030,
			i_scalar = -1.557E-7,
			w_offset = 273.8777,
			w_scalar = 1.64505E-5,
			a_offset = 5.20256,
			a_scalar = 0,
			e_offset = 0.048498,
			e_scalar = 4.469E-9,
			M_offset = 19.8950,
			M_scalar = 0.0830853001,
		};
		public static readonly AstrobodyConstants saturn = new AstrobodyConstants()
		{
			name = "saturn",
			N_offset = 113.6634,
			N_scalar = 2.38980E-5,
			i_offset = 2.4886,
			i_scalar = -1.081E-7,
			w_offset = 339.3939,
			w_scalar = 2.97661E-5,
			a_offset = 9.55475,
			a_scalar = 0,
			e_offset = 0.055546,
			e_scalar = -9.499E-9,
			M_offset = 316.9670,
			M_scalar = 0.0334442282,
		};
		public static readonly AstrobodyConstants uranus = new AstrobodyConstants()
		{
			name = "uranus",
			N_offset = 74.0005,
			N_scalar = 1.3978E-5,
			i_offset = 0.7733,
			i_scalar = 1.9E-8,
			w_offset = 96.6612,
			w_scalar = 3.0565E-5,
			a_offset = 19.18171,
			a_scalar = -1.55E-8,//Grand Uranus-Neptune term
			e_offset = 0.047318,
			e_scalar = 7.45E-9,
			M_offset = 142.5905,
			M_scalar = 0.011725806,
		};
		public static readonly AstrobodyConstants neptune = new AstrobodyConstants()
		{
			name = "neptune",
			N_offset = 131.7806,
			N_scalar = 3.0173E-5,
			i_offset = 1.7700,
			i_scalar = -2.55E-7,
			w_offset = 272.8461,
			w_scalar = -6.027E-6,
			a_offset = 30.05826,
			a_scalar = 3.313E-8,//Grand Uranus-Neptune term
			e_offset = 0.008606,
			e_scalar = 2.15E-9,
			M_offset = 260.2471,
			M_scalar = 0.005995147,
		};
	}
}