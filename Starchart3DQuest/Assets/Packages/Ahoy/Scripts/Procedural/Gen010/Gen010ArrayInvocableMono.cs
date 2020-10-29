using UnityEngine;

namespace Ahoy
{

    public class Gen010ArrayInvocableMono : InvocableMono
    {

        public gen010[] value;

        public Gen010ArrayUnityEvent onInvoke;


        public override void Invoke()
        {
            onInvoke.Invoke(value);
        }



    }

}