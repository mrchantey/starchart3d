// using UnityEngine;
using System;

namespace Ahoy
{

    public enum TransformSpace
    {
        World,
        Local,
        Self
    }

    public enum TranslationSpace
    {
        World,
        Parent
    }

    public static class Utility
    {
        static readonly DateTime epoch = new DateTime(1992, 2, 20);

        public static double GetTime()
        {
            return DateTime.Now.Subtract(epoch).TotalMilliseconds;
        }

    }

}