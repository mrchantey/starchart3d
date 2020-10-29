using UnityEngine;
using System;
using System.Collections;

public static class MonoBehaviourExtensions
{

	public static void DrawPoseGizmo(this MonoBehaviour mono, float len = 1)
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(mono.transform.position, mono.transform.position + mono.transform.right * len);
		Gizmos.color = Color.green;
		Gizmos.DrawLine(mono.transform.position, mono.transform.position + mono.transform.up * len);
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(mono.transform.position, mono.transform.position + mono.transform.forward * len);
	}

	public static IEnumerator CoroutineDelay(this MonoBehaviour mono, Action action, float delay)
	{
		var coroutine = Delay(action, delay);
		mono.StartCoroutine(coroutine);
		return coroutine;
	}

	static IEnumerator Delay(Action action, float time)
	{
		yield return new WaitForSeconds(time);
		action();
	}


	public static IEnumerator CoroutineTimedLoop(this MonoBehaviour mono, Action<float> action, float time)
	{
		var coroutine = TimedLoop(action, time);
		mono.StartCoroutine(coroutine);
		return coroutine;
	}

	static IEnumerator TimedLoop(Action<float> action, float time)
	{
		for (float i = 0; i < time; i += Time.deltaTime)
		{
			action(i / time);
			yield return null;
		}
	}


}