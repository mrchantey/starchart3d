using UnityEngine;
// using System;
namespace Ahoy
{
	using TangentsFunc = System.Func<Vector3[], Vector3[], float>;

	public static class Bezier3D
	{
		public static Vector3 Linear(Vector3 p0, Vector3 p1, float t)
		{
			return new Vector3(
			Bezier.Linear(p0.x, p1.x, t),
			Bezier.Linear(p0.y, p1.y, t),
			Bezier.Linear(p0.z, p1.z, t));
		}
		public static Vector3 Quadratic(Vector3 p0, Vector3 p1, Vector3 p2, float t)
		{
			return new Vector3(
			Bezier.Quadratic(p0.x, p1.x, p2.x, t),
			Bezier.Quadratic(p0.y, p1.y, p2.y, t),
			Bezier.Quadratic(p0.z, p1.z, p2.z, t));
		}
		public static Vector3 Cubic(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			return new Vector3(
			Bezier.Cubic(p0.x, p1.x, p2.x, p3.x, t),
			Bezier.Cubic(p0.y, p1.y, p2.y, p3.y, t),
			Bezier.Cubic(p0.z, p1.z, p2.z, p3.z, t));
		}
		public static Vector3 Cubic(BezierSegment3D seg, float t)
		{
			return new Vector3(
			Bezier.Cubic(seg.p0.x, seg.p1.x, seg.p2.x, seg.p3.x, t),
			Bezier.Cubic(seg.p0.y, seg.p1.y, seg.p2.y, seg.p3.y, t),
			Bezier.Cubic(seg.p0.z, seg.p1.z, seg.p2.z, seg.p3.z, t));
		}

		public static BezierSegment3D[] SegmentsFromPoses(Pose[] poses, float radiusScalar)
		{
			if (poses.Length < 2)
				return new BezierSegment3D[0];
			var segments = new BezierSegment3D[poses.Length - 1];
			for (int i = 0; i < poses.Length - 1; i++)
			{
				segments[i] = SegmentFromPoses(poses[i], poses[i + 1], radiusScalar);
			}
			return segments;
		}

		static BezierSegment3D SegmentFromPoses(Pose poseA, Pose poseB, float radiusScalar)
		{
			var p0 = poseA.position;
			var p3 = poseB.position;
			float dist = Vector3.Distance(p0, p3);
			var p1 = poseA.position + poseA.forward * dist * radiusScalar;
			var p2 = poseB.position + -poseB.forward * dist * radiusScalar;
			return new BezierSegment3D(p0, p1, p2, p3);
		}

		public static BezierSegment3D[] SegmentsFromPoints(Vector3[] points, float radiusScalar, bool closed = false)
		{
			if (points.Length < 3)
			{
				// Debug.LogWarning($"Ahoy Bezier - point count must be at least 3");
				return new BezierSegment3D[0];
			}
			int numSegments = closed ? points.Length : points.Length - 1;
			BezierSegment3D[] segments = new BezierSegment3D[numSegments];
			Vector3[] tangents = closed ?
				CreateTangentsClosed(points, radiusScalar) :
				CreateTangentsOpen(points, radiusScalar);

			for (int pi = 0, ti = 0; pi < points.Length - 1; pi++, ti += 2)
			{
				segments[pi] = new BezierSegment3D(
				points[pi],
				tangents[ti],
				tangents[ti + 1],
				points[pi + 1]);
			}
			if (closed)
			{
				segments[segments.Length - 1] = new BezierSegment3D(
				points[points.Length - 1],
				tangents[tangents.Length - 2],
				tangents[tangents.Length - 1],
				points[0]);
			}
			return segments;
		}

		static Vector3[] CreateTangentsOpen(Vector3[] points, float radiusScalar)
		{
			var tangents = new Vector3[(points.Length - 1) * 2];

			var quadFirst = CreateTangent(points[points.Length - 1], points[0], points[1], radiusScalar);
			var quadLast = CreateTangent(points[points.Length - 2], points[points.Length - 1], points[0], radiusScalar);

			for (int pi = 0, ti = 1; pi < points.Length - 2; pi++, ti += 2)
			{
				var quad = CreateTangent(points[pi], points[pi + 1], points[pi + 2], radiusScalar);
				tangents[ti] = quad.point1;
				tangents[ti + 1] = quad.point2;
			}

			tangents[0] = tangents[1];
			tangents[tangents.Length - 1] = tangents[tangents.Length - 2];

			return tangents;
		}

