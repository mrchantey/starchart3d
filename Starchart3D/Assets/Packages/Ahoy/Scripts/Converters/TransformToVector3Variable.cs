using UnityEngine;
using UnityEngine.UI;

namespace Ahoy.Loci
{

    public class TransformToVector3Variable : TransformToVariable
    {

        public Vector3Variable variable;
        [Range(0, 100)]
        public float range = 1;

        public override void Invoke()
        {
            var val = value.localPosition / range;
            variable.value = val;
        }



    }
}