using UnityEngine;
using Ahoy;

namespace Starchart3D
{

	public enum TimeType
	{
		Seconds,
		Minutes,
		Hours,
		Days,
		Years,
	}

	public class TimeManager : InvocableMono
	{
		public DoubleVariable day;

		// [Range(-12, 12)]
		// public int timezone = 10;

		// [Range(-30, 30)]
		public bool setToCurrentTimeOnStart = true;
		public TimeType timeType = TimeType.Days;
		public bool useDeltaTime = true;
		public double timeIncrement = 1;


		void Awake()
		{
			if (setToCurrentTimeOnStart)
				day.value = StarMath.UTCDateTimeToY2KDay(System.DateTime.UtcNow);
		}


		double ParseTimeType()
		{
			var increment = useDeltaTime ? timeIncrement * Time.deltaTime : timeIncrement;
			switch (timeType)
			{
				case TimeType.Seconds:
					return increment * StarMath.secondsToDays;
				case TimeType.Minutes:
					return increment * StarMath.minutesToDays;
				default:
				case TimeType.Days:
					return increment;
				case TimeType.Years:
					return increment * StarMath.tropicalYear;
			}
		}

		public override void Invoke()
		{
			day.value += ParseTimeType();
		}

	}
}