		static Vector3[] CreateTangentsClosed(Vector3[] points, float radiusScalar)
		{
			var tangents = new Vector3[points.Length * 2];

			var quadFirst = CreateTangent(points[points.Length - 1], points[0], points[1], radiusScalar);
			var quadLast = CreateTangent(points[points.Length - 2], points[points.Length - 1], points[0], radiusScalar);

			tangents[0] = quadFirst.point2;
			tangents[tangents.Length - 3] = quadLast.point1;
			tangents[tangents.Length - 2] = quadLast.point2;
			tangents[tangents.Length - 1] = quadFirst.point1;

			for (int pi = 0, ti = 1; pi < points.Length - 2; pi++, ti += 2)
			{
				var quad = CreateTangent(points[pi], points[pi + 1], points[pi + 2], radiusScalar);
				tangents[ti] = quad.point1;
				tangents[ti + 1] = quad.point2;
			}

			return tangents;
		}

		public static (Vector3 point1, Vector3 point2) CreateTangent(Vector3 p0, Vector3 p1, Vector3 p2, float radiusScalar = 0.5f)
		{
			//where p1 is origin and p1-p2 is y axis
			//the z axis is ignored
			var matrix = Math.PointsToMatrix(p1, p2, p0);
			Vector3 p0_2 = matrix.WorldToLocal.MultiplyPoint3x4(p0);
			Vector3 p1_2 = matrix.WorldToLocal.MultiplyPoint3x4(p1);
			Vector3 p2_2 = matrix.WorldToLocal.MultiplyPoint3x4(p2);

			var tangents = Bezier2D.CreateTangent(p0_2, p1_2, p2_2, radiusScalar);

			var tangent0_1 = matrix.LocalToWorld.MultiplyPoint3x4(tangents.point1);
			var tangent1_2 = matrix.LocalToWorld.MultiplyPoint3x4(tangents.point2);

			return (tangent0_1, tangent1_2);
		}

		public static float GetTotalLength(BezierSegment3D[] segments)
		{
			float lenTotal = 0;
			for (int i = 0; i < segments.Length; i++)
			{
				lenTotal += segments[i].length;
			}
			return lenTotal;
		}

		public static Vector3[] CreateDistributedPoints(BezierSegment3D[] segments, float maxDeltaPosition = 0.1f)
		{
			if (segments == null || segments.Length < 1)
				return new Vector3[0];
			// Debug.LogWarning($"Ahoy Bezier - segment count must be at least 1");
			// return null;
			float lenTotal = GetTotalLength(segments);
			int numPoints = Mathf.CeilToInt(lenTotal / maxDeltaPosition);
			if (numPoints > 5000 || numPoints < 1)
			{
				Debug.LogWarning($"Ahoy Bezier - max point count reached - 5000");
				numPoints = 5000;
			}

			var points = new Vector3[numPoints];
			for (int i = 0; i < numPoints; i++)
			{
				float t = (float)i / (numPoints - 1);
				points[i] = CreateDistributedPoint(segments, lenTotal, t);
			}
			return points;
		}

		public static Vector3[] CreateDistributedPoints(BezierSegment3D segment, float maxDeltaPosition = 0.1f)
		{
			int numPoints = Mathf.CeilToInt(segment.length / maxDeltaPosition);
			if (numPoints > 5000 || numPoints < 1)
			{
				Debug.LogWarning($"Ahoy Bezier - max point count reached - 5000");
				numPoints = 5000;
			}

			var points = new Vector3[numPoints];
			for (int i = 0; i < numPoints; i++)
			{
				float t = (float)i / (numPoints - 1);
				points[i] = Cubic(segment, t);
			}
			return points;
		}

		public static Vector3 CreateDistributedPoint(BezierSegment3D[] segments, float lenTotal, float t)
		{
			float lenTarget = lenTotal * t;
			int i = 1;
			float lenAcc = segments[0].length;
			while (lenTarget > lenAcc)
			{
				lenAcc += segments[i].length;
				i++;
			}
			var seg = segments[i - 1];
			float lenMin = lenAcc - seg.length;
			float lenSegTarget = lenTarget - lenMin;
			float segT = lenSegTarget / seg.length;
			Vector3 val = Cubic(seg, segT);
			return val;
		}

	}
}