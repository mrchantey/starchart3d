using UnityEngine;
using UnityEngine.UI;
namespace Ahoy
{



    public class LogToUI : MonoBehaviour
    {

        public bool continuous;

        public Text text;


        private void OnEnable()
        {
            Application.logMessageReceived += HandleLogMessage;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= HandleLogMessage;
        }

        void HandleLogMessage(string message, string stackTrace, LogType logType)
        {
            if (continuous)
                text.text += $"\n{message}";
            else
                text.text = message;
        }
    }

}