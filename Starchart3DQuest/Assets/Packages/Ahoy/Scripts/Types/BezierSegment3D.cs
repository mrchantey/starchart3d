using UnityEngine;

namespace Ahoy
{
	[System.Serializable]
	public struct BezierSegment3D
	{
		public Vector3 p0;
		public Vector3 p1;
		public Vector3 p2;
		public Vector3 p3;
		public float length;
		public BezierSegment3D(Vector3 _p0, Vector3 _p1, Vector3 _p2, Vector3 _p3)
		{
			p0 = _p0;
			p1 = _p1;
			p2 = _p2;
			p3 = _p3;

			length = CalculateSegmentLength(p0, p1, p2, p3);
		}

		public static float CalculateSegmentLength(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			Vector3 lastPos = p0;
			float accDist = 0;
			for (int i = 1; i < Bezier.SegmentLengthResolution; i++)
			{
				float t = (float)i / (Bezier.SegmentLengthResolution - 1);
				Vector3 pos = Bezier3D.Cubic(p0, p1, p2, p3, t);
				float dist = Vector3.Distance(lastPos, pos);
				accDist += dist;
				lastPos = pos;
			}
			return accDist;
		}

		public override string ToString()
		{
			return $"p0: {p0},p1: {p1},p2: {p2},p3: {p3},length: {length}";
		}
	}

}