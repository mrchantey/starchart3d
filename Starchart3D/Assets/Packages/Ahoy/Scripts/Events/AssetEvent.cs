using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;


namespace Ahoy
{
    [CreateAssetMenu(fileName = "AssetEvent", menuName = "Ahoy/Asset Events/Null", order = 0)]
    public class AssetEvent : InvocableSO
    {
        public bool debug;

        public List<UnityEvent> unityEventListeners;
        public List<AssetEvent> assetEventListeners;
        AhoyEvent ahoyEvent = new AhoyEvent();

        public void AddListener(Action action)
        {
            ahoyEvent.AddListener(action);
        }

        public void RemoveListener(Action action)
        {
            ahoyEvent.RemoveListener(action);
        }

        public void AddListener(UnityEvent listener)
        {
            unityEventListeners.TryAdd(listener);
        }
        public void RemoveListener(UnityEvent listener)
        {
            unityEventListeners.TryRemove(listener);
        }
        public void AddListener(AssetEvent listener)
        {
            assetEventListeners.TryAdd(listener);
        }
        public void RemoveListener(AssetEvent listener)
        {
            assetEventListeners.TryRemove(listener);
        }

        public override void Invoke()
        {
            if (debug)
                Debug.Log($"{name} event invoked");
            //important to do this incase a listener removes its self from the list
            ahoyEvent.Invoke();
            unityEventListeners.ToArray().ForEach(l => l.Invoke());
            assetEventListeners.ToArray().ForEach(l => l.Invoke());
        }
    }
}