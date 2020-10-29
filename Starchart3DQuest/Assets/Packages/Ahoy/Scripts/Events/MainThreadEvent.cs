using UnityEngine;

namespace Ahoy
{
    [ExecuteAlways]
    public class MainThreadEvent : MonoBehaviour
    {

        public System.Action action;


        private void Start()
        {
            action();
            GameObject.DestroyImmediate(gameObject);
        }

    }

}