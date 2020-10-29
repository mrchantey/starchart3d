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
/*AUTO SCRIPT*/    [CreateAssetMenu(fileName = "TimedQuaternionAssetEvent", menuName = "Ahoy/Asset Events/TimedQuaternion", order = 0)]
/*AUTO SCRIPT*/    public class TimedQuaternionAssetEvent : InvocableSO
/*AUTO SCRIPT*/    {
/*AUTO SCRIPT*/        public bool debug;
/*AUTO SCRIPT*/        public TimedQuaternion constantValue;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        // public List<TimedQuaternionUnityEvent> listeners = new List<TimedQuaternionUnityEvent>();
/*AUTO SCRIPT*/        public List<TimedQuaternionUnityEvent> unityEventListeners;
/*AUTO SCRIPT*/        public List<TimedQuaternionAssetEvent> assetEventListeners;
/*AUTO SCRIPT*/        AhoyEvent<TimedQuaternion> ahoyEvent = new AhoyEvent<TimedQuaternion>();
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void AddListener(Action<TimedQuaternion> action)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            ahoyEvent.AddListener(action);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void RemoveListener(Action<TimedQuaternion> action)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            ahoyEvent.RemoveListener(action);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void AddListener(TimedQuaternionUnityEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            unityEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void RemoveListener(TimedQuaternionUnityEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            unityEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void AddListener(TimedQuaternionAssetEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            assetEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void RemoveListener(TimedQuaternionAssetEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            assetEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void Invoke(TimedQuaternion val)
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