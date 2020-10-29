using UnityEngine;
namespace Ahoy
{
	// using HitDict = Dictionary<Transform, RaycastInfo>;
	public class TransformRaycastEvents : RaycastEvents
	{

		public Vector3 localDirection = Vector3.forward;

		protected override Ray GetRay()
		{
			var worldDir = transform.TransformDirection(localDirection);
			return new Ray(transform.position, worldDir);
		}

	}
}