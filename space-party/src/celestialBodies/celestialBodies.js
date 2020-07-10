



const { getDaysFrom2000 } = require('./utility');
const getAllOrbitalElements = require('./orbitalElements');
const applyPertubations = require('./pertubations');
const calculatePositions = require('./positions');


function getCelestialBodies(day) {
	const bodies = getAllOrbitalElements(day)
	applyPertubations(bodies)
	calculatePositions(bodies, day)

	return bodies

}


if (require.main === module) {
	const day = getDaysFrom2000(1990, 4, 19)
	const bodies = getCelestialBodies(day)
	console.dir(bodies);
}

module.exports = getCelestialBodies


/*
example output:
sun: {
    N: 0,
    i: 0,
    w: 282.7735477295,
    a: 1,
    e: 0.016713077993,
    M: 104.06528413449996,
    L: 26.838831863999985,
    E: 104.99038551447352,
    x: -0.27537003282124345,
    y: 0.9658343236151069,
    r: 1.0043229538594765,
    v: 105.91343617758396,
    eclipticRect: { x: 0.8810475691133732, y: 0.4820993430906537, z: 0 },
    eclipticSphere: {
      radius: 1.0043229538594765,
      longitude: 28.686983907083956,
      latitude: 0
    },
    eclipticRectGeo: { x: 0.8810475691133732, y: 0.4820993430906537, z: 0 },
    eclipticSphereGeo: {
      radius: 1.0043229538594765,
      longitude: 28.686983907083956,
      latitude: 0
    },
    eclipticRectHelio: { x: 0, y: 0, z: 0 },
    eclipticSphereHelio: { radius: 0, longitude: 0, latitude: 0 },
    name: 'sun',
    equatorialRectGeo: {
      x: 0.8810475691133732,
      y: 0.44231324442489217,
      z: 0.1917779195182946
    },
    equatorialSphereGeo: {
      radius: 1.0043229538594765,
      rightAscention: 1.7772048282505475,
      declination: 11.00837277279888
    }
  },



*/