using UnityEngine;
using System.Linq;

namespace Ahoy
{

	public abstract class RaycastEvents : InvocableMono
	{

		[Range(0, 1000)]
		public float maxDistance = 1000;
		[Range(0, 1000)]
		public int maxRays = 1;

		RaycastInfo[] currentHits = new RaycastInfo[0];

		public NullUnityEvent onMiss;
		public RaycastInfoUnityEvent onHitEnter;
		public RaycastInfoUnityEvent onHitStay;
		public RaycastInfoUnityEvent onHitExit;

		protected abstract Ray GetRay();

		public override void Invoke()
		{
			var ray = GetRay();
			var raycastHits = Physics.RaycastAll(ray, maxDistance);
			if (raycastHits.Length == 0)
				onMiss.Invoke();
			// var transforms = raycasts.Select(r => r.transform).ToArray();
			// if (debug) Debug.Log($"CursorRaycast - {transforms.Length} transforms hit");
			int numTransforms = Mathf.Min(raycastHits.Length, maxRays);

			raycastHits = raycastHits
				.OrderBy(h => h.distance)
				.Take(numTransforms)
				.ToArray();
			// onHit.Invoke(filteredTransforms);

			var nextHits = raycastHits
			.Select(nh => new RaycastInfo() { ray = ray, hit = nh })
			.ToArray();

			//enter hits
			nextHits
			.Where(nh => !currentHits
				.Select(ch => ch.hit.transform)
				.Contains(nh.hit.transform))
			.ForEach(nh => onHitEnter.Invoke(nh));

			//stay hits
			nextHits
			.Where(nh => currentHits
				.Select(ch => ch.hit.transform)
				.Contains(nh.hit.transform))
			.ForEach(nh => onHitStay.Invoke(nh));

			//exit hits
			currentHits
			.Where(h => !nextHits
				.Any(nh => nh.hit.transform == h.hit.transform))
			.ForEach(h => onHitExit.Invoke(h));

			//update current hits
			currentHits = nextHits;
			// currentHits
		}
	}
}