using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Ahoy
{
    public class Gen010AssetEventListener : MonoBehaviour
    {

        public Gen010AssetEvent assetEvent;
        public Gen010UnityEvent response;


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