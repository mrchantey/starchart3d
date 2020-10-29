using UnityEngine;

namespace Ahoy
{
    [ExecuteAlways]
    public class TransformConstrainer : InvocableMono
    {


        public Transform value;
        Vector3 startPosition;
        Vector3 startEuler;

        public bool freezePositionX;
        public bool freezePositionY;
        public bool freezePositionZ;
        public bool freezeRotationX;
        public bool freezeRotationY;
        public bool freezeRotationZ;

        public bool clamp;
        [Range(0, 100)]
        public float clampRadius = 1f;

        void OnEnable()
        {
            if (value == null) value = transform;
            startPosition = value.localPosition;
            startEuler = value.localRotation.eulerAngles;
        }

        public override void Invoke()
        {
            var pose = value.LocalPose();
            // var worldToLocal = value.worldToLocalMatrix;
            if (freezePositionX)
                pose.position.x = startPosition.x;
            if (freezePositionY)
                pose.position.y = startPosition.y;
            if (freezePositionZ)
                pose.position.z = startPosition.z;
            var euler = pose.rotation.eulerAngles;
            if (freezeRotationX)
                euler.x = startEuler.x;
            if (freezeRotationY)
                euler.y = startEuler.y;
            if (freezeRotationZ)
                euler.z = startEuler.z;
            pose.rotation.eulerAngles = euler;
            if (clamp)
                pose.position = Vector3.ClampMagnitude(pose.position, clampRadius);
            // Debug.Log($"Transform Constrainer - pos:{worldToLocal.GetPosition()}\trot{worldToLocal.GetRotation().eulerAngles}");
            // value.SetPositionAndRotation(worldToLocal, TransformSpace.Local);
            value.SetPositionAndRotation(pose, TransformSpace.Local);
        }


    }
}