using UnityEngine;

namespace Ahoy
{

    public class Vector3ToTransform : MonoBehaviour
    {


        public Vector3AssetEvent assetEvent;

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

        public void Invoke(Vector3 position)
        {
            // transform.position = Vector3.Lerp(transform.position, pose.position, lerp);
            // transform.rotation = Quaternion.Lerp(transform.rotation, pose.rotation, lerp);
            transform.position = position;
        }
    }

}