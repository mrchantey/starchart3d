using UnityEngine;
using System.Linq;


namespace Ahoy
{


    public static class Bezier
    {
        public static readonly int SegmentLengthResolution = 100;

        public static float Linear(float p0, float p1, float t)
        {
            return p0 + t * (p1 - p0);
        }

        public static float Quadratic(float p0, float p1, float p2, float t)
        {
            return p1
                + Mathf.Pow((1 - t), 2) * (p0 - p1)
                + Mathf.Pow(t, 2) * (p2 - p1);
        }

        public static float Cubic(float p0, float p1, float p2, float p3, float t)
        {
            float it = 1 - t;
            return Mathf.Pow(it, 3) * p0
            + 3 * Mathf.Pow(it, 2) * t * p1
            + 3 * it * Mathf.Pow(t, 2) * p2
            + Mathf.Pow(t, 3) * p3;
        }


    }
}












