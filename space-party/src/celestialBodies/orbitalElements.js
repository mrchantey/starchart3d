const {
	wrapDeg,
	// cbrt,
	// equatorialSphereToRectangular,
	// eclipticalSphereToRectangular,
	// rectangularToEquatorialSphere,
	rectangularToEclipticSphere,
	// eclipticalToEquatorial,
	// equatorialToEcliptical,
	getDaysFrom2000,
	// millisInDay,
	// y2000Millis,
	// deg2rad,
	rad2deg,
	// earthTiltDeg,
	abs,
	sqrt,
	// log,
	// exp,
	sin_d,
	cos_d,
	// tan_d,
	atan2_d
} = require('./utility');
/*
The primary orbital elements are here denoted as:
    N = longitude of the ascending node
    i = inclination to the ecliptic (plane of the Earth's orbit)
    w = argument of perihelion
    a = semi-major axis, or mean distance from Sun
    e = eccentricity (0=circle, 0-1=ellipse, 1=parabola)
    M = mean anomaly (0 at perihelion; increases uniformly with time)

	Related orbital elements are:
    w1 = N + w   = longitude of perihelion
    L  = M + w1  = mean longitude
    q  = a*(1-e) = perihelion distance
    Q  = a*(1+e) = aphelion distance
    P  = a ^ 1.5 = orbital period (years if a is in AU, astronomical units)
    T  = Epoch_of_M - (M(deg)/360_deg) / P  = time of perihelion
    v  = true anomaly (angle between position and perihelion)
    E  = eccentric anomaly
	*/

const constants = {
	sun: {
		N_offset: 0,			//Longitude of asc. node, point where the body passes from negative to positive latitude on the ecliptic
		N_scalar: 0,
		i_offset: 0,			//Inclination
		i_scalar: 0,
		w_offset: 282.9404,		//Longitude of perihelion
		w_scalar: 4.70935E-5,
		a_offset: 1.000000,		//mean distance, a.u.
		a_scalar: 0,
		e_offset: 0.016709,		//eccentricity
		e_scalar: -1.151E-9,
		M_offset: 356.0470,		//mean anomaly
		M_scalar: 0.9856002585,
	},
	moon: {
		N_offset: 125.1228,
		N_scalar: -0.0529538083,
		i_offset: 5.1454,
		i_scalar: 0,
		w_offset: 318.0634,
		w_scalar: 0.1643573223,	//(Arg. of perigee)
		a_offset: 60.2666,//earth radii
		a_scalar: 0,
		e_offset: 0.054900,
		e_scalar: 0,
		M_offset: 115.3654,
		M_scalar: 13.0649929509,
	},

	mercury: {
		N_offset: 48.3313,
		N_scalar: 3.24587E-5,
		i_offset: 7.0047,
		i_scalar: 5.00E-8,
		w_offset: 29.1241,
		w_scalar: 1.01444E-5,
		a_offset: 0.387098,
		a_scalar: 0,
		e_offset: 0.205635,
		e_scalar: 5.59E-10,
		M_offset: 168.6562,
		M_scalar: 4.0923344368
	},
	venus: {
		N_offset: 76.6799,
		N_scalar: 2.46590E-5,
		i_offset: 3.3946,
		i_scalar: 2.75E-8,
		w_offset: 54.8910,
		w_scalar: 1.38374E-5,
		a_offset: 0.723330,
		a_scalar: 0,
		e_offset: 0.006773,
		e_scalar: -1.302E-9,
		M_offset: 48.0052,
		M_scalar: 1.6021302244,
	},
	earth: {//values copied from sun with N flipped 180
		N_offset: 180,
		N_scalar: 0,
		i_offset: 0,
		i_scalar: 0,
		w_offset: 282.9404,
		w_scalar: 4.70935E-5,
		a_offset: 1.000000,
		a_scalar: 0,
		e_offset: 0.016709,
		e_scalar: -1.151E-9,
		M_offset: 356.0470,
		M_scalar: 0.9856002585,
	},
	mars: {
		N_offset: 49.5574,
		N_scalar: 2.11081E-5,
		i_offset: 1.8497,
		i_scalar: -1.78E-8,
		w_offset: 286.5016,
		w_scalar: 2.92961E-5,
		a_offset: 1.523688,
		a_scalar: 0,
		e_offset: 0.093405,
		e_scalar: 2.516E-9,
		M_offset: 18.6021,
		M_scalar: 0.5240207766,
	},
	jupiter: {
		N_offset: 100.4542,
		N_scalar: 2.76854E-5,
		i_offset: 1.3030,
		i_scalar: -1.557E-7,
		w_offset: 273.8777,
		w_scalar: 1.64505E-5,
		a_offset: 5.20256,
		a_scalar: 0,
		e_offset: 0.048498,
		e_scalar: 4.469E-9,
		M_offset: 19.8950,
		M_scalar: 0.0830853001,
	},
	saturn: {
		N_offset: 113.6634,
		N_scalar: 2.38980E-5,
		i_offset: 2.4886,
		i_scalar: -1.081E-7,
		w_offset: 339.3939,
		w_scalar: 2.97661E-5,
		a_offset: 9.55475,
		a_scalar: 0,
		e_offset: 0.055546,
		e_scalar: -9.499E-9,
		M_offset: 316.9670,
		M_scalar: 0.0334442282,
	},
	uranus: {
		N_offset: 74.0005,
		N_scalar: 1.3978E-5,
		i_offset: 0.7733,
		i_scalar: 1.9E-8,
		w_offset: 96.6612,
		w_scalar: 3.0565E-5,
		a_offset: 19.18171,
		a_scalar: -1.55E-8,//Grand Uranus-Neptune term
		e_offset: 0.047318,
		e_scalar: 7.45E-9,
		M_offset: 142.5905,
		M_scalar: 0.011725806,
	},
	neptune: {
		N_offset: 131.7806,
		N_scalar: 3.0173E-5,
		i_offset: 1.7700,
		i_scalar: -2.55E-7,
		w_offset: 272.8461,
		w_scalar: -6.027E-6,
		a_offset: 30.05826,
		a_scalar: 3.313E-8,//Grand Uranus-Neptune term
		e_offset: 0.008606,
		e_scalar: 2.15E-9,
		M_offset: 260.2471,
		M_scalar: 0.005995147,
	},


}


