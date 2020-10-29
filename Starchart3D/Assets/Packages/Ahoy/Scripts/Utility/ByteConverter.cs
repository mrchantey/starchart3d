using UnityEngine;
using Unity.Collections;
// using Unity
namespace Ahoy
{

    public static class ByteConverter
    {
        public static void InsertBytes(NativeArray<byte> bytes, float val, int offset)
        {
            int valInt = (int)(val * floatMultiplier + floatMultiplier);
            InsertBytes(bytes, valInt, offset);
        }

        public static void InsertBytes(NativeArray<byte> bytes, int val, int offset)
        {
            bytes[offset + 3] = (byte)(val >> 24);
            bytes[offset + 2] = (byte)(val >> 16);
            bytes[offset + 1] = (byte)(val >> 8);
            bytes[offset] = (byte)val;
        }


        public static byte[] GetBytes(int val)
        {
            var bytes = new byte[4];
            bytes[3] = (byte)(val >> 24);
            bytes[2] = (byte)(val >> 16);
            bytes[1] = (byte)(val >> 8);
            bytes[0] = (byte)val;
            return bytes;
        }


        public static byte[] GetBytes(float val)
        {
            return FloatToBytesAsInt(val);
        }

        public static int ToInt32(byte[] bytes, int offset = 0)
        {
            var val = 0;
            val += (int)(bytes[offset + 3] << 24);
            val += (int)(bytes[offset + 2] << 16);
            val += (int)(bytes[offset + 1] << 8);
            val += (int)(bytes[offset + 0]);
            return val;
        }
        public static int ToInt32(NativeArray<byte> bytes, int offset)
        {
            var val = 0;
            val += (int)(bytes[offset + 3] << 24);
            val += (int)(bytes[offset + 2] << 16);
            val += (int)(bytes[offset + 1] << 8);
            val += (int)(bytes[offset + 0]);
            return val;
        }

        public static float ToFloat(byte[] bytes, int offset = 0)
        {
            return BytesAsIntToFloat(bytes, offset);
        }
        public static float ToFloat(NativeArray<byte> bytes, int offset = 0)
        {
            return BytesAsIntToFloat(bytes, offset);
        }


        static readonly int floatMultiplier = 100000;
        // static readonly int floatMultiplier = 1;
        // #                 b  m  t   1 billion
        static readonly double floatDivider = 0.00001;
        // static readonly double floatDivider = 1;


        static byte[] FloatToBytesAsInt(float val)
        {
            int valInt = (int)(val * floatMultiplier + floatMultiplier);
            // Debug.Log($"float to int - val int: {valInt}");
            return GetBytes(valInt);
        }

        static float BytesAsIntToFloat(byte[] bytes, int offset = 0)
        {
            var valInt = ToInt32(bytes, offset);
            return (float)((valInt - floatMultiplier) * floatDivider);
        }
        static float BytesAsIntToFloat(NativeArray<byte> bytes, int offset = 0)
        {
            var valInt = ToInt32(bytes, offset);
            return (float)((valInt - floatMultiplier) * floatDivider);
        }

        //TO DEPRECATE AND USE FLOAT EXTENSION METHOD
        public static bool AreAlmostEqual(float a, float b, double threshold = 0.0001)
        {
            return Mathf.Abs(b - a) < threshold;
        }
        public static bool ElementsAreAlmostEqual(this float[] arr1, float[] arr2, double threshold = 0.0001)
        {
            if (arr1.Length != arr2.Length)
                return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!AreAlmostEqual(arr1[i], arr2[i], threshold))
                    return false;
            }
            return true;
        }
        public static bool ElementsAreAlmostEqual(this NativeArray<float> arr1, float[] arr2, double threshold = 0.0001)
        {
            if (arr1.Length != arr2.Length)
                return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!AreAlmostEqual(arr1[i], arr2[i], threshold))
                    return false;
            }
            return true;
        }
        public static bool ElementsAreAlmostEqual(this NativeArray<float> arr1, NativeArray<float> arr2, double threshold = 0.0001)
        {
            if (arr1.Length != arr2.Length)
                return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!AreAlmostEqual(arr1[i], arr2[i], threshold))
                    return false;
            }
            return true;
        }


    }

}