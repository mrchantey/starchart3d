using UnityEngine;

namespace Ahoy
{

    public abstract class TransformToVariable : InvocableMono
    {

        // [Header("the transforms local position will be read from -1 to 1")]
        public Transform value;

        void OnEnable()
        {
            if (value == null) value = transform;
        }



    }
}