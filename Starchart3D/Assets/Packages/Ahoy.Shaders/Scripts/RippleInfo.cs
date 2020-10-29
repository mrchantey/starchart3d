using UnityEngine;
using System;
namespace Ahoy.Shaders
{
    [Serializable]
    public struct RippleInfo
    {
        public Transform transform;
        [Range(0, 10)]
        public float falloff;
    }
    [Serializable]
    public struct ClickRippleInfo
    {
        public Vector3 position;
        public float timeStamp;
        // public bool isActive;
        // [Range(0, 10)]
        // public float falloff;
    }

    [Serializable]
    public struct RippleInfoValue
    {
        public Vector3 position;
        public float falloff;
        public RippleInfoValue(RippleInfo info)
        {
            position = info.transform.position;
            falloff = info.falloff;
        }
    }


}