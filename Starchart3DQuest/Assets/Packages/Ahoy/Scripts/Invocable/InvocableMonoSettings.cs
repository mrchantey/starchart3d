using UnityEngine;

namespace Ahoy
{
    [System.Serializable]
    public class InvocableMonoSettings
    {
        public bool debug;
        public bool InvokeOnValidate;
        public bool InvokeOnStart;
        public bool InvokeOnUpdate;
        public bool InvokeOnFixedUpdate;
        public bool InvokeOnNthFrame;
        public bool InvokeEveryNthFrame;
        [Range(0, 1024)]
        public int nthFrame = 5;
        public bool InvokeEveryInterval;
        public bool InvokeEveryIntervalFixed;
        [Range(0, 1024)]
        public float interval = 5;

    }
}