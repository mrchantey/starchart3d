using UnityEngine;

namespace Ahoy
{

    public class PoseToRigidbody : MonoBehaviour
    {

        public Space space;
        public PoseAssetEvent assetEvent;
        Pose pose;
        new Rigidbody rigidbody;
        // [Range(0, 1)]
        // public float lerp = 0.01f;

        void OnEnable()
        {
            if (assetEvent != null)
                assetEvent.AddListener(Invoke);
            rigidbody = GetComponent<Rigidbody>();
        }

        void OnDisable()
        {
            if (assetEvent != null)
                assetEvent.RemoveListener(Invoke);
        }

        public void Invoke(Pose pose)
        {
            switch (space)
            {
                case Space.World:
                    rigidbody.MovePosition(pose.position);
                    rigidbody.MoveRotation(pose.rotation);
                    break;
                case Space.Self:
                    // rigidbody.position = (transform.InverseTransformPoint(pose.position));
                    // rigidbody.rotation = (Quaternion.Inverse(transform.rotation) * pose.rotation);
                    var pos = transform.parent.TransformPoint(pose.position);
                    // var fwd = transform.parent.TransformPoint(pose.rotation * Vector3.forward);
                    // var up = transform.parent.TransformPoint(pose.rotation * Vector3.up);
                    // var rot = Quaternion.LookRotation(fwd, up);
                    var rot = transform.parent.rotation * pose.rotation;
                    // if(rot.)
                    rigidbody.MovePosition(pos);
                    rigidbody.MoveRotation(rot.normalized);
                    break;
            }
            // transform.position = Vector3.Lerp(transform.position, pose.position, lerp);
            // transform.rotation = Quaternion.Lerp(transform.rotation, pose.rotation, lerp);
        }
    }

}