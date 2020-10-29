
const math = require('./math');



module.exports = {
    linear1d,
    quadratic1d,
    cubic1d,
    quadratic2d,
    cubic2d,
    toBezierSegmentsClosed,
    toDistributedPoints,
}


function linear1d(p0, p1, t) {
    t = Math.min(Math.max(t, 0), 1);
    return p0 +
        t * (p1 - p0);
}

function quadratic1d(p0, p1, p2, t) {
    t = Math.min(Math.max(t, 0), 1);
    return p1
        + Math.pow((1 - t), 2) * (p0 - p1)
        + Math.pow(t, 2) * (p2 - p1)
}

function cubic1d(p0, p1, p2, p3, t) {
    t = Math.min(Math.max(t, 0), 1);
    const it = 1 - t
    return Math.pow(it, 3) * p0
        + 3 * Math.pow(it, 2) * t * p1
        + 3 * it * Math.pow(t, 2) * p2
        + Math.pow(t, 3) * p3
}

function quadratic2d(p0, p1, p2, t) {
    return {
        x: quadratic1d(p0.x, p1.x, p2.x, t),
        y: quadratic1d(p0.y, p1.y, p2.y, t)
    }
}

function cubic2d(p0, p1, p2, p3, t) {
    return {
        x: cubic1d(p0.x, p1.x, p2.x, p3.x, t),
        y: cubic1d(p0.y, p1.y, p2.y, p3.y, t)
    }
}

function tangentPoints(p0, p1, p2, radiusScalar = 0.5) {

    const p0_1 = math.sub(p1, p0)
    const polar0_1 = math.cartesianToPolar(p0_1)

    const theta0_1_2 = math.signedDeltaAngle(p0, p1, p2)

    const tangentTheta1_2 = polar0_1.theta + theta0_1_2 / 2
    const tangentTheta0_1 = tangentTheta1_2 + Math.PI

    //radius is not satisfactory, need a new formula
    //values higher than 0.5 will cause 'knotting'
    const tangentRadius0_1 = math.distance(p0, p1) * radiusScalar
    const tangentRadius1_2 = math.distance(p1, p2) * radiusScalar

    let tangent0_1 = math.polarToCartesian(tangentTheta0_1, tangentRadius0_1)
    let tangent1_2 = math.polarToCartesian(tangentTheta1_2, tangentRadius1_2)

    tangent0_1 = math.add(tangent0_1, p1)
    tangent1_2 = math.add(tangent1_2, p1)

    return {
        tangent0_1
        , tangent1_2
    }
}

// function toBezierSegments(points, radiusScalar = 0.5) {

//     var tangents = []

//     for (let i = 0; i < points.length - 2; i++) {
//         var quad = tangentPoints(points[i], points[i + 1], points[i + 2], radiusScalar)
//         tangents.push(quad.tangent0_1)
//         tangents.push(quad.tangent1_2)
//         console.log('in the loop');
//     }
//     return tangents

// }

function toBezierSegmentsClosed(points, radiusScalar = 0.5) {

    var tangents = []

    const quad1 = tangentPoints(points[points.length - 1], points[0], points[1], radiusScalar)
    tangents.push(quad1.tangent1_2)

    for (let i = 0; i < points.length - 2; i++) {
        const quad = tangentPoints(points[i], points[i + 1], points[i + 2], radiusScalar)
        tangents.push(quad.tangent0_1)
        tangents.push(quad.tangent1_2)
        // console.log('in the loop');
    }

    const quad2 = tangentPoints(points[points.length - 2], points[points.length - 1], points[0], radiusScalar)
    tangents.push(quad2.tangent0_1)
    tangents.push(quad2.tangent1_2)
    tangents.push(quad1.tangent0_1)

    // console.dir(points);
    // console.dir(tangents);
    var segments = createSegmentsClosed(points, tangents)
    appendSegmentLengths(segments, 100)
    return segments

}

function appendSegmentLengths(segments, resolution) {

    segments.forEach(s => {
        let lastPos = s.p0
        let accDist = 0
        for (let i = 1; i < resolution; i++) {
            const t = i / (resolution - 1)
            const pos = cubic2d(s.p0, s.p1, s.p2, s.p3, t)
            const dist = math.distance(lastPos, pos)
            accDist += dist
            lastPos = pos
        }
        s.length = accDist
    })
}

function createSegmentsClosed(points, tangents) {
    const segments = []
    for (let pi = 0, ti = 0; pi < points.length - 1; pi++ , ti += 2) {
        const p0 = points[pi]
        const p1 = tangents[ti]
        const p2 = tangents[ti + 1]
        const p3 = points[pi + 1]
        segments.push({ p0, p1, p2, p3 })
    }
    const p0Last = points[points.length - 1]
    const p1Last = tangents[tangents.length - 2]
    const p2Last = tangents[tangents.length - 1]
    const p3Last = points[0]
    segments.push({ p0: p0Last, p1: p1Last, p2: p2Last, p3: p3Last })

    // console.dir(segments);
    return segments
}



function toDistributedPoints(segments, pointSpacing) {
    let lenTotal = 0
    for (let i = 0; i < segments.length; i++) {
        lenTotal += segments[i].length
    }
    const numPoints = Math.ceil(lenTotal / pointSpacing)

    console.log(lenTotal);
    console.log(`total length: ${lenTotal}, point count: ${numPoints}`);
    let points = []
    for (let i = 0; i < numPoints; i++) {
        const t = i / (numPoints - 1)
        const point = getDistributedPosition(segments, lenTotal, t)
        points.push(point)
    }
    return points
}

function getDistributedPosition(segments, lenTotal, t) {
    const lenTarget = lenTotal * t
    let i = 1
    let lenAcc = segments[0].length
    while (lenTarget > lenAcc) {
        lenAcc += segments[i].length
        i++
    }
    // console.log(i);
    const seg = segments[i - 1]

    const lenMin = lenAcc - seg.length
    const lenSegTarget = lenTarget - lenMin
    const segT = lenSegTarget / seg.length
    // console.log(segT);
    let val = bezier.cubic2d(seg.p0, seg.p1, seg.p2, seg.p3, segT)
    return val
}