using UnityEngine;
using System.Collections.Generic;
using System.Linq;
namespace Ahoy.Shaders
{

    public class ClickRippleDX11 : MonoBehaviour
    {

        public Material clickRippleMat;
        List<ClickRippleInfo> rippleInfos;
        ComputeBuffer rippleObjects;
        [Range(1, 512)]
        public int maxRipples = 32;
        // Vector3 debugPos;
        Plane plane;

        private void OnEnable()
        {
            rippleInfos = new List<ClickRippleInfo>();
            rippleObjects = new ComputeBuffer(maxRipples, sizeof(float) * 4);
            clickRippleMat.SetBuffer("rippleObjects", rippleObjects);
            plane = new Plane(Vector3.forward, transform.position);
        }

        private void Start()
        {
            SetMaterial();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
                var enter = 0f;
                if (!plane.Raycast(ray, out enter))
                    return;
                var pos = ray.GetPoint(enter);
                // debugPos = pos;
                AddRipple(pos);
            }
        }

        public void AddRipple(Vector3 position)
        {
            var ri = new ClickRippleInfo();
            ri.timeStamp = Time.time;
            ri.position = position;
            rippleInfos.Add(ri);
            FilterRippleInfos();
            SetMaterial();
        }

        void FilterRippleInfos()
        {
            var duration = clickRippleMat.GetFloat("_Duration");
            rippleInfos = rippleInfos
            .Where(ri => (Time.time - ri.timeStamp) < duration)
            .ToList();
        }

        void SetMaterial()
        {
            var ris = new ClickRippleInfo[maxRipples];
            if (rippleInfos.Count > maxRipples)
                Debug.LogWarning($"number of ripples exceeds max, please reduce ripple duration or increase max ripple count");
            // Debug.Log($"setting {rippleInfos.Count} ripples");
            for (int i = 0; i < maxRipples; i++)
            {
                if (i < rippleInfos.Count)
                    ris[i] = rippleInfos[i];
                else
                {
                    ris[i] = new ClickRippleInfo();
                    ris[i].timeStamp = -10000;
                }

            }
            // foreach (var ri in ris)
            // {
            //     Debug.Log(ri.timeStamp);
            // }
            rippleObjects.SetData(ris);
            // clickRippleMat.SetBuffer("rippleObjects", rippleObjects);

        }
        private void OnDisable()
        {
            rippleObjects.Dispose();
        }

        private void OnDrawGizmos()
        {
            // Gizmos.DrawLine(Camera.main.transform.position, debugPos);
        }

    }

}