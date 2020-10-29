using System;
using UnityEngine;
using System.Linq;


public static class ArraySegmentExtensions
{


    public static void SetElement<T>(this ArraySegment<T> seg, T val, int index)
    {
        seg.Array[seg.Offset + index] = val;
    }


    public static T GetElement<T>(this ArraySegment<T> seg, int index)
    {
        return seg.Array[seg.Offset + index];
    }
    public static ArraySegment<T> ToSeek<T>(this ArraySegment<T> seg, int offset)
    {
        return new ArraySegment<T>(seg.Array, seg.Offset + offset, seg.Count - offset);
    }
    public static ArraySegment<T> Copy<T>(this ArraySegment<T> seg)
    {
        return new ArraySegment<T>(seg.Array, seg.Offset, seg.Count);
    }



    public static void Insert<T>(this ArraySegment<T> seg, T[] arr2, int offset)
    {
        for (int i = 0; i < arr2.Length; i++)
        {
            seg.Array[seg.Offset + i + offset] = arr2[i];
        }
    }

    public static bool ElementsAreEqual<T>(this ArraySegment<T> seg1, ArraySegment<T> seg2) where T : IEquatable<T>
    {
        if (seg1.Count != seg2.Count)
            return false;
        for (int i = 0; i < seg1.Count; i++)
        {
            if (!seg1.Array[seg1.Offset + i].Equals(seg2.Array[seg2.Offset + i]))
                return false;
        }
        return true;
    }




    public static string SegmentElementsToString<T>(this ArraySegment<T> arr, int max = -1)
    {
        var str = "";
        if (arr.Count == 0)
            return str;
        if (max == -1) max = arr.Count;
        var len = max < arr.Count ? max : arr.Count;
        for (int i = arr.Offset; i < arr.Offset + max; i++)
        {
            str += arr.Array[i] + ",";
        }
        str.Remove(str.Length - 1, 1);
        return str;
    }
}
