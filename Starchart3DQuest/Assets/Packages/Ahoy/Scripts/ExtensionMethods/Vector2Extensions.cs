using UnityEngine;

public static class Vector2Extensions
{

    public static Vector3 ToVector3XY(this Vector2 vec) { return new Vector3(vec.x, vec.y, 0); }
    public static Vector3 ToVector3XZ(this Vector2 vec) { return new Vector3(vec.x, 0, vec.y); }


    public static Vector2 Perpendicular(this Vector2 vec) { return new Vector2(-vec.y, vec.x); }
    public static float Angle(this Vector2 vec) { return Mathf.Atan2(vec.y, vec.x); }


    public static bool IsAlmostEqual(this Vector2 a, Vector2 b, double threshold = 0.0001)
    {
        return
        Mathf.Abs(b.x - a.x) < threshold &&
        Mathf.Abs(b.y - a.y) < threshold;
    }

}