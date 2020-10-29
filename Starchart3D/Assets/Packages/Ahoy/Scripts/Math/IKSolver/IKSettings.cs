using UnityEngine;

namespace Ahoy
{

    [CreateAssetMenu(fileName = "IK Settings", menuName = "Ahoy/IK Settings", order = 0)]
    public class IKSettings : ScriptableObject
    {

        [Range(0, 10)]
        public float segment1Length = 0.28f;
        [Range(0, 10)]
        public float segment2Length = 0.32f;

        [MinMax(0, 1)]
        public Vector2 extentsLimits = new Vector2(0.05f, 0.95f);
    }

}