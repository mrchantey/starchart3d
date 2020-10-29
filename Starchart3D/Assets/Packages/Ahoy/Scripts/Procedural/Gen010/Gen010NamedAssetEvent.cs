using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;


namespace Ahoy
{
	[CreateAssetMenu(fileName = "Gen010NamedAssetEvent", menuName = "Ahoy/Asset Events/gen010 - named", order = 0)]
	public class Gen010NamedAssetEvent : InvocableSO
	{
		public bool debug;
		public gen010 constantValue;

		public new string name = "gen010 named event";

		// public List<Gen010NamedUnityEvent> listeners = new List<Gen010NamedUnityEvent>();
		public List<Gen010NamedUnityEvent> unityEventListeners;
		public List<Gen010AssetEvent> assetEventListeners;
		AhoyEvent<string, gen010> ahoyEvent = new AhoyEvent<string, gen010>();

		public void AddListener(Action<string, gen010> action)
		{
			ahoyEvent.AddListener(action);
		}

		public void RemoveListener(Action<string, gen010> action)
		{
			ahoyEvent.RemoveListener(action);
		}

		public void AddListener(Gen010NamedUnityEvent listener)
		{
			unityEventListeners.TryAdd(listener);
		}
		public void RemoveListener(Gen010NamedUnityEvent listener)
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
			ahoyEvent.Invoke(name, val);
			//important to do this incase a listener removes its self from the list
			unityEventListeners.ToArray().ForEach(l => l.Invoke(name, val));
			assetEventListeners.ToArray().ForEach(l => l.Invoke(val));
		}


		public override void Invoke()
		{
			Invoke(constantValue);
		}


	}
}