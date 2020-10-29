using UnityEngine;

namespace Ahoy
{

    public class LineTransform : InvocableMono
    {

        public Transform targetA;
        public Transform targetB;


        public override void Invoke()
        {
            var a = targetA.position;
            var b = targetB.position;
            var deltaAB = b - a;
            var dirAB = deltaAB.normalized;
            var avgAB = (b + a) / 2;
            var distAB = deltaAB.magnitude;
            transform.position = avgAB;
            transform.rotation = Quaternion.LookRotation(dirAB, Vector3.up);
            transform.localScale = new Vector3(1, 1, distAB);
        }

    }
}