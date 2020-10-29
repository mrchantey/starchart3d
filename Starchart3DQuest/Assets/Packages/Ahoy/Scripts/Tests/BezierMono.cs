// using UnityEngine;

// namespace Ahoy
// {

// 	public class BezierMono : MonoBehaviour
// 	{
// 		public bool debug;

// 		BezierSegment3D[] segments;
// 		Vector3[] spacedPoints;

// 		bool closed;

// 		public BezierSegment3D[] GenerateSegments(Vector3[] points, bool closed = false, float radiusScalar = 0.5f)
// 		{
// 			this.closed = closed;
// 			if (closed)
// 				segments = Bezier3D.CreateBezierSegmentsClosed(points, radiusScalar);
// 			else
// 				segments = Bezier3D.CreateBezierSegmentsOpen(points, radiusScalar);
// 			if (debug)
// 				Debug.Log($"segment count: {segments.Length}\n{segments.ElementsToString("\n")}");
// 			return segments;
// 		}

// 		public Vector3[] GenerateSpacedPoints(float maxPointSpacing = 0.1f)
// 		{
// 			spacedPoints = Bezier3D.CreateDistributedPoints(segments, maxPointSpacing);
// 			if (debug)
// 				Debug.Log($" points count: {spacedPoints.Length}");
// 			return spacedPoints;
// 		}


// 		void OnDrawGizmos()
// 		{

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
// 				Gizmos.DrawWireSphere(segments[segments.Length - 1].p3, r);
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