// using UnityEngine;
// using System.Linq;

// namespace Ahoy
// {

// 	public class TestBezier2D : InvocableMono
// 	{


// 		public Vector3 bounds = new Vector3(1, 1, 0);
// 		[Range(3, 64)]
// 		public int numPoints = 4;
// 		[Range(0, 1)]
// 		public float radiusScalar = 0.5f;
// 		[Range(0, 1)]
// 		public float maxPointSpacing = 0.4f;

// 		public bool closed;
// 		Vector2[] points;
// 		BezierSegment2D[] segments;
// 		Vector2[] spacedPoints;

// 		public override void Invoke()
// 		{

// 			GeneratePoints2D();
// 		}
// 		void GenerateRandomPoints()
// 		{
// 			if (points == null || points.Length != numPoints)
// 			{
// 				var hBounds = bounds * 0.5f;
// 				points = new Vector2[numPoints];

// 				for (int i = 0; i < numPoints; i++)
// 				{
// 					points[i] = new Vector3(
// 						Random.Range(-hBounds.x, hBounds.x),
// 						Random.Range(-hBounds.y, hBounds.y));
// 				}
// 			}
// 		}
// 		void GeneratePoints2D()
// 		{
// 			GenerateRandomPoints();
// 			if (closed)
// 				segments = Bezier2D.CreateBezierSegmentsClosed(points, radiusScalar);
// 			else
// 				segments = Bezier2D.CreateBezierSegmentsOpen(points, radiusScalar);
// 			spacedPoints = Bezier2D.CreateDistributedPoints(segments, maxPointSpacing);
// 			Debug.Log($"segment count: {segments.Length}, points count: {spacedPoints.Length}");
// 			Debug.Log(segments.ElementsToString("\n"));
// 		}


// 		private void OnDrawGizmos()
// 		{
// 			Gizmos.color = Color.yellow;
// 			Gizmos.DrawWireCube(Vector3.zero, bounds);
// 			float r = 0.01f;
// 			if (segments != null)
// 			{
// 				segments.ForEach(s =>
// 				{
// 					Gizmos.color = Color.magenta;
// 					Gizmos.DrawWireSphere(s.p0, r);
// 					Gizmos.DrawWireSphere(s.p3, r);
// 					Gizmos.color = Color.cyan;
// 					Gizmos.DrawWireSphere(s.p1, r);
// 					Gizmos.DrawWireSphere(s.p2, r);
// 				});
// 				Gizmos.color = Color.yellow;
// 				Gizmos.DrawWireSphere(segments[0].p0, r);
// 				Gizmos.color = Color.green;
// 				Gizmos.DrawWireSphere(segments[1].p0, r);
// 			}
// 			if (spacedPoints != null)
// 			{
// 				Gizmos.color = Color.white;
// 				for (int i = 0; i < spacedPoints.Length - 1; i++)
// 				{
// 					int ii = i + 1;
// 					Gizmos.DrawLine(spacedPoints[i], spacedPoints[ii]);
// 				}
// 				if (closed)
// 					Gizmos.DrawLine(spacedPoints[spacedPoints.Length - 1], spacedPoints[0]);
// 			}
// 		}
// 	}

// }
