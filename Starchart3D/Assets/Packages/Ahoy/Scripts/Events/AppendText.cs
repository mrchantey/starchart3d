using UnityEngine;
using UnityEngine.UI;

namespace Ahoy
{


    public class AppendText : MonoBehaviour
    {

        public Text text;

        public void Append(string str)
        {
            text.text += str;
        }

    }

}