using UnityEngine;

namespace Ahoy
{
	public static class Math
	{
		public const float PI = 3.14159265359f;
		public const float TWO_PI = 6.28318530718f;
		public const float HALF_PI = 1.57079632679f;
		public const float QUARTER_PI = 0.78539816339f;
		public const float ONEANDHALF_PI = 4.71238898038f;
		public const float THREEQUARTER_PI = 2.35619449019f;

		public static (float theta, float radius) CartesianToPolar(Vector2 val)
		{
			return (Mathf.Atan2(val.y, val.x), val.magnitude);
		}
		public static (float theta, float radius) CartesianToPolar(float x, float y)
		{
			return (Mathf.Atan2(y, x), Mathf.Sqrt(x * x + y * y));
		}

		public static float Map(float val, float min1, float max1, float min2, float max2)
		{
			return (val - min1) / (max1 - min1) * (max2 - min2) + min2;
		}
		public static float Map01(float val, float min1, float max1)
		{
			return (val - min1) / (max1 - min1);
		}

		public static Vector3 Abs(Vector3 vec)
		{
			return new Vector3(Mathf.Abs(vec.x), Mathf.Abs(vec.y), Mathf.Abs(vec.z));
		}


		public static int Wrap(int i, int i_max)
		{
			return ((i % i_max) + i_max) % i_max;
		}
		public static float Wrap(float i, float i_max)
		{
			return ((i % i_max) + i_max) % i_max;
		}


		public static Vector2 PolarToCartesian(float theta, float radius = 1)
		{
			return new Vector2(
				Mathf.Cos(theta) * radius,
				Mathf.Sin(theta) * radius
			);
		}


		//dot 	= a.x * b.x + a.y * b.y
		//dot	= a.mag * b.mag * cos(theta)
		//cos(theta) = dot / (a.mag * b.mag)
		//theta = acos(dot / (a.mag * b.mag))
		public static float AngleBetween(Vector2 a, Vector2 b)
		{
			float dot = Vector2.Dot(a, b);
			float mag = a.magnitude * b.magnitude;
			return Mathf.Acos(dot / mag);
		}
		public static float AngleBetween(Vector3 a, Vector3 b)
		{
			float dot = Vector3.Dot(a, b);
			float mag = a.magnitude * b.magnitude;
			return Mathf.Acos(dot / mag);
		}

		public static float SignedAngleBetween(Vector2 a, Vector2 b)
		{
			float thetaA = Mathf.Atan2(a.y, a.x);
			float thetaB = Mathf.Atan2(b.y, b.x);
			float theta = thetaB - thetaA;
			if (theta > Mathf.PI)
				return theta - TWO_PI;
			else if (theta < -Mathf.PI)
				return theta + TWO_PI;
			else
				return theta;
		}

		public static float SignedDeltaAngle(Vector2 a, Vector2 b, Vector2 c)
		{
			var dAB = b - a;
			var dBC = c - b;
			return SignedAngleBetween(dAB, dBC);
		}


		//scalar projection
		//dan schiffman
		//https://youtu.be/_ENEsV_kNx8?list=PLRqwX-V7Uu6YHt0dtyf4uiw8tKOxQLvlW
		//this is computational shorthand for figuring out the answer using trigonometry
		public static Vector3 PointOnLine(Vector3 point, Vector3 lineA, Vector3 lineB)
		{
			var ac = point - lineA;//point = c
			var ab_n = (lineB - lineA).normalized;
			var d_len = Vector3.Dot(ac, ab_n);
			return lineA + ab_n * d_len;
		}
		public static Vector3 PointOnLine(Vector3 point, Pose linePose)
		{
			var ac = point - linePose.position;
			var d_len = Vector3.Dot(ac, linePose.forward);
			return linePose.position + linePose.forward * d_len;
		}
		public static Vector3 PointOnLine(Vector3 point, Pose linePose, out float linePos)
		{
			var ac = point - linePose.position;
			linePos = Vector3.Dot(ac, linePose.forward);
			return linePose.position + linePose.forward * linePos;
		}

		// public static bool PlaneIntersection(Ray ray, Vector3 planePos, Vector3 planeNormal, out Vector3 intersection)

		public static Vector3 PointOnPlane(Vector3 point, Vector3 planePos, Vector3 planeNormal)
		{
			var dPos = point - planePos;
			var dot1 = Vector3.Dot(dPos, planeNormal);
			var dot2 = Vector3.Dot(planeNormal, planeNormal);
			var dot3 = dot1 / dot2;
			return point - planeNormal * dot3;
			// Debug.Log($"plane intersection: 1: {dot1.ToString("0.00")}\t2: {dot2.ToString("0.00")}\t3: {dot3.ToString("0.0")}\tintersection: {intersection}");
		}

