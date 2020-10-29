using UnityEngine;

namespace Ahoy
{

    public class ProjectilePredicter : MonoBehaviour
    {

        public bool debug;
        GameObject projectile;
        Vector3 position;
        [Range(-100, 100)]
        public float yIntersect;

        public Vector3UnityEvent OnPredict;

        public void SetProjectile(GameObject projectile)
        {
            this.projectile = projectile;
        }


        void Update()
        {
            if (projectile != null)
            {
                var vel = projectile.GetComponent<Rigidbody>().velocity;
                if (vel == Vector3.zero)
                    return;
                var pos = projectile.transform.position;
                position = Mechanics.FinalProjectilePosition(pos, vel, yIntersect);
                OnPredict.Invoke(position);
            }
        }

        void OnDrawGizmos()
        {
            if (debug)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(position, 1);
            }

        }

    }
}