using UnityEngine;
using Ahoy;

namespace Starchart3D
{

	public enum CelestialCoordinateType
	{
		Horizontal,
		Equatorial,
		Ecliptic
	}



	public class CelestialOrigin : MonoBehaviour
	{

		public bool debug = true;
		public bool correctForPrecession = true;

		public CelestialCoordinateType coordinateType;
		public GeographicCoordsSO geocoordsSO;
		public AstrobodiesSO astrobodiesSO;
		public DoubleVariable day;
		public QuaternionVariable equatorialOrigin;

		void Update()
		{
			var lst = StarMath.LocalSiderealTime(astrobodiesSO.value, geocoordsSO.value, day.value);
			var obl_ecl = StarMath.ObliquityOfEcliptic(day.value);

			// var dirVernalEq_equatorial = new EquatorialCoords(0,0);


			var dirVernalEquinox_equ = new EquatorialCoords(0, 0);
			var dirCelestialPole_equ = new EquatorialCoords(0, 90);
			if (correctForPrecession)
			{
				dirVernalEquinox_equ = dirVernalEquinox_equ.ToCorrectedPrecession(day.value, obl_ecl);
				dirCelestialPole_equ = dirCelestialPole_equ.ToCorrectedPrecession(day.value, obl_ecl);
			}
			var dirVernalEquinox_vec = dirVernalEquinox_equ.ToVector3();
			var dirCelestialPole_vec = dirCelestialPole_equ.ToVector3();

			Vector3 dirForward, dirUp;

			switch (coordinateType)
			{
				default:
				case CelestialCoordinateType.Horizontal:
					dirForward = dirVernalEquinox_equ
						   .ToHorizontal(geocoordsSO.value, lst)
						   .ToVector3();
					dirUp = dirCelestialPole_equ
						.ToHorizontal(geocoordsSO.value, lst)
						.ToVector3();
					break;
				case CelestialCoordinateType.Equatorial:
					dirForward = dirVernalEquinox_vec;
					dirUp = dirCelestialPole_vec;
					break;
				case CelestialCoordinateType.Ecliptic:
					dirForward = Vector3.forward;
					dirUp = Vector3.up;
					break;

			}
			transform.localRotation = Quaternion.LookRotation(dirForward, dirUp);
			equatorialOrigin.value = Quaternion.LookRotation(dirVernalEquinox_vec, dirCelestialPole_vec);
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