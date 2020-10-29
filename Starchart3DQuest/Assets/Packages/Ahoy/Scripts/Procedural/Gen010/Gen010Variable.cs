using UnityEngine;

namespace Ahoy
{

    [CreateAssetMenu(fileName = "Gen010Variable", menuName = "Ahoy/Variable/Gen010", order = 0)]
    public class Gen010Variable : ScriptableObject
    {

        public gen010 value;
        [Header("min and max only for where it applies")]
        public bool useMinMax;
        public gen010 min;
        public gen010 max;
    }

}