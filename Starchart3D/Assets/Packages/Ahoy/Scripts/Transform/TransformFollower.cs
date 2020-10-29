


using UnityEngine;

namespace Ahoy
{

	public class TransformFollower : MonoBehaviour
	{

		public Transform other;

		[Range(0, 1)]
		public float trackingSpeed = 0.5f;

		void Update()
		{
			var pose = PoseExtensions.Slerp(transform.Pose(), other.Pose(), trackingSpeed);
			transform.SetPositionAndRotation(pose);
		}

	}
}