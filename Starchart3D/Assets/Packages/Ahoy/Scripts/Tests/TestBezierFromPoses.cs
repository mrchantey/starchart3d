// using UnityEngine;

// namespace Ahoy
// {

// 	public class TestBezierFromPoses : InvocableMono
// 	{

// 		public Transform tranA;
// 		public Transform tranB;
// 		[Range(0, 1)]
// 		public float radiusScalar = 0.5f;
// 		public Vector3[] path;

// 		public float speed = 1f;
// 		float bPos = 0;
// 		BezierSegment3D[] segments;
// 		public override void Invoke()
// 		{
// 			var seg = Bezier3D.SegmentFromPoses(tranB.Pose(), tranA.Pose(), radiusScalar);
// 			segments = new BezierSegment3D[] { seg };
// 			path = Bezier3D.CreateDistributedPoints(segments);
// 			bPos = 0;
// 		}

// 		protected override void Update()
// 		{
// 			base.Update();
// 			if (segments == null)
// 				return;
// 			bPos += speed * Time.deltaTime;
// 			var t = bPos / segments[0].length;
// 			var nextPos = Bezier3D.CreateDistributedPoint(segments, segments[0].length, t);
// 			tranB.position = nextPos;
// 		}

// 		public void OnDrawGizmos()
// 		{
// 			if (path == null || segments == null || segments.Length == 0)
// 				return;
// 			Gizmos.color = Color.white;
// 			for (int i = 0; i < path.Length - 1; i++)
// 			{
// 				Gizmos.DrawLine(path[i], path[i + 1]);
// 			}
// 			if (segments == null)
// 				return;
// 			Gizmos.DrawWireSphere(segments[0].p1, 0.1f);
// 			Gizmos.DrawWireSphere(segments[0].p2, 0.1f);
// 		}

// 	}
// }