using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Unity.Collections;
// namespace Ahoy
// {

public static class ArrayExtensions
{
	public static ArraySegment<T> ToSegment<T>(this T[] source)
	{
		return new ArraySegment<T>(source);
	}
	public static void ForEach2D<T>(this T[,] arr, Action<T, int, int> action)
	{
		for (int i = 0; i < arr.GetLength(0); i++)
		{
			for (int j = 0; j < arr.GetLength(1); j++)
			{
				action(arr[i, j], i, j);
			}
		}
	}
	public static T[,] Select2D<T>(this T[,] arr, Func<T, int, int, T> func)
	{
		for (int i = 0; i < arr.GetLength(0); i++)
		{
			for (int j = 0; j < arr.GetLength(1); j++)
			{
				arr[i, j] = func(arr[i, j], i, j);
			}
		}
		return arr;
	}


	public static int[] IndiciesToArray(this int[] source)
	{
		for (int i = 0; i < source.Length; i++)
		{
			source[i] = i;
		}
		return source;
	}

	public static void Insert<T>(this T[] arr1, T[] arr2, int startIndex, int length)
	{
		for (int i = 0; i < length; i++)
		{
			var i1 = startIndex + i;
			arr1[i1] = arr2[i];
		}
	}


	public static T[] Combine<T>(this T[] arr1, T[] arr2)
	{
		var arr = new T[arr1.Length + arr2.Length];
		for (int i = 0; i < arr1.Length; i++)
		{
			arr[i] = arr1[i];
		}
		for (int i = 0; i < arr2.Length; i++)
		{
			arr[arr1.Length + i] = arr2[i];
		}
		return arr;
	}

	public static void Insert<T>(this T[] arr1, T[] arr2, int startIndex)
	{
		for (int i = 0; i < arr2.Length; i++)
		{
			var i1 = startIndex + i;
			arr1[i1] = arr2[i];
		}
	}

}