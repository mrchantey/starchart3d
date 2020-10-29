using UnityEngine;
using System.Collections.Generic;

namespace Ahoy
{

	public class PropertyTest : MonoBehaviour
	{

		// [ReorderableList]
		// public Vector2 myWrongList;


		public IntList myIntList = new IntList() { 1, 2, 4, 6 };
#if UNITY_EDITOR
		[MinMax(0, 100)]
#endif
		public Vector2 myMinMax;

	}
}