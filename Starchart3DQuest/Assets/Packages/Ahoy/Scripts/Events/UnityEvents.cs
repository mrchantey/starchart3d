using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Ahoy
{
    [Serializable]
    public class NullUnityEvent : UnityEvent { }
    [System.Serializable]
    public class CollisionUnityEvent : UnityEvent<Collision> { }
    [System.Serializable]
    public class ColliderUnityEvent : UnityEvent<Collider> { }
    [System.Serializable]
    public class RaycastInfoUnityEvent : UnityEvent<RaycastInfo> { }

}