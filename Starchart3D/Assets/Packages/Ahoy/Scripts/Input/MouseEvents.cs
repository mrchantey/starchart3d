using UnityEngine;

namespace Ahoy
{

    public class MouseEvents : MonoBehaviour
    {


        public NullUnityEvent onMouseLeftDown;
        public NullUnityEvent onMouseLeftUp;
        public NullUnityEvent whileMouseLeft;
        public NullUnityEvent onMouseRightDown;
        public NullUnityEvent whileMouseRight;
        public NullUnityEvent onMouseRightUp;
        public FloatUnityEvent onMouseScroll;

        private void Update()
        {


            if (Input.GetMouseButtonDown(0))
                onMouseLeftDown.Invoke();
            if (Input.GetMouseButton(0))
                whileMouseLeft.Invoke();
            if (Input.GetMouseButtonUp(0))
                onMouseLeftUp.Invoke();

            if (Input.GetMouseButtonDown(1))
                onMouseRightDown.Invoke();
            if (Input.GetMouseButton(1))
                whileMouseRight.Invoke();
            if (Input.GetMouseButtonUp(1))
                onMouseRightUp.Invoke();
            if (Input.mouseScrollDelta.y != 0)
                onMouseScroll.Invoke(Input.mouseScrollDelta.y);
        }

    }

}