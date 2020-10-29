using UnityEngine;
using UnityEngine.UI;

namespace Ahoy
{

    public class Gen010VariableText : InvocableMono
    {

        public Gen010Variable variable;
        public Text text;

        public override void Invoke()
        {
            text.text = $"{variable.name}: {variable.value}";
        }

    }

}