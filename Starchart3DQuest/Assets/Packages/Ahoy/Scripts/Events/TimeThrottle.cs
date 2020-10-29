using UnityEngine;
using System;

namespace Ahoy
{

    public abstract class TimeThrottle<dataT, eventT> : MonoBehaviour
    where eventT : UnityEngine.Events.UnityEvent<dataT>
    {
        public bool debug;

        [Range(0, 100)]
        public int maxMessagesPerSecond = 10;
        float dMillisMin;

        public eventT onClearInvoke;
        DateTime lastMessageTime;
        double lastDeltaMillis;

        private void OnValidate()
        {
            SedDeltaMillis();
            lastMessageTime = DateTime.Now;
        }

        void SedDeltaMillis()
        {
            dMillisMin = ((float)1 / maxMessagesPerSecond) * 1000;
        }

        bool CheckTime()
        {
            var now = DateTime.Now;
            var dMillis = DateTime.Now.Subtract(lastMessageTime).TotalMilliseconds;

            // Debug.Log($"delta millis {dMillis} millis min: {dMillisMin}");

            if (dMillis >= dMillisMin)
            {
                lastDeltaMillis = dMillis;
                // Debug.Log($"yay, sending");
                lastMessageTime = DateTime.Now;
                return true;
            }
            else
                return false;
        }

        public void ForceInvoke(dataT val)
        {
            lastMessageTime = DateTime.Now;
            onClearInvoke.Invoke(val);
        }

        public void TryInvoke(dataT val)
        {
            if (CheckTime())
            {
                if (debug)
                    Debug.Log($"throttle cleared: {lastDeltaMillis}");
                onClearInvoke.Invoke(val);
            }

        }

        private void OnEnable()
        {
            SedDeltaMillis();
        }



    }

}