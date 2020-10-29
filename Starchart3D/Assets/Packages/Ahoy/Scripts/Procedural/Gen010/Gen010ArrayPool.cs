using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Ahoy
{

    public struct Gen010ArrayPool : IEnumerable<gen010>
    {

        public gen010[] m_array;
        int index;
        // public int Length { get { return m_array.Length; } }
        public int Length { get; private set; }

        public Gen010ArrayPool(int length)
        {
            m_array = new gen010[length];
            index = -1;
            Length = 0;
            // Length = 0;
        }

        public void Push(gen010 val)
        {
            index = (index + 1) % m_array.Length;
            Length = Mathf.Clamp(Length + 1, 0, m_array.Length - 1);
            m_array[index] = val;
        }

        public gen010 Pop()
        {
            index = index - 1;
            if (index < 0) index = m_array.Length - 1;
            Length = Mathf.Clamp(Length - 1, 0, m_array.Length - 1);
            return m_array[index];
        }


        public gen010 this[int key]
        {
            get => m_array[(index + key) % Length];
            // get
            // {
            //     var i = (index + key) % Length;
            //     Debug.Log($"getting element at {i}");
            //     return m_array[i];
            // }
            // set => m_array[(index + key) % m_array.Length] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<gen010> IEnumerable<gen010>.GetEnumerator()
        {
            return (IEnumerator<gen010>)GetEnumerator();
        }

        public Gen010ArrayPoolEnum GetEnumerator()
        {
            return new Gen010ArrayPoolEnum(this);
        }
    }

    public class Gen010ArrayPoolEnum : IEnumerator<gen010>
    {
        public Gen010ArrayPool arrayPool;
        int position = -1;

        public Gen010ArrayPoolEnum(Gen010ArrayPool arrayPool)
        {
            this.arrayPool = arrayPool;
        }

        public bool MoveNext()
        {
            position++;
            return (position < arrayPool.Length);
        }

        public void Reset()
        {
            position = -1;
        }
        object IEnumerator.Current { get { return Current; } }
        public gen010 Current { get { try { return arrayPool[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } } }

        public void Dispose() { }
    }
}