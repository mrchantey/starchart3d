using UnityEngine;
using UnityEngine.UI;
using Ahoy;

namespace Starchart3D
{

	public class CoordinatesUI : MonoBehaviour
	{
		public bool debug = true;

		public Text text;
		public GeographicCoordsSO geocoordsSO;
		public AstrobodiesSO astrobodiesSO;
		public CelestialCoordinatesType coordsType;
		public FloatVariable day;

		// HorizontalCoords horizontalCoords = new HorizontalCoords();


		void Start()
		{
		}

		void Update()
		{
			// var ha = new HorizontalCoords(transform.rotation);
			// var sidTime = StarMath.LocalSiderealTime(astrobodiesSO.value, geocoordsSO.value, (double)day.value);
			// // var ea = ha.ToEquatorial(geocoordsSO.value, sidTime);
			// var hb = ea.ToHorizontal(geocoordsSO.value, sidTime);

			// Debug.Log($"CoordinatesUI - HA: {ha}\tEA: {ea}\tHB: {hb}");


			var horiz = new HorizontalCoords(transform.rotation);

			switch (coordsType)
			{

				case CelestialCoordinatesType.Horizontal:
					text.text = $"";
					text.text = $"Az: {horiz.azimuth.ToString("0.0")}\nAlt: {horiz.altitude.ToString("0.0")}";
					break;
				case CelestialCoordinatesType.Equatorial:
					// var sidTime = StarMath.LocalSiderealTime(astrobodiesSO.value, geocoordsSO.value, (double)day.value);
					// var equ = horiz.ToEquatorial(geocoordsSO.value, sidTime);
					// if (debug) Debug.Log($"CoordinatesUI - equ: {equ}");
					// text.text = $"RA: {equ.rightAscention.ToString("0.0")}\nDec: {equ.declination.ToString("0.0")}";
					break;
			}
		}


	}
}