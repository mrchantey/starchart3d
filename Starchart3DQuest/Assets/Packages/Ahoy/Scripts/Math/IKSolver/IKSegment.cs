using UnityEngine;


namespace Ahoy
{
    [System.Serializable]
    public class IKSegment
    {
        public float length = 1;
        public Vector2 pointA;
        public Vector2 pointB;
        public float theta;

        public void SetPointBFromAngle(float theta)
        {
            pointB = pointA + Math.PolarToCartesian(theta, length);

        }

    }

}