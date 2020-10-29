//
//
//	THS FILE IS AUTO GENERATED
//	DO NOT EDIT DIRECTLY
//



/*AUTO SCRIPT*/using UnityEngine;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/namespace Ahoy
/*AUTO SCRIPT*/{
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/    public class DoubleArrayPoolInvocableMono : InvocableMono
/*AUTO SCRIPT*/    {
/*AUTO SCRIPT*/        [Range(0, 12400)]
/*AUTO SCRIPT*/        public int poolSize = 512;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public DoubleArrayPoolUnityEvent onInvoke;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        DoubleArrayPool array;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        void OnEnable()
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            array = new DoubleArrayPool(poolSize);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public void Push(double val)
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            array.Push(val);
/*AUTO SCRIPT*/            Invoke();
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public double Pop()
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            var val = array.Pop();
/*AUTO SCRIPT*/            Invoke();
/*AUTO SCRIPT*/            return val;
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public override void Invoke()
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            onInvoke.Invoke(array);
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/    }
/*AUTO SCRIPT*/}