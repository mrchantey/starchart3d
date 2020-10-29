using System;
using UnityEngine;
using UnityEngine.UI;
namespace Ahoy
{

    [ExecuteInEditMode]
    public class WorldToWorldRect : InvocableMono
    {



        // [Header("Ensure rect is anchored at bottom left")]
        public RectTransform rect;
        public Transform target;
        RectTransform canvasRect;
        public float quadOffset = 1f;
        public Vector3 offset = Vector3.up * 0.5f;

        void OnEnable()
        {
            rect.anchorMin = Vector2.one * 0.5f;
            rect.anchorMax = Vector2.one * 0.5f;
            canvasRect = rect.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        }


        public override void Invoke()
        {
            var targetWorld = target.transform.position + offset;
            var targetLocal = CameraUtility.CachedCamera().transform.InverseTransformPoint(targetWorld);
            // var thetaX = Mathf.Cos(targetLocal.)
            var polarX = Math.CartesianToPolar(targetLocal.ZX());
            var polarY = Math.CartesianToPolar(targetLocal.ZY());

            var quadX = Mathf.Tan(polarX.theta) * quadOffset;
            var quadY = Mathf.Tan(polarY.theta) * quadOffset;

            // quadX.

            // Vector3 viewPortPos = CameraUtility.CachedCamera().WorldToViewportPoint(targetPos);
            // Vector2 screenPos = viewPortPos * canvasRect.sizeDelta;
            rect.anchoredPosition = new Vector2(quadX, quadY);
            // Debug.Log($"target - local:{targetLocal}");
            rect.gameObject.SetActive(targetLocal.z > 0);
        }

    }
}