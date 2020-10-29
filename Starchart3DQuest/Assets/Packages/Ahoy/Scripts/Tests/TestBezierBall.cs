// using UnityEngine;
// using System.Linq;

// namespace Ahoy
// {
// 	[RequireComponent(typeof(BezierMono))]
// 	public class TestBezierBall : InvocableMono
// 	{


// 		public Vector3 bounds = Vector3.one;
// 		[Range(3, 64)]
// 		public int numPoints = 4;
// 		[Range(0, 1)]
// 		public float radiusScalar = 0.5f;
// 		[Range(0, 1)]
// 		public float maxPointSpacing = 0.4f;

// 		public bool closed;

// 		public float speed = 1;
// 		Vector3[] points;

// 		public Transform ball;

// 		float totalLen;
// 		float pos;
// 		BezierSegment3D[] segments;

// 		public override void Invoke()
// 		{
// 			GeneratePoints3D();
// 		}
// 		void GeneratePoints3D()
// 		{
// 			GenerateRandomPoints();
// 			var bez = GetComponent<BezierMono>();
// 			segments = bez.GenerateSegments(points, closed, radiusScalar);
// 			bez.GenerateSpacedPoints(maxPointSpacing);
// 			totalLen = Bezier3D.GetTotalLength(segments);
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

// 		protected override void Update()
// 		{
// 			base.Update();
// 			pos += Time.deltaTime * speed;
// 			float t = (pos % totalLen) / totalLen;
// 			var worldPos = Bezier3D.CreateDistributedPoint(segments, totalLen, t);
// 			ball.position = worldPos;
// 		}


// 		private void OnDrawGizmos()
// 		{
// 			Gizmos.color = Color.yellow;
// 			Gizmos.DrawWireCube(Vector3.zero, bounds);
// 		}

// 	}

// }