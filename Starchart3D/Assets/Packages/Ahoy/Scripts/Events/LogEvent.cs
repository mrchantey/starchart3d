using UnityEngine;

namespace Ahoy
{

    public class LogEvent : MonoBehaviour
    {




        public StringUnityEvent onLogMessage;

        void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        void HandleLog(string logString, string stackTrace, LogType type)
        {
            onLogMessage.Invoke(logString);
            // output = logString;
            // stack = stackTrace;
        }


    }

}