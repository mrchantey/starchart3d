import React from 'react';
import { styled } from '@material-ui/core/styles';
import p5 from 'p5';


const getCelestialBodies = require('./celestialBodies/celestialBodies');
const { dateTo2000Offset, deg2rad, millisInDay } = require('./celestialBodies/utility');

const CanvasContainerStyle = styled('div')({
	margin: '1rem',
})
// let day = getDaysFrom2000(1991, 11, 29)



const Sketch = ({ settingsRef, setSettings }) => {

	const parentRef = React.createRef()
	// const un

	React.useEffect(_ => {
		const parent = parentRef.current
		const { width, height } = parent.getBoundingClientRect()
		const u = Math.min(width, height) * 0.01
		const sketchRadius = u * 50
		const distScale = u * 45
		const bodySize = u * 6
		const textSize = u * 3
		let lastFrameMillis

		const sketch = new p5(p => {
			p.setup = _ => {
				p.createCanvas(width, height)
					.parent(parent)
				p.stroke(127, 127, 76)
				// p.background(102, 255, 178)
				p.fill(255, 255, 153)
				p.textAlign(p.CENTER, p.CENTER)
				p.textSize(textSize)
				lastFrameMillis = Date.now()
			}
			p.draw = _ => {
				// p.background(102, 255, 178)
				p.background(0, 0, 32)
				// p.background('rgba(0,0,0,0.0001)')
				p.translate(p.width / 2, p.height / 2)
				drawZodiac()


				const thisFrameMillis = Date.now()
				const deltaMillis = thisFrameMillis - lastFrameMillis
				lastFrameMillis = thisFrameMillis

				const dateObj = settingsRef.current.date
				const lastDate = dateObj._isAMomentObject ? dateObj._d : dateObj//https://stackoverflow.com/questions/28126529/momentjs-internal-object-what-is-d-vs-i#:~:text=_i%20will%20never%20be%20a,that%20backs%20the%20moment%20object.&text=If%20you%20are%20in%20%22UTC,exhibits%20with%20the%20public%20API.

				const daysPerSecond = settingsRef.current.daysPerSecond
				const millis = lastDate.getTime()
				const nextMillis = millis + millisInDay * daysPerSecond * deltaMillis * 0.001
				var nextDate = new Date(nextMillis)
				setSettings(prev => ({
					...prev,
					date: nextDate
				}))//new date needs to be set in order to update states

				const day = dateTo2000Offset(lastDate)

				const celestialBodies = getCelestialBodies(day)

				// drawEarthMoon(celestialBodies.earth, celestialBodies.moon)
				const bodies = ["sun", "mercury", "venus", "earth", "mars", "jupiter", "saturn", "uranus", "neptune"]
				// const bodies = ["sun", "moon", "mercury", "venus", "earth", "mars", "jupiter", "saturn", "uranus", "neptune"]

				bodies.forEach(b => {
					// drawEclipticRectHelio(celestialBodies[b])
					// drawEclipticRectGeoHelio(celestialBodies[b])
					drawEclipticSphereGeo(celestialBodies[b])
				})
				// p.noLoop()
			}

			const zodiac = ["Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricon", "Aquarius", "Pisces"]
			function drawZodiac() {
				const thetaStep = Math.PI / 6
				const halfThetaStep = Math.PI / 12
				for (let i = 0; i < 12; i++) {
					const theta = i * thetaStep
					const x1 = Math.cos(theta) * sketchRadius
					const y1 = -Math.sin(theta) * sketchRadius
					const x2 = Math.cos(theta + Math.PI) * sketchRadius
					const y2 = -Math.sin(theta + Math.PI) * sketchRadius
					const x3 = Math.cos(theta + halfThetaStep) * sketchRadius
					const y3 = -Math.sin(theta + halfThetaStep) * sketchRadius
					p.fill(255)
					p.noStroke()
					p.text(`${zodiac[i]}`, x3, y3)
					p.stroke(255)
					p.strokeWeight(1)
					p.line(x1, y1, x2, y2)
				}
			}

			function drawEclipticRectHelio(body) {
				const pos = body.eclipticRectHelio
				drawBody(body.name, pos.x, pos.y)
			}
			function drawEclipticRectGeo(body) {
				const pos = body.eclipticRectGeo
				drawBody(body.name, pos.x, pos.y)
			}

			function bezier(p0, p1, p2, p3, t) {
				const it = 1 - t;
				return Math.pow(it, 3) * p0
					+ 3 * Math.pow(it, 2) * t * p1
					+ 3 * it * Math.pow(t, 2) * p2
					+ Math.pow(t, 3) * p3;
			}

			function iterateBezier(p0, p1, p2, p3, t, iterations) {
				for (let i = 0; i < iterations; i++) {
					t = bezier(p0, p1, p2, p3, t)
				}
				return t
			}

			function drawEclipticSphereGeo(body) {
				const { radius, longitude } = body.eclipticSphereGeo
				let r = radius / 35
				r = iterateBezier(0,
					settingsRef.current.distanceScaleMin,
					settingsRef.current.distanceScaleMax,
					1,
					r,
					settingsRef.current.distanceScaleIterations)
				const theta = longitude * deg2rad
				const x = r * Math.cos(theta)
				const y = r * Math.sin(theta)
				drawBody(body.name, x, y)
			}

			function drawBody(name, x, y) {
				x *= distScale
				y *= -distScale		//invert y axis
				p.noStroke()
				p.fill(127, 127, 127)
				p.ellipse(x, y, bodySize, bodySize)
				p.fill(255)
				p.text(name, x, y)
			}
			// function drawEquatorialSphereGeo(body) {
			// 	const sphere = body.equatorialSphereGeo
			// 	const theta = sphere.rightAscention / 24 * Math.PI * 2
			// 	const x = Math.cos(theta)
			// 	const y = Math.sin(theta)
			// 	drawBody(body.name, x, y)
			// }

			// function drawEarthMoon(earth, moon) {
			// 	const earthPos = earth.eclipticRectHelio
			// 	const moonPos = moon.eclipticRectHelio
			// 	p.translate(earthPos.x * distScale, earthPos.y * distScale)
			// 	// p.scale(2, 2)
			// 	p.noStroke()
			// 	p.fill(127, 127, 255)
			// 	p.ellipse(0, 0, 10 * bodySize, 10 * bodySize)
			// 	const deltaMoonPos = {
			// 		x: moonPos.x - earthPos.x,
			// 		y: moonPos.y - earthPos.y
			// 	}
			// 	const s2 = bodySize * 10000
			// 	p.fill(0, 127, 255)
			// 	p.ellipse(deltaMoonPos.x * s2, deltaMoonPos.y * s2, 5 * bodySize, 5 * bodySize)

			// 	// const mPos = moonPos
			// 	// moonPos -= earthPos
			// }

			// const pos = body.eclipticRectGeo
			// const pos = body.eclipticRectGeo
			// const x = pos.x * distScale
			// const y = pos.y * distScale
			// const sphere = body.eclipticSphereGeo
			// const x = Math.cos(sphere.longitude / 360 * Math.PI * 2) * distScale
			// const y = Math.sin(sphere.longitude / 360 * Math.PI * 2) * distScale
			// }
		})

	}, [])
	return <CanvasContainerStyle id="canvasContainer" ref={parentRef} />
}
export default Sketch
