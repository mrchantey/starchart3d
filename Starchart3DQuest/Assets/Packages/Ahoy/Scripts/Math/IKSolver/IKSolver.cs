using UnityEngine;
using System.Linq;


namespace Ahoy
{


    public static class IKSolver
    {


        public static void SolveIK(ref IKSegment segA, ref IKSegment segB, ref Transform pointA, ref Transform pointB, ref Transform pointC, Vector3 target, IKSettings settings)
        {
            Vector3 pA = pointA.position;
            Vector3 pB = pointB.position;
            Vector3 pC = pointC.position;
            SolveIK(ref segA, ref segB, ref pA, ref pB, ref pC, target, settings);
            pointB.position = pB;
            pointC.position = pC;

            var dirAC = (pC - pA).normalized;
            var dirAB = (pB - pA).normalized;
            var dirBC = (pC - pB).normalized;
            pointA.rotation = Quaternion.LookRotation(dirAB, dirAC);
            pointB.rotation = Quaternion.LookRotation(dirBC, dirAC);
        }

        public static void SolveIK(ref IKSegment segA, ref IKSegment segB, ref Vector3 pointA, ref Vector3 pointB, ref Vector3 pointC, Vector3 target, IKSettings settings)
        {
            var dir = target - pointA;
            var dirXZ = new Vector3(dir.x, 0, dir.z).normalized;
            var rotation = Quaternion.LookRotation(dirXZ, Vector3.up);
            var matrix = Matrix4x4.TRS(pointA, rotation, Vector3.one);
            var localTarget = matrix.inverse.MultiplyPoint3x4(target);
            SolveIK(ref segA, ref segB, localTarget.z, localTarget.y, settings);
            pointB = matrix.MultiplyPoint3x4(new Vector3(0, segA.pointB.y, segA.pointB.x));
            pointC = matrix.MultiplyPoint3x4(new Vector3(0, segB.pointB.y, segB.pointB.x));
        }



        public static void SolveIK(ref IKSegment segA, ref IKSegment segB, float x, float y, IKSettings settings)
        {
            var c2 = segA.length;
            var c3 = segB.length;
            var maxExtents = c2 + c3;

            var c1Raw = Math.PythagorasC(x, y);
            //if c1 raw is greater than c2 + c3, segment is out of range
            var c1Max = Mathf.Min(c2 + c3, c1Raw);
            //clamp max length by scalar of max extents
            var c1 = Mathf.Clamp(c1Max, maxExtents * settings.extentsLimits.x, maxExtents * settings.extentsLimits.y);


            var b1 = Math.TrigToaTheta(x, y);
            var b4 = Math.LawOfCosinesABC(c2, c3, c1);

            var a4 = Math.LawOfSinesA(c2, c3, b4);
            var c4 = Math.PI - a4 - b4;

            //b2 is adjacent to b4
            var b2 = b1 - b4;
            var b3 = Math.PI - c4;

            segA.SetPointBFromAngle(b2);
            segB.pointA = segA.pointB;
            //world angle for segB
            segB.SetPointBFromAngle(b2 + b3);
            // Debug.Log($"ik debug: c1: {c1.ToString("0.0")}\tb1: {b1.ToString("0.0")}\tb2: {b2.ToString("0.0")}\tb3: {b3.ToString("0.0")}\tb4 :{b4.ToString("0.0")}");
        }


    }
}












