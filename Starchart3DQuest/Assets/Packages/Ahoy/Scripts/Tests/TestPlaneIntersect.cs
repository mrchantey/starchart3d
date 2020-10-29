using UnityEngine;

namespace Ahoy
{

    public class TestPlaneIntersect : InvocableMono
    {

        public Transform ray;
        public Transform plane;

        Vector3 rayIntersect;
        Vector3 pointIntersect;

        public override void Invoke()
        {
            pointIntersect = Math.PointOnPlane(ray.position, plane.position, plane.forward);
            if (Math.PlaneIntersection(ray.localToWorldMatrix, plane.localToWorldMatrix, out rayIntersect))
            {
            }
            else
            {
                rayIntersect = Vector3.zero;
                Debug.Log($"line never intersects plane");
            }


        }


        void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(ray.position, rayIntersect);
            Gizmos.DrawSphere(rayIntersect, 0.2f);
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(pointIntersect, 0.2f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(rayIntersect + plane.right * -10, rayIntersect + plane.right * 10);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(rayIntersect + plane.up * -10, rayIntersect + plane.up * 10);
        }


    }
}