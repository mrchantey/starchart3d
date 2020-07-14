using UnityEngine;
using Ahoy;

namespace Starchart3D
{

	public class EquatorialOrigin : MonoBehaviour
	{

		public bool debug = true;

		public GeographicCoordsSO geocoordsSO;
		public AstrobodiesSO astrobodiesSO;
		public DoubleVariable day;
		public QuaternionVariable rotationVariable;

		void Update()
		{
			var lst = StarMath.LocalSiderealTime(astrobodiesSO.value, geocoordsSO.value, day.value);
			var dirVernalEq = new EquatorialCoords(0, 0)
				.ToHorizontal(geocoordsSO.value, lst)
				.ToVector3();

			var dirCelestPole = new EquatorialCoords(0, 90)
				.ToHorizontal(geocoordsSO.value, lst)
				.ToVector3();

			var rotation = Quaternion.LookRotation(dirVernalEq, dirCelestPole);
			rotationVariable.value = rotation;
			transform.rotation = rotation;
		}

		void OnDrawGizmos()
		{
			this.DrawPoseGizmo();
			if (!debug) return;
		}
	}
}



// //POINTS TO VERNAL EQUINOX
// var (azVernal, altVernal) = RaDecToAzAlt(latitude, lonHr, 0, 0, sidTime);
// var dirVernal = Quaternion.Euler((float)altVernal, (float)azVernal, 0) * Vector3.forward;


// //POINTS TO NORTH STAR
// //this will be virtually constant
// var (azNorth, altNorth) = RaDecToAzAlt(latitude, lonHr, 0, 90, sidTime);
// var dirNorth = Quaternion.Euler((float)altNorth, (float)azNorth, 0) * Vector3.forward;
// // if (debug) Debug.Log($"Topocentric - azVernal: {azVernal.ToString("0.0")}\taltFwd: {altFwd.ToString("0.0")}\t azNorth: {azNorth.ToString("0.0")}\taltNorth: {altNorth}");

// transform.rotation = Quaternion.LookRotation(dirVernal, dirNorth);
// transform.rotation = Quaternion.LookRotation(dirNorth, dirVernal);


// }
/*
SCANDINAVIA TEST VALUES
SUN
AZ 15.676702976646197
ALT -17.95700763078881


MOON
RA = 309.4881_deg
Decl = -19.0741_deg



SYDNEY TEST VALUES
10/07/2020 10:30:00 UT
TEST SUN
az 112°08'18" alt  -17°27'16"
TEST MOON
az 270°53'51" alt  -42°23'34"
*/