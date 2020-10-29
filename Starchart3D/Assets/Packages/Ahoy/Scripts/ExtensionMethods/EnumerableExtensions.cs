using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Unity.Collections;
// namespace Ahoy
// {

public static class EnumerableExtensions

{
	public static T2 GetOrCreateValue<T1, T2>(this Dictionary<T1, T2> dict, T1 key) where T2 : new()
	{
		T2 value;
		if (dict.TryGetValue(key, out value))
			return value;
		value = new T2();
		dict.Add(key, value);
		return value;
	}
	public static T2 GetOrCreateValue<T1, T2>(this Dictionary<T1, T2> dict, T1 key, Action<T2> onNew) where T2 : new()
	{
		T2 value;
		if (dict.TryGetValue(key, out value))
			return value;
		value = new T2();
		onNew(value);
		dict.Add(key, value);
		return value;
	}

	public static void AddOrSet<T1, T2>(this Dictionary<T1, T2> dict, T1 key, T2 value)
	{
		if (dict.ContainsKey(key))
			dict[key] = value;
		else
			dict.Add(key, value);
	}

	public static void Deconstruct<K, V>(this KeyValuePair<K, V> kvp, out K key, out V value)
	{
		key = kvp.Key;
		value = kvp.Value;
	}

	public static bool TryAdd<T>(this List<T> source, T item)
	{
		if (source.Contains(item))
			return false;
		source.Add(item);
		return true;
	}

	public static bool TryRemove<T>(this List<T> source, T item)
	{
		if (!source.Contains(item))
			return false;
		source.Remove(item);
		return true;
	}


	public static IEnumerable<T> Clone<T>(this IEnumerable<T> arr) where T : ICloneable
	{
		return arr.Select(item => (T)item.Clone());
	}


	public static void ForEach<T>(this IEnumerable<T> source, System.Action<T> action)
	{
		foreach (var element in source)
		{
			action(element);
		}
	}

	public static void ForEach<T>(this IEnumerable<T> arr, System.Action<T, int> action)
	{
		for (int i = 0; i < arr.Count(); i++)
		{
			action(arr.ElementAt(i), i);
		}
	}

	public static string ElementsToString<T>(this IEnumerable<T> arr, string separator = ",")
	{
		return String.Join(separator, arr.Select(p => p.ToString()).ToArray());
	}
	public static string ElementsToStringFormattable<T>(this IEnumerable<T> arr, string separator = ",", string format = "") where T : IFormattable
	{
		return String.Join(separator, arr.Select(p => p.ToString(format, CultureInfo.CurrentCulture)).ToArray());
	}




	public static bool ElementsAreEqual<T>(this T[] arr1, T[] arr2) where T : IEquatable<T>
	{
		if (arr1.Length != arr2.Length)
			return false;
		for (int i = 0; i < arr1.Length; i++)
		{
			if (!arr1[i].Equals(arr2[i]))
				return false;
		}
		return true;
	}
	// public static T[] Combine<T>(this T[] arr1, T[] arr2) where T : IEquatable<T>
	// {
	//     if (arr1.Length != arr2.Length)
	//         return false;
	//     for (int i = 0; i < arr1.Length; i++)
	//     {
	//         if (!arr1[i].Equals(arr2[i]))
	//             return false;
	//     }
	//     return true;
	// }



	public static IEnumerable<T> SubArray<T>(this IEnumerable<T> source, int startIndex, int count)
	{
		return source.Skip(startIndex).Take(count);
	}

	public static T[][] ToChunks<T>(this IEnumerable<T> source, int chunkSize)
	{
		var arrLen = source.Count();
		if (source == null || arrLen <= 0 || chunkSize <= 0)
			return null;
		//convert to math.ceil
		var numChunks = Mathf.CeilToInt((float)arrLen / chunkSize);
		var chunkSizeLast = arrLen - (chunkSize * (numChunks - 1));
		if (chunkSizeLast == 0) chunkSizeLast = chunkSize;

		var chunks = new T[numChunks][];

		for (int i = 0; i < numChunks - 1; i++)
		{
			chunks[i] = new T[chunkSize];
		}
		chunks[numChunks - 1] = new T[chunkSizeLast];

		for (int i = 0; i < arrLen; i++)
		{
			var ci = i / chunkSize;//integer division
			var ai = i % chunkSize;
			chunks[ci][ai] = source.ElementAt(i);
		}
		return chunks;
	}

	public static T[][] ArrayToChunks<T>(T[] arr, int chunkSize)
	{
		if (arr == null || arr.Length <= 0 || chunkSize <= 0)
			return null;
		var numChunks = Mathf.CeilToInt((float)arr.Length / chunkSize);
		var chunkSizeLast = arr.Length - (chunkSize * (numChunks - 1));
		if (chunkSizeLast == 0) chunkSizeLast = chunkSize;

		var chunks = new T[numChunks][];

		for (int i = 0; i < numChunks - 1; i++)
		{
			chunks[i] = new T[chunkSize];
		}
		chunks[numChunks - 1] = new T[chunkSizeLast];

		for (int i = 0; i < arr.Length; i++)
		{
			var ci = i / chunkSize;//integer division
			var ai = i % chunkSize;
			chunks[ci][ai] = arr[i];
		}
		return chunks;
	}

}
// }