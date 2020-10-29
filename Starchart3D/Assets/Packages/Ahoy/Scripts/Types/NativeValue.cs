using UnityEngine;
using Unity.Collections;
using System;
namespace Ahoy
{

    public struct NativeValue<T> : IEquatable<NativeValue<T>>, IEquatable<T> where T : struct, IEquatable<T>
    {
        public NativeArray<T> arr;

        public void Init(Allocator allocator = Allocator.Persistent)
        {
            arr = new NativeArray<T>(1, allocator);
        }

        public T Get()
        {
            return arr[0];
        }

        public void Set(T val)
        {
            arr[0] = val;
        }
        public void Dispose()
        {
            arr.Dispose();
        }

        public bool Equals(NativeValue<T> other)
        {
            return arr[0].Equals(other.arr[0]);
        }
        public bool Equals(T other)
        {
            return arr[0].Equals(other);
        }



        public override string ToString()
        {
            return arr[0].ToString();
        }

    }

}