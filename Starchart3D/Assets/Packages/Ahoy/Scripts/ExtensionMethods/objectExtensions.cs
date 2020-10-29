// using UnityEngine;
using Ahoy;
using System;

public static class objectExtensions
{

	public static string ToDec2(this object obj)
	{
		return ((float)obj).ToString("0.00");
	}

}