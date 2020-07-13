using UnityEngine;
using Ahoy;

namespace Starchart3D
{

	public class DayMono : InvocableMono
	{
		public FloatVariable day;

		// [Range(-12, 12)]
		// public int timezone = 10;

		[Range(-30, 30)]
		public float daysPerSecond = 1;
		void Awake()
		{
			day.value = (float)StarMath.UTCDateTimeToY2KDay(System.DateTime.UtcNow);
			// base.Awake();
		}

		public override void Invoke()
		{
			day.value += daysPerSecond * Time.deltaTime;
		}

	}
}