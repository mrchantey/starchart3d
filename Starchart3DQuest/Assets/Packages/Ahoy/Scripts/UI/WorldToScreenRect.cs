using UnityEngine;
using UnityEngine.UI;
namespace Ahoy
{

    [ExecuteInEditMode]
    public class WorldToScreenRect : InvocableMono
    {



        // [Header("Ensure rect is anchored at bottom left")]
        public RectTransform rect;
        public Transform target;
        RectTransform canvasRect;
        public Vector3 offset = Vector3.up * 0.2f;

        void OnEnable()
        {
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.zero;
            canvasRect = rect.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        }


        public override void Invoke()
        {
            var targetPos = target.transform.position + offset;
            Vector3 viewPortPos = CameraUtility.CachedCamera().WorldToViewportPoint(targetPos);
            Vector2 screenPos = viewPortPos * canvasRect.sizeDelta;
            rect.anchoredPosition = screenPos;
            rect.gameObject.SetActive(viewPortPos.z > 0);
        }

    }
}