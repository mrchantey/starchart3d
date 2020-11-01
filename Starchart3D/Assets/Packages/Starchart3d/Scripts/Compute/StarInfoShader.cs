using UnityEngine;
using System.Linq;
using Ahoy;

namespace Starchart3D
{

	public struct StarInfoShader
	{
		public Vector3 position;
		public Vector3 velocity;
		public Vector4 color;
		public float apparentMagnitude;
		public float absoluteMagnitude;

		public StarInfoShader(StarInfo star)
		{
			position = star.position;
			velocity = star.velocity;
			color = star.color;
			apparentMagnitude = star.apparentMagnitude;
			absoluteMagnitude = star.absoluteMagnitude;
		}

		public static int stride = sizeof(float) * 12;

		public override string ToString()
		{
			// return $"position: {position}";
			return $"color: {color}";
		}
	}

}