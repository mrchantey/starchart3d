using UnityEngine;
namespace Ahoy
{
    public abstract class InvocableSO : ScriptableObject
    {

        public bool InvokeOnEnable;
        public bool InvokeOnDisable;

        protected virtual void OnEnable()
        {
            if (InvokeOnEnable)
                Invoke();
        }
        protected virtual void OnDisable()
        {
            if (InvokeOnDisable)
                Invoke();
        }

        public abstract void Invoke();
    }

}