using UnityEngine;

namespace Starchart3D
{

	public enum Direction
	{
		Right,
		Left,
		Up,
		Down,
		Forward,
		Back
	}

	[System.Serializable]
	public struct CoordinateConversionInfo
	{
		public Direction right;
		public Direction up;
		public Direction forward;

		public Vector3 ParseVector3(Vector3 vec)
		{
			var parsed = vec;
			ParseDirection(right, ref parsed, vec.x);
			ParseDirection(up, ref parsed, vec.y);
			ParseDirection(forward, ref parsed, vec.z);
			return parsed;
		}

		void ParseDirection(Direction dir, ref Vector3 vec, float val)
		{
			switch (dir)
			{
				case Direction.Right:
					vec.x = val;
					break;
				case Direction.Left:
					vec.x = -val;
					break;
				case Direction.Up:
					vec.y = val;
					break;
				case Direction.Down:
					vec.y = -val;
					break;
				case Direction.Forward:
					vec.z = val;
					break;
				case Direction.Back:
					vec.z = -val;
					break;
			}
		}

		public static readonly CoordinateConversionInfo Default = new CoordinateConversionInfo()
		{
			right = Direction.Right,
			up = Direction.Up,
			forward = Direction.Forward
		};

		public static readonly CoordinateConversionInfo EquatorialToUnity = new CoordinateConversionInfo()
		{
			right = Direction.Forward,
			up = Direction.Left,
			forward = Direction.Up
		};


	}
}