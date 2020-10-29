using System;
using UnityEngine;

namespace Ahoy
{
    // [ExecuteAlways]
    public abstract class InvocableMono : MonoBehaviour
    {

        public InvocableMonoSettings invokeSettings;
        bool needsInvoking;
        float lastInvoke;

        protected virtual void OnValidate()
        {
            //many operations cannot be done on validate call
            if (invokeSettings == null || !invokeSettings.InvokeOnValidate)
                return;
            needsInvoking = true;
        }

        protected virtual void Start()
        {
            if (invokeSettings.InvokeOnStart)
                Invoke();
        }

        public void Invoke(Action onInvoke)
        {
            Invoke();
            onInvoke();
        }

        protected virtual void Update()
        {
            if (needsInvoking)
            {
                needsInvoking = false;
                Invoke();
            }
            else if (invokeSettings.InvokeOnUpdate)
                Invoke();
            else if (invokeSettings.InvokeOnNthFrame && Time.frameCount == invokeSettings.nthFrame)
                Invoke();
            else if (invokeSettings.InvokeEveryNthFrame && Time.frameCount % invokeSettings.nthFrame == 0)
                Invoke();
            else if (invokeSettings.InvokeEveryInterval && Time.time - lastInvoke > invokeSettings.interval)
            {
                lastInvoke = Time.time;
                Invoke();
            }
        }
        protected virtual void FixedUpdate()
        {

            if (invokeSettings.InvokeOnFixedUpdate)
                Invoke();
            else if (invokeSettings.InvokeEveryIntervalFixed && Time.time - lastInvoke > invokeSettings.interval)
            {
                lastInvoke = Time.time;
                Invoke();
            }
        }

        public abstract void Invoke();
    }


}