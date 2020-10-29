using UnityEngine;

namespace Ahoy
{

    public class TransformToPose : InvocableMono
    {
        public PoseUnityEvent onUpdate;
        public new Transform transform;
        public override void Invoke()
        {
            onUpdate.Invoke(new Pose(transform.position, transform.rotation));
        }

    }

}