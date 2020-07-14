using UnityEngine;
using Ahoy;

namespace Starchart3D
{

	public class DayMono : InvocableMono
	{
		public DoubleVariable day;

		// [Range(-12, 12)]
		// public int timezone = 10;

		[Range(-30, 30)]
		public double daysPerSecond = 1;
		void Awake()
		{
			day.value = StarMath.UTCDateTimeToY2KDay(System.DateTime.UtcNow);
		}

		public override void Invoke()
		{
			day.value += daysPerSecond * Time.deltaTime;
		}

	}
}