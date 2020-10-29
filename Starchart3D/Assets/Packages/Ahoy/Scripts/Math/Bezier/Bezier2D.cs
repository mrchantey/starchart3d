using UnityEngine;
namespace Ahoy
{

	public static class Bezier2D
	{
		public static Vector2 Linear(Vector2 p0, Vector2 p1, float t)
		{
			return new Vector2(
			Bezier.Linear(p0.x, p1.x, t),
			Bezier.Linear(p0.y, p1.y, t));
		}

		public static Vector2 Quadratic(Vector2 p0, Vector2 p1, Vector2 p2, float t)
		{
			return new Vector2(
			Bezier.Quadratic(p0.x, p1.x, p2.x, t),
			Bezier.Quadratic(p0.y, p1.y, p2.y, t));
		}

		public static Vector2 Cubic(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
		{
			return new Vector2(
			Bezier.Cubic(p0.x, p1.x, p2.x, p3.x, t),
			Bezier.Cubic(p0.y, p1.y, p2.y, p3.y, t));
		}


		// public static float CalculateSegmentLength(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
		// {
		// 	Vector2 lastPos = p0;
		// 	float accDist = 0;
		// 	for (int i = 1; i < Bezier.SegmentLengthResolution; i++)
		// 	{
		// 		float t = (float)i / (Bezier.SegmentLengthResolution - 1);
		// 		Vector2 pos = Cubic(p0, p1, p2, p3, t);
		// 		float dist = Vector2.Distance(lastPos, pos);
		// 		accDist += dist;
		// 		lastPos = pos;
		// 	}
		// 	return accDist;
		// }

		// public static BezierSegment2D[] CreateBezierSegmentsOpen(Vector2[] points, float radiusScalar = 0.5f)
		// {
		// 	if (points.Length < 3)
		// 	{
		// 		Debug.LogWarning($"Ahoy Bezier - point count must be at least 3");
		// 		return null;
		// 	}
		// 	var segments = new BezierSegment2D[points.Length - 1];
		// 	var tangents = CreateTangentsOpen(points, radiusScalar);

		// 	for (int pi = 0, ti = 0; pi < points.Length - 1; pi++, ti += 2)
		// 	{
		// 		segments[pi] = new BezierSegment2D(
		// 		points[pi],
		// 		tangents[ti],
		// 		tangents[ti + 1],
		// 		points[pi + 1]);
		// 	}
		// 	return segments;
		// }

		// static Vector2[] CreateTangentsOpen(Vector2[] points, float radiusScalar)
		// {
		// 	var tangents = new Vector2[(points.Length - 1) * 2];

		// 	var quadFirst = CreateTangent(points[points.Length - 1], points[0], points[1], radiusScalar);
		// 	var quadLast = CreateTangent(points[points.Length - 2], points[points.Length - 1], points[0], radiusScalar);

		// 	for (int pi = 0, ti = 1; pi < points.Length - 2; pi++, ti += 2)
		// 	{
		// 		var quad = CreateTangent(points[pi], points[pi + 1], points[pi + 2], radiusScalar);
		// 		tangents[ti] = quad.point1;
		// 		tangents[ti + 1] = quad.point2;
		// 	}

		// 	tangents[0] = tangents[1];
		// 	tangents[tangents.Length - 1] = tangents[tangents.Length - 2];

		// 	return tangents;
		// }


		// public static BezierSegment2D[] CreateBezierSegmentsClosed(Vector2[] points, float radiusScalar = 0.5f)
		// {
		// 	if (points.Length < 3)
		// 	{
		// 		Debug.LogWarning($"Ahoy Bezier - point count must be at least 3");
		// 		return null;
		// 	}
		// 	var tangents = CreateTangentsClosed(points, radiusScalar);
		// 	var segments = new BezierSegment2D[points.Length];

		// 	for (int pi = 0, ti = 0; pi < points.Length - 1; pi++, ti += 2)
		// 	{
		// 		segments[pi] = new BezierSegment2D(
		// 		points[pi],
		// 		tangents[ti],
		// 		tangents[ti + 1],
		// 		points[pi + 1]);
		// 	}
		// 	segments[segments.Length - 1] = new BezierSegment2D(
		// 		points[points.Length - 1],
		// 		tangents[tangents.Length - 2],
		// 		tangents[tangents.Length - 1],
		// 		points[0]);
		// 	return segments;
		// }

		// static Vector2[] CreateTangentsClosed(Vector2[] points, float radiusScalar)
		// {
		// 	var tangents = new Vector2[points.Length * 2];

		// 	var quadFirst = CreateTangent(points[points.Length - 1], points[0], points[1], radiusScalar);
		// 	var quadLast = CreateTangent(points[points.Length - 2], points[points.Length - 1], points[0], radiusScalar);

		// 	tangents[0] = quadFirst.point2;
		// 	tangents[tangents.Length - 3] = quadLast.point1;
		// 	tangents[tangents.Length - 2] = quadLast.point2;
		// 	tangents[tangents.Length - 1] = quadFirst.point1;

		// 	for (int pi = 0, ti = 1; pi < points.Length - 2; pi++, ti += 2)
		// 	{
		// 		var quad = CreateTangent(points[pi], points[pi + 1], points[pi + 2], radiusScalar);
		// 		tangents[ti] = quad.point1;
		// 		tangents[ti + 1] = quad.point2;
		// 	}

		// 	return tangents;
		// }

		public static (Vector2 point1, Vector2 point2) CreateTangent(Vector2 p0, Vector2 p1, Vector2 p2, float radiusScalar = 0.5f)
		{

			Vector2 p0_1 = p1 - p0;
			var polar0_1 = Math.CartesianToPolar(p0_1);

			float theta0_1_2 = Math.SignedDeltaAngle(p0, p1, p2);

			float tangentTheta1_2 = polar0_1.theta + theta0_1_2 / 2;
			float tangentTheta0_1 = tangentTheta1_2 + Math.PI;

			//radius is not satisfactory, need a new formula
			//values higher than 0.5 will cause 'knotting'
			float tangentRadius0_1 = Vector2.Distance(p0, p1) * radiusScalar;
			float tangentRadius1_2 = Vector2.Distance(p1, p2) * radiusScalar;

			Vector2 tangent0_1 = p1 + Math.PolarToCartesian(tangentTheta0_1, tangentRadius0_1);
			Vector2 tangent1_2 = p1 + Math.PolarToCartesian(tangentTheta1_2, tangentRadius1_2);

			return (tangent0_1, tangent1_2);
		}

		// public static Vector2[] CreateDistributedPoints(BezierSegment2D[] segments, float maxPointSpacing)
		// {
		// 	if (segments == null || segments.Length < 1)
		// 	{
		// 		Debug.LogWarning($"Ahoy Bezier - segment count must be at least 1");
		// 		return null;
		// 	}
		// 	float lenTotal = 0;
		// 	for (int i = 0; i < segments.Length; i++)
		// 	{
		// 		lenTotal += segments[i].length;
		// 	}
		// 	int numPoints = Mathf.CeilToInt(lenTotal / maxPointSpacing);
		// 	if (numPoints > 5000 || numPoints < 1)
		// 	{
		// 		Debug.LogWarning($"Ahoy Bezier - max point count reached - 5000");
		// 		numPoints = 5000;
		// 	}

		// 	var points = new Vector2[numPoints];
		// 	for (int i = 0; i < numPoints; i++)
		// 	{
		// 		float t = (float)i / (numPoints - 1);
		// 		points[i] = CreateDistributedPoint(segments, lenTotal, t);
		// 	}
		// 	return points;


		// }

		// static Vector2 CreateDistributedPoint(BezierSegment2D[] segments, float lenTotal, float t)
		// {
		// 	float lenTarget = lenTotal * t;
		// 	int i = 1;
		// 	float lenAcc = segments[0].length;
		// 	while (lenTarget > lenAcc)
		// 	{
		// 		lenAcc += segments[i].length;
		// 		i++;
		// 	}
		// 	var seg = segments[i - 1];
		// 	float lenMin = lenAcc - seg.length;
		// 	float lenSegTarget = lenTarget - lenMin;
		// 	float segT = lenSegTarget / seg.length;
		// 	Vector2 val = Cubic(seg.p0, seg.p1, seg.p2, seg.p3, segT);
		// 	return val;
		// }


	}

}