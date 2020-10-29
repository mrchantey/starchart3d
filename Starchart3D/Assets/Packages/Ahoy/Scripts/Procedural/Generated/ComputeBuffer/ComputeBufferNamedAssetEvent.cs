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
/*AUTO SCRIPT*/	[CreateAssetMenu(fileName = "ComputeBufferNamedAssetEvent", menuName = "Ahoy/Asset Events/ComputeBuffer - named", order = 0)]
/*AUTO SCRIPT*/	public class ComputeBufferNamedAssetEvent : InvocableSO
/*AUTO SCRIPT*/	{
/*AUTO SCRIPT*/		public bool debug;
/*AUTO SCRIPT*/		public ComputeBuffer constantValue;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public new string name = "ComputeBuffer named event";
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		// public List<ComputeBufferNamedUnityEvent> listeners = new List<ComputeBufferNamedUnityEvent>();
/*AUTO SCRIPT*/		public List<ComputeBufferNamedUnityEvent> unityEventListeners;
/*AUTO SCRIPT*/		public List<ComputeBufferAssetEvent> assetEventListeners;
/*AUTO SCRIPT*/		AhoyEvent<string, ComputeBuffer> ahoyEvent = new AhoyEvent<string, ComputeBuffer>();
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public void AddListener(Action<string, ComputeBuffer> action)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			ahoyEvent.AddListener(action);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public void RemoveListener(Action<string, ComputeBuffer> action)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			ahoyEvent.RemoveListener(action);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public void AddListener(ComputeBufferNamedUnityEvent listener)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			unityEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/		public void RemoveListener(ComputeBufferNamedUnityEvent listener)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			unityEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/		public void AddListener(ComputeBufferAssetEvent listener)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			assetEventListeners.TryAdd(listener);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/		public void RemoveListener(ComputeBufferAssetEvent listener)
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			assetEventListeners.TryRemove(listener);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public void Invoke(ComputeBuffer val)
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