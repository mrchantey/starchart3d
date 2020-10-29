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
/*AUTO SCRIPT*/    [CreateAssetMenu(fileName = "Image2DAssetEvent", menuName = "Ahoy/Asset Events/Image2D", order = 0)]
/*AUTO SCRIPT*/    public class Image2DAssetEvent : InvocableSO
/*AUTO SCRIPT*/    {
/*AUTO SCRIPT*/        public bool debug;
/*AUTO SCRIPT*/        public Image2D constantValue;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        // public List<Image2DUnityEvent> listeners = new List<Image2DUnityEvent>();
/*AUTO SCRIPT*/        public List<Image2DUnityEvent> unityEventListeners;
/*AUTO SCRIPT*/        public List<Image2DAssetEvent> assetEventListeners;
/*AUTO SCRIPT*/        AhoyEvent<Image2D> ahoyEvent = new AhoyEvent<Image2D>();
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void AddListener(Action<Image2D> action)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            ahoyEvent.AddListener(action);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void RemoveListener(Action<Image2D> action)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            ahoyEvent.RemoveListener(action);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void AddListener(Image2DUnityEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            unityEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void RemoveListener(Image2DUnityEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            unityEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void AddListener(Image2DAssetEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            assetEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/        public void RemoveListener(Image2DAssetEvent listener)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            assetEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void Invoke(Image2D val)
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