using UnityEngine;

namespace Ahoy
{

    public class PoseToTransform : MonoBehaviour
    {

        public Space space;
        public PoseAssetEvent assetEvent;
        Pose pose;
        // [Range(0, 1)]
        // public float lerp = 0.01f;

        void OnEnable()
        {
            if (assetEvent != null)
                assetEvent.AddListener(Invoke);
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
                    transform.position = pose.position;
                    transform.rotation = pose.rotation;
                    break;
                case Space.Self:
                    transform.localPosition = pose.position;
                    transform.localRotation = pose.rotation;
                    break;
            }
            // transform.position = Vector3.Lerp(transform.position, pose.position, lerp);
            // transform.rotation = Quaternion.Lerp(transform.rotation, pose.rotation, lerp);
        }
    }

}