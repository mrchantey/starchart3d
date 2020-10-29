using UnityEngine;

namespace Ahoy
{
	public enum RaycastTransformDirection
	{
		None,
		RayDirecion,
		HitNormal
	}
	public class TransformFromRaycast : MonoBehaviour
	{

		public bool updatePositon;
		public RaycastTransformDirection rotationDirection;

		public void OnHit(RaycastInfo info)
		{
			if (updatePositon)
				transform.position = info.hit.point;
			switch (rotationDirection)
			{
				case RaycastTransformDirection.HitNormal:
					transform.rotation = Quaternion.LookRotation(info.hit.normal, Vector3.up);
					break;
				case RaycastTransformDirection.RayDirecion:
					transform.rotation = Quaternion.LookRotation(info.ray.direction, Vector3.up);
					break;
				default:
					break;
			}
		}

	}
}