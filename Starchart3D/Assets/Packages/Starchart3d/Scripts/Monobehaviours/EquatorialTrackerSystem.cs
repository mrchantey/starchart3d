using UnityEngine;
using Ahoy;
using System.Linq;
using System.Collections.Generic;

namespace Starchart3D
{

	public class EquatorialTrackerSystem : MonoBehaviour
	{


		public DoubleVariable day;
		public GeographicCoordsSO geographicCoordsSO;
		public AstrobodiesSO astrobodiesSO;



		public List<EquatorialTracker> trackers;

		void Update()
		{
			var lst = StarMath.LocalSiderealTime(astrobodiesSO.value, geographicCoordsSO.value, day.value);
			trackers = trackers.Where(t => t != null).ToList();
			trackers.ForEach(t => UpdateTrackerPosition(t, lst));
		}

		void UpdateTrackerPosition(EquatorialTracker tracker, double lst)
		{
			float deltaRa = tracker.raPerSecond * Time.deltaTime;
			tracker.coords.rightAscention = ((tracker.coords.rightAscention + deltaRa + 24) % 48) - 24;

			var fwd = tracker.coords
				.ToHorizontal(geographicCoordsSO.value, lst)
				.ToVector3();
			tracker.transform.rotation = Quaternion.LookRotation(fwd, Vector3.up);
		}

	}

}