const { getDaysFrom2000,
	deg2rad,
	deg2hours,
	millisInDay,
	wrapDeg,
	hours2deg,
	sin_d,
	cos_d,
	tan_d,
	asin_d,
	acos_d,
	atan_d,
	atan2_d
} = require('./utility');





if (require.main === module) {
	const getCelestialBodies = require('./celestialBodies');

	//SYDNEY TEST
	// const utcHour = 10.5
	// const lon = 151.2093 * deg2hours
	// const lat = -33.8688
	// let day = getDaysFrom2000(2020, 7, 10, utcHour)

	//SCANDINAVIA TEST
	const utcHour = 0
	const lon = 15 * deg2hours
	const lat = 60
	const day = getDaysFrom2000(1990, 4, 19, utcHour)


	const bodies = getCelestialBodies(day)

	const gmst0 = wrapDeg(bodies.sun.L * deg2hours + 12)
	const sidTime = gmst0 + utcHour + lon

	// getSunAzAlt(lon, lat, bodies.sun.equatorialSphereGeo.rightAscention, bodies.sun.equatorialSphereGeo.declination, utcHour, sidTime)
	getSunAzAlt(lon, lat, 0, 0, utcHour, sidTime)

}


// I THINK THIS SUN CASE CAN BE GENERAL CASE
function getSunAzAlt(lon, lat, ra, dec, utcHour, sidTime) {


	const ha = (sidTime - ra) * hours2deg

	const x_sid = cos_d(ha) * cos_d(dec)
	const y_sid = sin_d(ha) * cos_d(dec)
	const z_sid = sin_d(dec)

	const x_hor = x_sid * sin_d(lat) - z_sid * cos_d(lat)
	const y_hor = y_sid
	const z_hor = x_sid * cos_d(lat) + z_sid * sin_d(lat)

	const az = atan2_d(y_hor, x_hor) + 180
	const alt = atan2_d(z_hor, Math.sqrt(x_hor * x_hor + y_hor * y_hor))

	console.log(az, alt);



}
//DOESNT WORK
// function getMoonAzAlt(lon, lat, moon, utcHour, sidTime) {

	// 	const sidTime_d = sidTime * hours2deg

	// 	const gclat = lat - 0.1924 * sin_d(2 * lat)//sphere gclat = lat
	// 	const rho = 0.99833 + 0.00167 * cos_d(2 * lat)//sphere rho = 1
	// 	const mpar = Math.asin(1 / moon.r)

	// 	const ra = moon.equatorialSphereGeo.rightAscention
	// 	const dec = moon.equatorialSphereGeo.declination

	// 	// const ha_geo = (sidTime - ra)
	// 	// const ha_geo = (sidTime_d - ra)
	// 	const ha_geo = (sidTime - ra) * hours2deg

	// 	console.log(ha_geo);

	// 	const g = atan_d(tan_d(gclat) / cos_d(ha_geo))

	// 	const topRA = ra - mpar * rho * cos_d(gclat) * sin_d(ha_geo) / cos_d(dec)
	// 	const topDec = dec - mpar * rho * sin_d(gclat) * sin_d(g - dec) / sin_d(g)

	// 	// console.log(sidTime_d);
	// 	const ha = sidTime_d - ra
	// 	// console.dir(ha);


	// }
/*
SCANDINAVIA TEST VALUES
SUN
AZ 15.676702976646197
ALT -17.95700763078881


MOON
RA = 309.4881_deg
Decl = -19.0741_deg



SYDNEY TEST VALUES
10/07/2020 10:30:00 UT
TEST SUN
az 112°08'18" alt  -17°27'16"
TEST MOON
az 270°53'51" alt  -42°23'34"
*/