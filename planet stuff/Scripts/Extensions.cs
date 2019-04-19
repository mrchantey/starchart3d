using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Extensions
{

    public static string ElementsToString(this Array arr, string separator = "\n")
    {
        var str = "";
        foreach (var elt in arr)
        {
            str += elt.ToString() + separator;
        }
        return str;
    }

    public static string[] Replace(this String[] arr, char oldChar, char newChar = '\0')
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = arr[i].Replace(oldChar, newChar);
        }
        return arr;
    }

}
