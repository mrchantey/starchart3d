using UnityEngine;

namespace Ahoy
{

    public class IKSolverMono : InvocableMono
    {
        public bool debug;

        public Transform target;
        public Transform pointA;
        public Transform pointAMesh;
        public Transform pointB;
        public Transform pointBMesh;
        public Transform pointC;

        public IKSegment segA;
        public IKSegment segB;

        public IKSettings ikSettings;

        public bool threeDimensional;
        protected override void Start()
        {
            base.Start();
        }


        public override void Invoke()
        {
            pointAMesh.localScale = new Vector3(pointAMesh.localScale.x, pointAMesh.localScale.y, ikSettings.segment1Length);
            pointAMesh.localPosition = new Vector3(pointAMesh.localPosition.x, pointAMesh.localPosition.y, ikSettings.segment1Length / 2f);
            pointBMesh.localScale = new Vector3(pointBMesh.localScale.x, pointBMesh.localScale.y, ikSettings.segment2Length);
            pointBMesh.localPosition = new Vector3(pointBMesh.localPosition.x, pointBMesh.localPosition.y, ikSettings.segment2Length / 2f);


            segA.length = ikSettings.segment1Length;
            segB.length = ikSettings.segment2Length;
            IKSolver.SolveIK(ref segA, ref segB, ref pointA, ref pointB, ref pointC, target.position, ikSettings);
        }

        void OnDrawGizmos()
        {
            if (debug && target != null && pointA != null && pointB != null && pointC != null)
            {
                Vector3 scale = Vector3.one * 0.1f;
                Gizmos.color = Color.magenta;
                Gizmos.DrawWireCube(target.position, scale);

                Gizmos.color = Color.cyan;
                Gizmos.DrawWireCube(pointA.position, scale);
                Gizmos.DrawWireCube(pointB.position, scale);
                Gizmos.DrawWireCube(pointC.position, scale);
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(pointA.position, pointB.position);
                Gizmos.DrawLine(pointB.position, pointC.position);
            }
        }

    }

}