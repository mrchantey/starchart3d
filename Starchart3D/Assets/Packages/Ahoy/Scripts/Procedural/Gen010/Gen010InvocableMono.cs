using UnityEngine;

namespace Ahoy
{

    public class Gen010InvocableMono : InvocableMono
    {

        public gen010 value;

        public Gen010UnityEvent onInvoke;

        public override void Invoke()
        {
            onInvoke.Invoke(value);
        }

    }

}