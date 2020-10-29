using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Ahoy
{
    public class AssetEventListener : MonoBehaviour
    {

        public AssetEvent assetEvent;
        public UnityEvent response;


        protected virtual void OnEnable()
        {
            assetEvent.AddListener(response);
        }
        protected virtual void OnDisable()
        {
            assetEvent.RemoveListener(response);
        }
    }


}