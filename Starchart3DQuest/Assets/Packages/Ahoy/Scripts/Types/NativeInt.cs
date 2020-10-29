using UnityEngine;
using Unity.Collections;

namespace Ahoy
{

    public struct NativeInt
    {
        public NativeArray<int> arr;

        public void Init(Allocator allocator = Allocator.Persistent)
        {
            arr = new NativeArray<int>(1, allocator);
        }

        public int Get()
        {
            return arr[0];
        }

        public void Set(int val)
        {
            arr[0] = val;
        }
        public void Dispose()
        {
            arr.Dispose();
        }

        public static int operator +(NativeInt a, NativeInt b)
        {
            return a.arr[0] + b.arr[0];
        }



        public override string ToString()
        {
            return arr[0].ToString();
        }

    }

}