using UnityEngine;
using System.Collections.Generic;

namespace Ahoy
{

    public class InvocableMonoArray : InvocableMono
    {
        public List<InvocableMono> invocables;

        public override void Invoke()
        {
            invocables.ForEach(i => i.Invoke());
        }


    }

}