



using UnityEngine;

namespace Starchart3D
{

	public class TimeManager : MonoBehaviour
	{



		[Range(-100000, 100000)]
		public float currentYear = 2018;

		public float yearsPerSecond = 10;

		public bool autoUpdate;
		public bool reset;

		void OnValidate()
		{
			SetJ2000Offset(currentYear);
			if (reset)
			{
				reset = false;
				currentYear = 2000;
				SetJ2000Offset(currentYear);
			}
		}

		void Update()
		{
			if (autoUpdate)
			{
				currentYear += yearsPerSecond * Time.deltaTime;
				SetJ2000Offset(currentYear);
			}

		}


		void SetJ2000Offset(float year)
		{
			Shader.SetGlobalFloat("J2000Offset", year - 2000);
		}

	}
}