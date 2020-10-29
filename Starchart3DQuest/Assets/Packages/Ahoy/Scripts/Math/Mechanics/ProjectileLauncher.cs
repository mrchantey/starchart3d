using UnityEngine;
using UnityEditor;
namespace Ahoy
{

	public class ProjectileLauncher : InvocableMono
	{

		public bool debug;

		public Transform cannon;
		public Transform target;

		public ProjectileSettings settings;
		Vector3 projectileTarget;

		public GameObjectUnityEvent onLaunch;

		protected override void Start()
		{
			base.Start();
		}

		public override void Invoke()
		{
			var targetRb = target.GetComponent<Rigidbody>();
			var horizDist = Vector3.Magnitude(target.position.XZ() - transform.position.XZ());
			var outOfRange = horizDist > settings.range;

			if (outOfRange && !settings.launchWhenOutOfRange)
				return;

			var rangeDist = Mathf.Clamp(horizDist, 0, settings.range);
			var horizVel = (targetRb == null || !settings.scaleVelocity)
			? settings.horizontalVelocity
			: settings.horizontalVelocity * rangeDist + settings.horizontalVelocity * targetRb.velocity.XZ().magnitude;

			var desiredTarget = (targetRb == null)
			? target.position
			: Mechanics.ProjectileTargetNextPosition(transform.position, target.position, targetRb.velocity, horizVel);


			var clampedTarget = transform.position + Vector3.ClampMagnitude(desiredTarget - transform.position, settings.range);
			projectileTarget = clampedTarget;

			var randomPos = projectileTarget + Random.insideUnitSphere * settings.randomRadius;
			var vel = Mechanics.ProjectileVelocity(transform.position, randomPos, horizVel);

			transform.rotation = Quaternion.LookRotation(vel.normalized, Vector3.up);

			var go = GameObject.Instantiate(settings.projectilePrefab, cannon.position, Quaternion.identity);
			var rigidBody = go.GetComponent<Rigidbody>();
			rigidBody.AddForce(vel, ForceMode.Impulse);
			onLaunch.Invoke(go);
		}

#if UNITY_EDITOR
		void OnDrawGizmos()
		{
			if (debug)
			{
				Gizmos.color = Color.cyan;
				Gizmos.DrawSphere(projectileTarget, 0.5f);
				Gizmos.color = Color.yellow;
				Gizmos.DrawWireSphere(projectileTarget, settings.randomRadius);
				Handles.color = Color.red;
				Handles.DrawWireDisc(transform.position, Vector3.up, settings.range);
			}
		}
#endif

	}
}