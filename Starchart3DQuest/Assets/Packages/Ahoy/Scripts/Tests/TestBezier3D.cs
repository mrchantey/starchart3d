// using UnityEngine;
// using System.Linq;

// namespace Ahoy
// {
// 	[RequireComponent(typeof(BezierMono))]
// 	public class TestBezier3D : InvocableMono
// 	{


// 		public Vector3 bounds = Vector3.one;
// 		[Range(3, 64)]
// 		public int numPoints = 4;
// 		[Range(0, 1)]
// 		public float radiusScalar = 0.5f;
// 		[Range(0, 1)]
// 		public float maxPointSpacing = 0.4f;

// 		public bool closed;
// 		Vector3[] points;

// 		public override void Invoke()
// 		{
// 			GeneratePoints3D();
// 		}

// 		void GenerateRandomPoints()
// 		{
// 			if (points == null || points.Length != numPoints)
// 			{
// 				var hBounds = bounds * 0.5f;
// 				points = new Vector3[numPoints];
// 				points = points.Select(p => hBounds.RandomInsideExtents()).ToArray();
// 			}
// 		}

// 		void GeneratePoints3D()
// 		{
// 			GenerateRandomPoints();
// 			GetComponent<BezierMono>().GenerateSegments(points, closed, radiusScalar);
// 			GetComponent<BezierMono>().GenerateSpacedPoints(maxPointSpacing);
// 		}

// 		private void OnDrawGizmos()
// 		{
// 			Gizmos.color = Color.yellow;
// 			Gizmos.DrawWireCube(Vector3.zero, bounds);
// 		}

// 	}

// }