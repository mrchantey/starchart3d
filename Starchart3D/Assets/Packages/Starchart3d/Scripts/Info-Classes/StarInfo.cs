using UnityEngine;
using Ahoy;

namespace Starchart3D
{
	[System.Serializable]
	public class StarInfo
	{

		public int hygId;
		public int hipId;
		public float apparentMagnitude;//magnitude from earth
		public float absoluteMagnitude;//actual magnitude
		public string properName;
		public float colorIndex;
		public Color color;

		public Vector3 position;
		public Vector3 velocity;

		public StarInfo(string csvLine)
		{
			var lines = csvLine.Split(',');

			hygId = IOUtility.SafeIntParse(lines[0]);
			hipId = IOUtility.SafeIntParse(lines[1]);
			properName = lines[6];
			apparentMagnitude = IOUtility.SafeFloatParse(lines[13]);
			absoluteMagnitude = IOUtility.SafeFloatParse(lines[14]);

			colorIndex = IOUtility.SafeFloatParse(lines[16]);
			color = ColorUtility.ColorIndexToRGB(colorIndex);

			position = new Vector3(
			  IOUtility.SafeFloatParse(lines[17]),
			  IOUtility.SafeFloatParse(lines[18]),
			  IOUtility.SafeFloatParse(lines[19])
			);
			velocity = new Vector3(
			  IOUtility.SafeFloatParse(lines[20]),
			  IOUtility.SafeFloatParse(lines[21]),
			  IOUtility.SafeFloatParse(lines[22])
			);
			position = Vector3.ClampMagnitude(position, 1000);
		}

	}
}