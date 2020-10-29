
using UnityEngine;


public static class FloatExtensions
{
    public static bool IsAlmostEqual(this float a, float b, double threshold = 0.0001)
    {
        return Mathf.Abs(b - a) < threshold;
    }
}