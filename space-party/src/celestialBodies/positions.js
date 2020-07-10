const {
	earthRadiiPerAU,
	// wrapDeg,
	wrapHours,
	// cbrt,
	// equatorialSphereToRectangular,
	eclipticalSphereToRectangular,
	rectangularToEquatorialSphere,
	rectangularToEclipticSphere,
	eclipticalToEquatorial,
	// equatorialToEcliptical,
	// getDaysFrom2000,
	// millisInDay,
	// y2000Millis,
	// deg2rad,
	// rad2deg,
	earthTiltDeg,
	// abs,
	// atan2,
	// sqrt,
	// log,
	// exp,
	// sin_d,
	// cos_d,
	// tan_d,
	// atan2_d
} = require('./utility');

function subtract(a, b) {
	return {
		x: a.x - b.x,
		y: a.y - b.y,
		z: a.z - b.z
	}
}
function add(a, b) {
	return {
		x: a.x + b.x,
		y: a.y + b.y,
		z: a.z + b.z
	}
}


function calculatePositions(bodies, day) {
	const obl_ecl = earthTiltDeg - 3.563E-7 * day //obliquity of the ecliptic, decreasing

	const helioBodies = ["mercury", "venus", "earth", "mars", "jupiter", "saturn", "uranus", "neptune"]
	const geoBodies = ["sun", "moon"]

	// const sun = bodies.sun
	helioBodies.forEach(n => {
		const b = bodies[n]
		b.eclipticRectHelio = b.eclipticRect
		b.eclipticSphereHelio = b.eclipticSphere
		b.eclipticRectGeo = add(b.eclipticRect, bodies.sun.eclipticRect)
		b.eclipticSphereGeo = rectangularToEclipticSphere(b.eclipticRectGeo)
	})

	//convert moon radius to AU

	bodies.moon.eclipticSphere.radius /= earthRadiiPerAU
	bodies.moon.eclipticRect = eclipticalSphereToRectangular(bodies.moon.eclipticSphere)


	//UNTESTED, NEED TO VISUALIZE
	geoBodies.forEach(n => {
		const b = bodies[n]
		b.eclipticRectGeo = b.eclipticRect
		b.eclipticSphereGeo = b.eclipticSphere
		b.eclipticRectHelio = subtract(b.eclipticRect, bodies.sun.eclipticRect)//confirmed
		b.eclipticSphereHelio = rectangularToEclipticSphere(b.eclipticRectHelio)//
	})


	//CALCULATE EQUATORIAL POSITION
	Object.entries(bodies).forEach(([key, value]) => {
		value.name = key
		value.equatorialRectGeo = eclipticalToEquatorial(value.eclipticRectGeo, obl_ecl)
		value.equatorialSphereGeo = rectangularToEquatorialSphere(value.equatorialRectGeo)
		value.equatorialSphereGeo.rightAscention = wrapHours(value.equatorialSphereGeo.rightAscention)//nessecary?
		// value.eclipticSphere
	})
}


module.exports = calculatePositions