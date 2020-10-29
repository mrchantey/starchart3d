//
//
//	THS FILE IS AUTO GENERATED
//	DO NOT EDIT DIRECTLY
//



/*AUTO SCRIPT*/using UnityEngine;
/*AUTO SCRIPT*/using UnityEngine.Events;
/*AUTO SCRIPT*/using System.Collections.Generic;
/*AUTO SCRIPT*/using System;
/*AUTO SCRIPT*/using System.Linq;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/namespace Ahoy
/*AUTO SCRIPT*/{
/*AUTO SCRIPT*/    [CreateAssetMenu(fileName = "UlongAssetEvent", menuName = "Ahoy/Asset Events/ulong", order = 0)]
/*AUTO SCRIPT*/    public class UlongAssetEvent : InvocableSO
/*AUTO SCRIPT*/    {
/*AUTO SCRIPT*/        public bool debug;
/*AUTO SCRIPT*/        public ulong constantValue;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        // public List<UlongUnityEvent> listeners = new List<UlongUnityEvent>();
/*AUTO SCRIPT*/        public List<UlongUnityEvent> unityEventListeners;
/*AUTO SCRIPT*/        public List<UlongAssetEvent> assetEventListeners;
/*AUTO SCRIPT*/        AhoyEvent<ulong> ahoyEvent = new AhoyEvent<ulong>();
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void AddListener(Action<ulong> action)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            ahoyEvent.AddListener(action);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void RemoveListener(Action<ulong> action)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            ahoyEvent.RemoveListener(action);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void AddListener(UlongUnityEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            unityEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void RemoveListener(UlongUnityEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            unityEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void AddListener(UlongAssetEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            assetEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void RemoveListener(UlongAssetEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            assetEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void Invoke(ulong val)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            if (debug)
/*AUTO SCRIPT*/                Debug.Log($"{name} event invoked: {val}");
/*AUTO SCRIPT*/            ahoyEvent.Invoke(val);
/*AUTO SCRIPT*/            //important to do this incase a listener removes its self from the list
/*AUTO SCRIPT*/            unityEventListeners.ToArray().ForEach(l => l.Invoke(val));
/*AUTO SCRIPT*/            assetEventListeners.ToArray().ForEach(l => l.Invoke(val));
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public override void Invoke()
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            Invoke(constantValue);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/    }
/*AUTO SCRIPT*/}