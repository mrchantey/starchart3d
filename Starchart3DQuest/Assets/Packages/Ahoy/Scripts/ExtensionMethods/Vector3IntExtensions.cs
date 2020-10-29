using UnityEngine;
using System;

public static class Vector3IntExtensions
{
	public static int SumSelf(this Vector3Int vec)
	{
		return vec.x + vec.y + vec.z;
	}

	public static int MultiplySelf(this Vector3Int vec)
	{
		return vec.x * vec.y * vec.z;
	}

	public static void ForEachXYZ(this Vector3Int vec, Action<int, int, int> action)
	{
		for (int x = 0; x < vec.x; x++)
		{
			for (int y = 0; y < vec.y; y++)
			{
				for (int z = 0; z < vec.z; z++)
				{
					action(x, y, z);
				}
			}
		}
	}

	public static Vector3Int Add(this Vector3Int vec, int a)
	{
		return new Vector3Int(vec.x + a, vec.y + a, vec.z + a);
	}
	public static Vector3Int Subtract(this Vector3Int vec, int a)
	{
		return new Vector3Int(vec.x - a, vec.y - a, vec.z - a);
	}

	public static Vector3Int Multiply(this Vector3Int vec, Vector3Int other)
	{
		return new Vector3Int(vec.x * other.x, vec.y * other.y, vec.z * other.z);
	}
	public static Vector3Int DivideToInt(this Vector3Int vec, Vector3Int other)
	{
		return new Vector3Int(vec.x / other.x, vec.y / other.y, vec.z / other.z);
	}
	public static Vector3 Multiply(this Vector3Int vec, float a)
	{
		return new Vector3(vec.x * a, vec.y * a, vec.z * a);
	}
	public static Vector3Int Clamp(this Vector3Int vec, int min, int max)
	{
		return new Vector3Int(
			Mathf.Min(Mathf.Max(vec.x, min), max),
			Mathf.Min(Mathf.Max(vec.y, min), max),
			Mathf.Min(Mathf.Max(vec.z, min), max));
	}


}
