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
	public class LifecycleHooks : MonoBehaviour
	{


		public UnityEvent onStart;
		public UnityEvent onUpdate;
		public UnityEvent onFixedUpdate;
		public UnityEvent onDrawGizmos;

		// public AhoyEvent start;
		// public AhoyEvent update;

		// bad practice, use ComponentSystems
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