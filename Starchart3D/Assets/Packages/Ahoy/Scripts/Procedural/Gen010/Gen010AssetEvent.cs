using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;


namespace Ahoy
{
    [CreateAssetMenu(fileName = "Gen010AssetEvent", menuName = "Ahoy/Asset Events/gen010", order = 0)]
    public class Gen010AssetEvent : InvocableSO
    {
        public bool debug;
        public gen010 constantValue;

        // public List<Gen010UnityEvent> listeners = new List<Gen010UnityEvent>();
        public List<Gen010UnityEvent> unityEventListeners;
        public List<Gen010AssetEvent> assetEventListeners;
        AhoyEvent<gen010> ahoyEvent = new AhoyEvent<gen010>();

        public void AddListener(Action<gen010> action)
        {
            ahoyEvent.AddListener(action);
        }

        public void RemoveListener(Action<gen010> action)
        {
            ahoyEvent.RemoveListener(action);
        }

        public void AddListener(Gen010UnityEvent listener)
        {
            unityEventListeners.TryAdd(listener);
        }
        public void RemoveListener(Gen010UnityEvent listener)
        {
            unityEventListeners.TryRemove(listener);
        }
        public void AddListener(Gen010AssetEvent listener)
        {
            assetEventListeners.TryAdd(listener);
        }
        public void RemoveListener(Gen010AssetEvent listener)
        {
            assetEventListeners.TryRemove(listener);
        }



        public void Invoke(gen010 val)
        {
            if (debug)
                Debug.Log($"{name} event invoked: {val}");
            ahoyEvent.Invoke(val);
            //important to do this incase a listener removes its self from the list
            unityEventListeners.ToArray().ForEach(l => l.Invoke(val));
            assetEventListeners.ToArray().ForEach(l => l.Invoke(val));
        }


        public override void Invoke()
        {
            Invoke(constantValue);
        }


    }
}