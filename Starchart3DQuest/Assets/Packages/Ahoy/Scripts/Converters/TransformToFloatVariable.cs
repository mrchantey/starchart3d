using UnityEngine;
using UnityEngine.UI;

namespace Ahoy.Loci
{

    public class TransformToFloatVariable : TransformToVariable
    {

        public FloatVariable floatVariable;
        [Range(0, 100)]
        public float range = 1;


        public override void Invoke()
        {
            var val = value.localPosition / range;
            var normalX = val.x * 0.5f + 0.5f;
            var x = Mathf.Lerp(floatVariable.min, floatVariable.max, normalX);
            floatVariable.value = x;
        }



    }
}