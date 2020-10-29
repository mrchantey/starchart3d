using UnityEngine;

namespace Ahoy
{

    public class Projectile : MonoBehaviour
    {


        public bool debug;
        float startTime;
        Vector3 startPosition;
        void Start()
        {
            startTime = Time.time;
            startPosition = transform.position;
        }
        void OnCollisionEnter(Collision other)
        {
            if (debug)
            {
                var dt = Time.time - startTime;
                var dist = transform.position - startPosition;
                Debug.Log($"projectile: delta time: {dt}\t distance {dist}");
            }
            GameObject.Destroy(gameObject);
        }

    }
}