using UnityEngine;

namespace Ahoy
{

    [ExecuteAlways]
    public class TransformUpdateListener : TransformInvocableMono
    {



        Matrix4x4 lastLocalToWorld;

        void OnEnable()
        {
            lastLocalToWorld = value.localToWorldMatrix;
            if (value == null)
                value = transform;
            // value = value;
        }

        protected override void Update()
        {
            if (value.localToWorldMatrix != lastLocalToWorld)
            {
                Invoke();
                // onUpdate.Invoke(value);
                lastLocalToWorld = value.localToWorldMatrix;
            }
            base.Update();
        }

    }
}