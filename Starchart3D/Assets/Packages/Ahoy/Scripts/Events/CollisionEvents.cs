using UnityEngine;

namespace Ahoy
{

    public class CollisionEvents : MonoBehaviour
    {

        public CollisionUnityEvent onCollisionEnter;
        public CollisionUnityEvent onCollisionStay;
        public CollisionUnityEvent onCollisionExit;
        public ColliderUnityEvent onTriggerEnter;
        public ColliderUnityEvent onTriggerStay;
        public ColliderUnityEvent onTriggerExit;

        void OnCollisionEnter(Collision collision)
        {
            onCollisionEnter.Invoke(collision);
        }

        void OnCollisionStay(Collision collision)
        {
            onCollisionStay.Invoke(collision);
        }

        void OnCollisionExit(Collision collision)
        {
            onCollisionExit.Invoke(collision);
        }

        void OnTriggerEnter(Collider other)
        {
            onTriggerEnter.Invoke(other);
        }
        void OnTriggerStay(Collider other)
        {
            onTriggerStay.Invoke(other);
        }
        void OnTriggerExit(Collider other)
        {
            onTriggerExit.Invoke(other);
        }
    }
}