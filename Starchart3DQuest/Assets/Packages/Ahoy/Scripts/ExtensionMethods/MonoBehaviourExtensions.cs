using UnityEngine;

public static class MonoBehaviourExtensions
{

public static void DrawPoseGizmo(this MonoBehaviour mono, float len = 1){
	Gizmos.color = Color.red;
	Gizmos.DrawLine(mono.transform.position, mono.transform.position + mono.transform.right * len);
	Gizmos.color = Color.green;
	Gizmos.DrawLine(mono.transform.position, mono.transform.position + mono.transform.up * len);
	Gizmos.color = Color.blue;
	Gizmos.DrawLine(mono.transform.position, mono.transform.position + mono.transform.forward * len);
}
}