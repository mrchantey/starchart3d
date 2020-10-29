using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;

namespace Ahoy
{
	struct FrameStampedAction
	{
		public System.Action action;
		public int frameStamp;
	}
	public class ApplicationEvents : MonoBehaviour
	{


		public UnityEvent onApplicationEditor;
		public UnityEvent onApplicationMobile;

		public UnityEvent onAwake;
		public UnityEvent onStart;
		public UnityEvent onUpdate;
		public UnityEvent onFixedUpdate;
		public UnityEvent onDrawGizmos;

		public static AhoyEvent awake = new AhoyEvent();
		public static AhoyEvent start = new AhoyEvent();
		public static AhoyEvent update = new AhoyEvent();
		public static AhoyEvent drawGizmos = new AhoyEvent();
		public static AhoyEvent fixedUpdate = new AhoyEvent();
		// public static AhoyEvent drawGizmosFixed = new AhoyEvent();
		static List<FrameStampedAction> drawGizmosFixed = new List<FrameStampedAction>();

		int lastFixedFrameCount;

		public static void AddDrawGizmosFixedListener(System.Action action)
		{
			// Debug.Log($"LifecycleHooks - wooo");
			drawGizmosFixed.Add(new FrameStampedAction() { action = action, frameStamp = Time.frameCount });
		}
		void Awake()
		{
			if (Application.isEditor)
				onApplicationEditor.Invoke();
			if (Application.isMobilePlatform)
				onApplicationMobile.Invoke();
			awake.Invoke();
			onAwake.Invoke();
		}
		public void Quit()
		{
			Application.Quit();
		}

		private void Start()
		{
			start.Invoke();
			onStart.Invoke();
		}

		private void Update()
		{
			update.Invoke();
			onUpdate.Invoke();
		}

		private void FixedUpdate()
		{
			fixedUpdate.Invoke();
			onFixedUpdate.Invoke();
			lastFixedFrameCount = Time.frameCount;
		}

		void OnDestroy()
		{
			drawGizmosFixed.Clear();
		}

		private void OnDrawGizmos()
		{
			onDrawGizmos.Invoke();
			drawGizmos.Invoke();
			drawGizmosFixed.ToArray().ForEach(kvp => kvp.action());
			drawGizmosFixed = drawGizmosFixed
.Where(fsa => fsa.frameStamp >= lastFixedFrameCount)
.ToList();
		}

	}
}