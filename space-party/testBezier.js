
function bezier(p0, p1, p2, p3, t) {
	const it = 1 - t;
	return Math.pow(it, 3) * p0
		+ 3 * Math.pow(it, 2) * t * p1
		+ 3 * it * Math.pow(t, 2) * p2
		+ Math.pow(t, 3) * p3;
}

function bezier2d(p0, p1, p2, p3, t) {
	return {
		x: bezier(p0.x, p1.x, p2.x, p3.x, t),
		y: bezier(p0.y, p1.y, p2.y, p3.y, t)
	}
}

function bezierEasing(p1, p2, t) {
	return bezier(0, p1.x, p2.x, x, 1, t)
}


function printBezier(p0, p1, p2, p3) {
	for (let i = 0; i < 10; i++) {
		const val = bezier2d(p0, p1, p2, p3, i * 0.1)
		console.log(`${i}\tx: ${val.x.toFixed(2)}\ty: ${val.y.toFixed(2)}`);
	}
}

const p0 = { x: 0, y: 0 }
const p1 = { x: 1, y: 0 }
const p2 = { x: 1, y: 0 }
const p3 = { x: 1, y: 1 }

printBezier(p0, p1, p2, p3)