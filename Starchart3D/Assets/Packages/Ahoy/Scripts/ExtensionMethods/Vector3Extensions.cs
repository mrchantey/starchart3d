using UnityEngine;


public static class Vector3Extensions
{
	public static int stride = sizeof(float) * 3;

	public static Vector2 XY(this Vector3 vec) { return new Vector2(vec.x, vec.y); }
	public static Vector2 XZ(this Vector3 vec) { return new Vector2(vec.x, vec.z); }
	public static Vector2 YZ(this Vector3 vec) { return new Vector2(vec.y, vec.z); }

	public static Vector2 YX(this Vector3 vec) { return new Vector2(vec.y, vec.x); }
	public static Vector2 ZX(this Vector3 vec) { return new Vector2(vec.z, vec.x); }
	public static Vector2 ZY(this Vector3 vec) { return new Vector2(vec.z, vec.y); }

	public static Vector3 ZeroX(this Vector3 vec) { return new Vector3(0, vec.y, vec.z); }
	public static Vector3 ZeroY(this Vector3 vec) { return new Vector3(vec.x, 0, vec.z); }
	public static Vector3 ZeroZ(this Vector3 vec) { return new Vector3(vec.x, vec.y, 0); }

	public static Vector3 Add(this Vector3 vec, float a) { return new Vector3(vec.x + a, vec.y + a, vec.z + a); }
	public static Vector3 Subtract(this Vector3 vec, float a) { return new Vector3(vec.x - a, vec.y - a, vec.z - a); }
	public static Vector3 Add(this Vector3 vec, Vector3 other) { return new Vector3(vec.x + other.x, vec.y + other.y, vec.z + other.z); }
	public static Vector3 Subtract(this Vector3 vec, Vector3 other) { return new Vector3(vec.x - other.x, vec.y - other.y, vec.z - other.z); }
	public static Vector3 Multiply(this Vector3 vec, Vector3 other) { return new Vector3(vec.x * other.x, vec.y * other.y, vec.z * other.z); }
	public static Vector3 Divide(this Vector3 vec, Vector3 other) { return new Vector3(vec.x / other.x, vec.y / other.y, vec.z / other.z); }

	public static Vector3 ClampElements(this Vector3 vec, float min, float max) { return new Vector3(Mathf.Clamp(vec.x, min, max), Mathf.Clamp(vec.y, min, max), Mathf.Clamp(vec.z, min, max)); }

	public static Vector3 Abs(this Vector3 vec) { return new Vector3(Mathf.Abs(vec.x), Mathf.Abs(vec.y), Mathf.Abs(vec.z)); }


	public static Vector3 RandomInsideExtents(this Vector3 vec)
	{
		return new Vector3(
						Random.Range(-vec.x, vec.x),
						Random.Range(-vec.y, vec.y),
						Random.Range(-vec.z, vec.z)
		);
	}
	// public static Vector3 ClampMagnitude(this Vector2 vec, float max)
	// {
	//     return new Vector3(vec.x, vec.y, 0);
	// }




	public static bool IsAlmostEqual(this Vector3 a, Vector3 b, double threshold = 0.0001)
	{
		return
		Mathf.Abs(b.x - a.x) < threshold &&
		Mathf.Abs(b.y - a.y) < threshold &&
		Mathf.Abs(b.z - a.z) < threshold;
	}

}
