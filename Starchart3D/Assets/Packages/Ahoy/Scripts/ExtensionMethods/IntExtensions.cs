using UnityEngine;
using System;

namespace Ahoy
{
	public static class IntExtensions
	{
		public static T[] SelectArray<T>(this int num, Func<int, T> func)
		{
			var arr = new T[num];

			for (int i = 0; i < num; i++)
			{
				arr[i] = func(i);
			}
			return arr;
		}
	}
}