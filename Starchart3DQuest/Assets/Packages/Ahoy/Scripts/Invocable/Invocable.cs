using UnityEngine;

namespace Ahoy
{

    public class Invocable : InvocableMono
    {

        public NullUnityEvent onInvoke;

        public override void Invoke()
        {
            // base.Invoke();
            onInvoke.Invoke();
        }

    }

}