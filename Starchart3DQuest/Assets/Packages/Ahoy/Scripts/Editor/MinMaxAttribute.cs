using UnityEngine;
using UnityEditor;



namespace Ahoy
{

	public class MinMaxAttribute : PropertyAttribute
	{
		public float minLimit;
		public float maxLimit;


		public MinMaxAttribute(float minLimit, float maxLimit)
		{
			this.minLimit = minLimit;
			this.maxLimit = maxLimit;
		}
	}
}

#if UNITY_EDITOR
#endif