using UnityEngine;
using System.Collections.Generic;

namespace Ahoy
{

    public class KeyboardEvents : MonoBehaviour
    {

        public List<KeyboardEvent> events;


        private void Update()
        {
            events.ForEach(e =>
            {
                if (Input.GetKeyDown(e.keyCode))
                    e.onKeyDown.Invoke(e.keyCode);
                if (Input.GetKey(e.keyCode))
                    e.onKey.Invoke(e.keyCode);
                if (Input.GetKeyUp(e.keyCode))
                    e.onKeyUp.Invoke(e.keyCode);
            });
        }

    }
    [System.Serializable]
    public struct KeyboardEvent
    {
        public KeyCode keyCode;
        public KeyCodeUnityEvent onKeyDown;
        public KeyCodeUnityEvent onKey;
        public KeyCodeUnityEvent onKeyUp;
    }

}