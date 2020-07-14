using UnityEngine;
using UnityEngine.UI;
using Ahoy;

namespace Starchart3D
{

	public class CoordinatesUI : MonoBehaviour
	{
		public bool debug = true;

		public Text text;
		public CelestialCoordinatesType coordsType;

		public QuaternionVariable equatorialRotation;
		public QuaternionVariable horizontalRotation;

		void Update()
		{
			switch (coordsType)
			{
				case CelestialCoordinatesType.Horizontal:
					text.text = $"";
					var horiz = new HorizontalCoords(horizontalRotation.value);
					text.text = $"Az: {horiz.azimuth.ToString("0.0")}\nAlt: {horiz.altitude.ToString("0.0")}";
					break;
				case CelestialCoordinatesType.Equatorial:
					// var localEquatorialRotation = Quaternion.Inverse(equatorialRotation.value) * horizontalRotation.value;
					// var equ = new EquatorialCoords(localEquatorialRotation);
					var rot = Quaternion.Inverse(equatorialRotation.value) * horizontalRotation.value;
					// var rot = equatorialRotation.value * horizontalRotation.value;
					var equ = new EquatorialCoords(rot);

					// var equ = new EquatorialCoords(equatorialRotation.value);
					text.text = $"RA: {equ.rightAscention.ToString("0.0")}\nDec: {(equ.declination).ToString("0.0")}";
					break;
			}
		}


	}
}