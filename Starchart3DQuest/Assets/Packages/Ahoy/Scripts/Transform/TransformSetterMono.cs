using UnityEngine;

namespace Ahoy
{

    public class TransformSetterMono : InvocableMono
    {

        public TransformSetter setter;


        public override void Invoke()
        {
            setter.Initialize();
        }

        protected override void Update()
        {
            setter.Update();
            base.Update();
        }
    }
}