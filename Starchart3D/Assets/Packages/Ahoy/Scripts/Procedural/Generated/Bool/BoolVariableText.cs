//
//
//	THS FILE IS AUTO GENERATED
//	DO NOT EDIT DIRECTLY
//



/*AUTO SCRIPT*/using UnityEngine;
/*AUTO SCRIPT*/using UnityEngine.UI;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/namespace Ahoy
/*AUTO SCRIPT*/{
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/    public class BoolVariableText : InvocableMono
/*AUTO SCRIPT*/    {
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public BoolVariable variable;
/*AUTO SCRIPT*/        public Text text;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/        public override void Invoke()
/*AUTO SCRIPT*/        {
/*AUTO SCRIPT*/            text.text = $"{variable.name}: {variable.value}";
/*AUTO SCRIPT*/        }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/    }
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/}