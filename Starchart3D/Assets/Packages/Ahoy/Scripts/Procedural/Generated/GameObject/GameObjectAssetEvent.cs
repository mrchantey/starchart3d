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
/*AUTO SCRIPT*/    [CreateAssetMenu(fileName = "GameObjectAssetEvent", menuName = "Ahoy/Asset Events/GameObject", order = 0)]
/*AUTO SCRIPT*/    public class GameObjectAssetEvent : InvocableSO
/*AUTO SCRIPT*/    {
/*AUTO SCRIPT*/        public bool debug;
/*AUTO SCRIPT*/        public GameObject constantValue;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        // public List<GameObjectUnityEvent> listeners = new List<GameObjectUnityEvent>();
/*AUTO SCRIPT*/        public List<GameObjectUnityEvent> unityEventListeners;
/*AUTO SCRIPT*/        public List<GameObjectAssetEvent> assetEventListeners;
/*AUTO SCRIPT*/        AhoyEvent<GameObject> ahoyEvent = new AhoyEvent<GameObject>();
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void AddListener(Action<GameObject> action)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            ahoyEvent.AddListener(action);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void RemoveListener(Action<GameObject> action)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            ahoyEvent.RemoveListener(action);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void AddListener(GameObjectUnityEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            unityEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void RemoveListener(GameObjectUnityEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            unityEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void AddListener(GameObjectAssetEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            assetEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void RemoveListener(GameObjectAssetEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            assetEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void Invoke(GameObject val)
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