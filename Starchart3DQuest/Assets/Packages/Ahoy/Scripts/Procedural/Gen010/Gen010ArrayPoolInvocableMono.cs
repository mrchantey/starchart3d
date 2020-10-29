using UnityEngine;

namespace Ahoy
{

    public class Gen010ArrayPoolInvocableMono : InvocableMono
    {
        [Range(0, 12400)]
        public int poolSize = 512;

        public Gen010ArrayPoolUnityEvent onInvoke;

        Gen010ArrayPool array;

        void OnEnable()
        {
            array = new Gen010ArrayPool(poolSize);
        }

        public void Push(gen010 val)
        {
            array.Push(val);
            Invoke();
        }

        public gen010 Pop()
        {
            var val = array.Pop();
            Invoke();
            return val;
        }

        public override void Invoke()
        {
            onInvoke.Invoke(array);
        }

    }
}