
function wrapDeg(x) {
	return x - Math.floor(x / 360.0) * 360.0;
}
function wrapHours(x) {
	return x - Math.floor(x / 24) * 24;
}
function cbrt(x) {
	if (x > 0.0)
		return exp(log(x) / 3.0);
	else if (x < 0.0)
		return -cbrt(-x);
	else /* x == 0.0 */
		return 0.0;
}

function equatorialSphereToRectangular({ rightAscention, declination, radius = 1 }) {
	return {
		x: radius * cos_d(rightAscention) * cos_d(declination),
		y: radius * sin_d(rightAscention) * cos_d(declination),
		z: radius * sin_d(declination)
	}
}

function eclipticalSphereToRectangular({ longitude, latitude, radius }) {
	return {
		x: radius * cos_d(longitude) * cos_d(latitude),
		y: radius * sin_d(longitude) * cos_d(latitude),
		z: radius * sin_d(latitude)
	}
}

function rectangularToEquatorialSphere({ x, y, z }) {
	return {
		radius: sqrt(x * x + y * y + z * z),
		rightAscention: Math.atan2(y, x) * rad2hours,
		declination: Math.atan2(z, sqrt(x * x + y * y)) * rad2deg
	}
}
//yes identical to equatorial
function rectangularToEclipticSphere({ x, y, z }) {
	return {
		radius: sqrt(x * x + y * y + z * z),
		longitude: Math.atan2(y, x) * rad2deg,
		latitude: Math.atan2(z, sqrt(x * x + y * y)) * rad2deg
	}
}


function eclipticalToEquatorial({ x, y, z }, obl_ecl) {
	return {
		x: x,
		y: y * cos_d(obl_ecl) - z * sin_d(obl_ecl),
		z: y * sin_d(obl_ecl) + z * cos_d(obl_ecl)
	}
}

function equatorialToEcliptical({ x, y, z }, obl_ecl) {
	return {
		x: x,
		y: y * cos_d(-obl_ecl) - z * sin_d(-obl_ecl),
		z: y * sin_d(-obl_ecl) + z * cos_d(-obl_ecl)
	}
}
// const earthTiltRad = earthTiltDeg * deg2rad

const deg2rad = Math.PI / 180
const rad2deg = 180 / Math.PI
const rad2hours = 12 / Math.PI;
const hours2rad = Math.PI / 12;
const deg2hours = 1 / 15
const hours2deg = 15
const earthTiltDeg = 23.4393
const abs = Math.abs
const sqrt = Math.sqrt
const log = Math.log
const exp = Math.exp
const sin_d = v => Math.sin(v * deg2rad)
const cos_d = v => Math.cos(v * deg2rad)
const tan_d = v => Math.tan(v * deg2rad)
const asin_d = v => Math.asin(v * deg2rad)
const acos_d = v => Math.acos(v * deg2rad)
const atan_d = v => Math.atan(v * deg2rad)
const atan2_d = (x, y) => Math.atan2(x * deg2rad, y * deg2rad) * rad2deg

//millis, seconds, minutes, hours
const millisInDay = 1000 * 60 * 60 * 24
// const millisInHour = 1000 * 60 * 60
const y2000Millis = Date.UTC(2000, 0, 1)

//NOT J2000, which is noon?
function getDaysFrom2000(year, month = 0, day = 1, hour = 0, minute = 0, second = 0, millisecond = 0) {
	const d = new Date()
	d.setUTCHours(hour, minute, second, millisecond)
	d.setUTCFullYear(year, month - 1, day)//MONTHS ARE ZERO INDEXED
	const utcMillis = d.getTime()
	return 1 + (utcMillis - y2000Millis) / millisInDay;//why the one? dunno but its tested
	// return (utcMillis - y2000Millis) / millisInDay;
	// add 1 because point of origin is 31st december 1999
}

function dateTo2000Offset(date) {
	const utcMillis = date.getTime()//utc
	return 1 + (utcMillis - y2000Millis) / millisInDay;
}

// function dateToDaysFrom2000(date) {
// 	const d = new Date()
// 	d.getut


// }


const metersPerAU = 1.4959787e+11;
const metersPerEarthRadii = 6378140.0;
const earthRadiiPerAU = metersPerAU / metersPerEarthRadii;      // 23454.779920164812


module.exports = {
	earthRadiiPerAU,
	wrapDeg,
	wrapHours,
	cbrt,
	equatorialSphereToRectangular,
	eclipticalSphereToRectangular,
	rectangularToEquatorialSphere,
	rectangularToEclipticSphere,
	eclipticalToEquatorial,
	equatorialToEcliptical,
	getDaysFrom2000,
	dateTo2000Offset,
	millisInDay,
	y2000Millis,
	deg2rad,
	rad2deg,
	rad2hours,
	hours2rad,
	earthTiltDeg,
	deg2hours,
	hours2deg,
	abs,
	sqrt,
	log,
	exp,
	sin_d,
	cos_d,
	tan_d,
	asin_d,
	acos_d,
	atan_d,
	atan2_d

}