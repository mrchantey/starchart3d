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
/*AUTO SCRIPT*/	[CreateAssetMenu(fileName = "LongNamedAssetEvent", menuName = "Ahoy/Asset Events/long - named", order = 0)]
/*AUTO SCRIPT*/	public class LongNamedAssetEvent : InvocableSO
/*AUTO SCRIPT*/	{
/*AUTO SCRIPT*/		public bool debug;
/*AUTO SCRIPT*/		public long constantValue;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public new string name = "long named event";
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		// public List<LongNamedUnityEvent> listeners = new List<LongNamedUnityEvent>();
/*AUTO SCRIPT*/		public List<LongNamedUnityEvent> unityEventListeners;
/*AUTO SCRIPT*/		public List<LongAssetEvent> assetEventListeners;
/*AUTO SCRIPT*/		AhoyEvent<string, long> ahoyEvent = new AhoyEvent<string, long>();
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public void AddListener(Action<string, long> action)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			ahoyEvent.AddListener(action);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public void RemoveListener(Action<string, long> action)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			ahoyEvent.RemoveListener(action);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public void AddListener(LongNamedUnityEvent listener)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			unityEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/		public void RemoveListener(LongNamedUnityEvent listener)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			unityEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/		public void AddListener(LongAssetEvent listener)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			assetEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/		public void RemoveListener(LongAssetEvent listener)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			assetEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public void Invoke(long val)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			if (debug)
/*AUTO SCRIPT*/				Debug.Log($"{name} event invoked: {val}");
/*AUTO SCRIPT*/			ahoyEvent.Invoke(name, val);
/*AUTO SCRIPT*/			//important to do this incase a listener removes its self from the list
/*AUTO SCRIPT*/			unityEventListeners.ToArray().ForEach(l => l.Invoke(name, val));
/*AUTO SCRIPT*/			assetEventListeners.ToArray().ForEach(l => l.Invoke(val));
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public override void Invoke()
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			Invoke(constantValue);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/	}
/*AUTO SCRIPT*/}