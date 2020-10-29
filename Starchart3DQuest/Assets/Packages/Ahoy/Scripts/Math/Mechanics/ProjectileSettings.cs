using UnityEngine;

namespace Ahoy
{

    [CreateAssetMenu(fileName = "ProjectileSettings", menuName = "Ahoy/ProjectileSettings", order = 0)]
    public class ProjectileSettings : ScriptableObject
    {

        public GameObject projectilePrefab;

        public bool scaleVelocity;
        [Range(0, 1024)]
        public float horizontalVelocity = 5f;

        public bool launchWhenOutOfRange;
        [Range(0, 512)]
        public float range = 10;

        [Range(0, 127)]
        public float randomRadius = 1f;





    }
}