const {
	// wrapDeg,
	// cbrt,
	// equatorialSphereToRectangular,
	eclipticalSphereToRectangular,
	// rectangularToEquatorialSphere,
	// rectangularToEclipticSphere,
	// eclipticalToEquatorial,
	// equatorialToEcliptical,
	// getDaysFrom2000,
	// millisInDay,
	// y2000Millis,
	// deg2rad,
	// rad2deg,
	// earthTiltDeg,
	// abs,
	// atan2,
	// sqrt,
	// log,
	// exp,
	sin_d,
	cos_d,
	// tan_d,
	// atan2_d
} = require('./utility');

function applyMoonPertubations(sun, moon) {
	const { N, M, L, } = moon
	// const { N, i, w, a, e, M, L, E, r, v } = moon

	const Ms = sun.M
	const F = L - N
	const D = L - sun.L
	const pertubations = {
		longitude:
			-1.274 * sin_d(M - 2 * D)    //(Evection)
			+ 0.658 * sin_d(2 * D)        // (Variation)
			- 0.186 * sin_d(Ms)          //(Yearly equation)
			- 0.059 * sin_d(2 * M - 2 * D)
			- 0.057 * sin_d(M - 2 * D + Ms)
			+ 0.053 * sin_d(M + 2 * D)
			+ 0.046 * sin_d(2 * D - Ms)
			+ 0.041 * sin_d(M - Ms)
			- 0.035 * sin_d(D)            //(Parallactic equation)
			- 0.031 * sin_d(M + Ms)
			- 0.015 * sin_d(2 * F - 2 * D)
			+ 0.011 * sin_d(M - 4 * D),
		latitude:
			-0.173 * sin_d(F - 2 * D)
			- 0.055 * sin_d(M - F - 2 * D)
			- 0.046 * sin_d(M + F - 2 * D)
			+ 0.033 * sin_d(F + 2 * D)
			+ 0.017 * sin_d(2 * M + F),
		radius:
			-0.58 * cos_d(M - 2 * D)
			- 0.46 * cos_d(2 * D)
	}
	//FOR TESTING ONLY
	moon.eclipticSphere.longitude += pertubations.longitude
	moon.eclipticSphere.latitude += pertubations.latitude
	moon.eclipticSphere.radius += pertubations.radius

	// moon.eclipticSphere.radius = 1
	// moon.eclipticSphere.longitude = 306.9484
	moon.eclipticRect = eclipticalSphereToRectangular(moon.eclipticSphere)
}

function applyJupiterPertubations(jupiter, saturn) {
	const Mj = jupiter.M
	const Ms = saturn.M
	const pertubations = {
		longitude:
			-0.332 * sin_d(2 * Mj - 5 * Ms - 67.6)
			- 0.056 * sin_d(2 * Mj - 2 * Ms + 21)
			+ 0.042 * sin_d(3 * Mj - 5 * Ms + 21)
			- 0.036 * sin_d(Mj - 2 * Ms)
			+ 0.022 * cos_d(Mj - Ms)
			+ 0.023 * sin_d(2 * Mj - 3 * Ms + 52)
			- 0.016 * sin_d(Mj - 5 * Ms - 69)
	}
	jupiter.eclipticSphere.longitude += pertubations.longitude
	jupiter.eclipticRect = eclipticalSphereToRectangular(jupiter.eclipticSphere)
}

function applySaturnPertubations(jupiter, saturn) {
	const Mj = jupiter.M
	const Ms = saturn.M
	const pertubations = {
		longitude:
			+0.812 * sin_d(2 * Mj - 5 * Ms - 67.6)
			- 0.229 * cos_d(2 * Mj - 4 * Ms - 2)
			+ 0.119 * sin_d(Mj - 2 * Ms - 3)
			+ 0.046 * sin_d(2 * Mj - 6 * Ms - 69)
			+ 0.014 * sin_d(Mj - 3 * Ms + 32),
		latitude:
			-0.020 * cos_d(2 * Mj - 4 * Ms - 2)
			+ 0.018 * sin_d(2 * Mj - 6 * Ms - 49)
	}
	saturn.eclipticSphere.longitude += pertubations.longitude
	saturn.eclipticSphere.latitude += pertubations.latitude
	saturn.eclipticRect = eclipticalSphereToRectangular(saturn.eclipticSphere)
}

function applyUranusPertubations(jupiter, saturn, uranus) {
	const Mj = jupiter.M
	const Ms = saturn.M
	const Mu = uranus.M
	const pertubations = {
		longitude:
			+0.040 * sin_d(Ms - 2 * Mu + 6)
			+ 0.035 * sin_d(Ms - 3 * Mu + 33)
			- 0.015 * sin_d(Mj - Mu + 20)
	}
	uranus.eclipticSphere.longitude += pertubations.longitude
	uranus.eclipticRect = eclipticalSphereToRectangular(uranus.eclipticSphere)
}


function applyPertubations(bodies) {
	applyMoonPertubations(bodies.sun, bodies.moon)
	applyJupiterPertubations(bodies.jupiter, bodies.saturn)
	applySaturnPertubations(bodies.jupiter, bodies.saturn)
	applyUranusPertubations(bodies.jupiter, bodies.saturn, bodies.uranus)
}



module.exports = applyPertubations