function getOrbitalElements(day, cnst) {

	///CALCULATE PRIMARY ELEMENTS
	const el = {
		N: wrapDeg(cnst.N_offset + cnst.N_scalar * day),
		i: wrapDeg(cnst.i_offset + cnst.i_scalar * day),
		w: wrapDeg(cnst.w_offset + cnst.w_scalar * day),
		a: wrapDeg(cnst.a_offset + cnst.a_scalar * day),
		e: wrapDeg(cnst.e_offset + cnst.e_scalar * day),
		M: wrapDeg(cnst.M_offset + cnst.M_scalar * day)
	}
	const { N, i, w, a, e, M } = el

	//CALCULATE SECONDARY ELEMENTS

	el.L = wrapDeg(N + w + M)
	let E0 = M + rad2deg * e * sin_d(M) * (1 + e * cos_d(M))
	let E1 = 0
	do {
		let temp = E0
		E0 = E1
		E1 = temp - (temp - rad2deg * e * sin_d(temp) - M) / (1 - e * cos_d(temp))
		// console.log(`${planetType} ecc diff: ${abs(E1 - E0)}`);
	}
	while (abs(E1 - E0) > 0.005)
	el.E = E1

	el.x = a * (cos_d(el.E) - e)
	el.y = a * sqrt(1 - e * e) * sin_d(el.E)
	el.r = sqrt(el.x * el.x + el.y * el.y)
	el.v = wrapDeg(atan2_d(el.y, el.x))//is wrapDeg nessecary? ie is negative bad?

	el.eclipticRect = {
		x: el.r * (cos_d(N) * cos_d(el.v + w) - sin_d(N) * sin_d(el.v + w) * cos_d(i)),
		y: el.r * (sin_d(N) * cos_d(el.v + w) + cos_d(N) * sin_d(el.v + w) * cos_d(i)),
		z: el.r * sin_d(el.v + w) * sin_d(i)
	}

	el.eclipticSphere = rectangularToEclipticSphere(el.eclipticRect)
	el.eclipticSphere.longitude = wrapDeg(el.eclipticSphere.longitude)//nesecary?


	return el
}

function getAllOrbitalElements(day) {
	const elements = {}
	Object.entries(constants).forEach(([key, value]) => {
		elements[key] = getOrbitalElements(day, value)
	})
	return elements
}


if (require.main === module) {
	const day = getDaysFrom2000(1990, 3, 19)
	const elements = getAllOrbitalElements(day)
	console.dir(elements);
}

module.exports = getAllOrbitalElements