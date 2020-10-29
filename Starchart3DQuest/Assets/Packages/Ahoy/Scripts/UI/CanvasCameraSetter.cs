using UnityEngine;
using UnityEngine.UI;

namespace Ahoy
{

    public class CanvasCameraSetter : MonoBehaviour
    {


        void OnEnable()
        {
            GetComponent<Canvas>().worldCamera = CameraUtility.CachedCamera();
        }

    }
}