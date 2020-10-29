using UnityEngine;
using UnityEngine.UI;
using Ahoy;

namespace Starchart3D
{

	public class CoordinatesUI : MonoBehaviour
	{
		public bool debug = true;
		public CelestialOrigin celestialOrigin;

		public Text text;
		public CelestialCoordinateType coordsType;

		public QuaternionVariable equatorialOrigin;
		public QuaternionVariable cameraRotation;

		void Update()
		{
			if (celestialOrigin.coordinateType != CelestialCoordinateType.Horizontal)
			{
				text.text = "";
				return;
			}
			switch (coordsType)
			{
				case CelestialCoordinateType.Horizontal:
				default:
					var horiz = new HorizontalCoords(cameraRotation.value);
					text.text = $"Az: {horiz.azimuth.ToString("0.0")}\nAlt: {horiz.altitude.ToString("0.0")}";
					break;
				case CelestialCoordinateType.Equatorial:
					var rot = Quaternion.Inverse(equatorialOrigin.value) * cameraRotation.value;
					var equ = new EquatorialCoords(rot);
					text.text = $"RA: {equ.rightAscention.ToString("0.0")}\nDec: {(equ.declination).ToString("0.0")}";
					break;
				case CelestialCoordinateType.Ecliptic:
					var ecl = EclipticCoords.FromQuaternionUntested(cameraRotation.value);
					text.text = $"Lon: {ecl.longitude.ToString("0.0")}\nLat: {ecl.latitude.ToString("0.0")}";
					break;
			}
		}


	}
}