		//algorithm from https://rosettacode.org/wiki/Find_the_intersection_of_a_line_with_a_plane
		public static bool PlaneIntersection(Matrix4x4 ray, Matrix4x4 plane, out Vector3 intersection)
		{
			return PlaneIntersection(ray.GetPosition(), ray.GetForward(), plane.GetPosition(), plane.GetForward(), out intersection);
		}

		public static bool PlaneIntersection(Vector3 rayPos, Vector3 rayDir, Vector3 planePos, Vector3 planeNormal, out Vector3 intersection)
		{
			var dPos = rayPos - planePos;
			var dot1 = Vector3.Dot(dPos, planeNormal);
			var dot2 = Vector3.Dot(rayDir, planeNormal);
			if (dot2 == 0)
			{
				//ray is parrallel to plane
				intersection = Vector3.zero;
				return false;
			}
			var dot3 = dot1 / dot2;
			if (dot3 > 0)
			{
				//intersection is behind ray
				intersection = Vector3.zero;
				return false;
			}
			intersection = rayPos - rayDir * dot3;
			// Debug.Log($"plane intersection: 1: {dot1.ToString("0.00")}\t2: {dot2.ToString("0.00")}\t3: {dot3.ToString("0.0")}\tintersection: {intersection}");
			return true;
		}



		public static float PythagorasC(float a, float b)
		{
			return Mathf.Sqrt(a * a + b * b);
		}

		public static float TrigToaTheta(float x, float y)
		{
			return Mathf.Atan2(y, x);
		}
		/// <summary>
		/// Get Angle abc
		/// </summary>
		/// <param name="lenA"></param>
		/// <param name="lenB"></param>
		/// <param name="lenC"></param>
		/// <returns></returns>
		public static float LawOfCosinesABC(float lenA, float lenB, float lenC)
		{
			return Mathf.Acos((lenB * lenB - (lenA * lenA + lenC * lenC)) / (-2 * lenA * lenC));
		}
		public static float LawOfSinesA(float lenA, float lenB, float thetaB)
		{
			return Mathf.Asin((Mathf.Sin(thetaB) / lenB) * lenA);
		}

		//
		// <summary>
		//     convert three points to matrix, with orign at pointA, and up the direction between point a and b
		// </summary>
		public static (Matrix4x4 WorldToLocal, Matrix4x4 LocalToWorld) PointsToMatrix(Vector3 a, Vector3 b, Vector3 c)
		{
			Vector3 dirY = (b - a).normalized;
			Vector3 ab = b - a;
			Vector3 ac = c - a;
			float thetaBAC = AngleBetween(ab, ac);
			float ad = Mathf.Cos(thetaBAC) * ac.magnitude;
			Vector3 d = a + dirY * ad;
			Vector3 dc = c - d;
			Vector3 dirX = dc.normalized;
			Vector3 dirZ = Vector3.Cross(dirX, dirY).normalized;
			var matrix = new Matrix4x4(dirX, dirY, dirZ, new Vector4(a.x, a.y, a.z, 1));
			return (matrix.inverse, matrix);
		}

		public static Matrix4x4 Lerp(Matrix4x4 a, Matrix4x4 b, float t)
		{
			Matrix4x4 c = new Matrix4x4();
			for (int i = 0; i < 16; i++)
				c[i] = Mathf.Lerp(a[i], b[i], t);
			return c;
		}

		/*quadratic equation
        ax^2 + bx + c = 0

        solve X:
        x = (-b [+-]sqrt(b^2 - 4ac)) / 2a

        solve A:
        ax^2 = -bx -c
        a = (-bx - c) / (x^2)

        solve B:
        ax^2 + bx = -c
        bx = -ax^2 - c
        b = (-ax^2 - c) /x

        solve C:
        c = -ax^2 - bx
        */

		public static float QuadraticPositive(float a, float b, float c)
		{
			return (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
		}
		public static float QuadraticNegative(float a, float b, float c)
		{
			return (-b - Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
		}

		public static float QuadraticA(float b, float c, float x)
		{
			return (-b * x - c) / (x * x);
		}
		public static float QuadraticB(float a, float c, float x)
		{
			return (-a * x * x - c) / x;
		}
		public static float QuadraticC(float a, float b, float x)
		{
			return (-a * x * x - b * x);
		}

	}


}