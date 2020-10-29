using UnityEngine;
using System.Collections.Generic;
using System.Linq;
namespace Ahoy.Shaders
{

    public class ClickRipple : MonoBehaviour
    {

        public Material clickRippleMat;
        List<ClickRippleInfo> rippleInfos;
        int maxRipples = 1000;
        Plane plane;

        private void OnEnable()
        {
            rippleInfos = new List<ClickRippleInfo>();
            plane = new Plane(Vector3.forward, transform.position);
            var ris = new Vector4[maxRipples];
            clickRippleMat.SetVectorArray("rippleObjects", ris);
            clickRippleMat.SetInt("rippleObjectCount", 0);
            clickRippleMat.SetFloat("timeStamp", 0);
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
                AddRipple(pos);
            }
            clickRippleMat.SetFloat("timeStamp", Time.time);
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
            int arrSize = rippleInfos.Count == 0 ? 1 : rippleInfos.Count;
            var ris = new Vector4[arrSize];
            if (rippleInfos.Count > maxRipples)
                Debug.LogWarning($"number of ripples exceeds max, please reduce ripple duration");
            for (int i = 0; i < rippleInfos.Count; i++)
            {
                ris[i] = new Vector4(rippleInfos[i].position.x, rippleInfos[i].position.y, rippleInfos[i].position.z, rippleInfos[i].timeStamp);
            }
            clickRippleMat.SetInt("rippleObjectCount", rippleInfos.Count);
            clickRippleMat.SetVectorArray("rippleObjects", ris);
        }

        private void OnDestroy()
        {
            clickRippleMat.SetInt("rippleObjectCount", 0);
        }

    }

}