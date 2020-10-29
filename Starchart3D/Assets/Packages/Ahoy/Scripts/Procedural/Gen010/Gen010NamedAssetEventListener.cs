using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Ahoy
{
	public class Gen010NamedAssetEventListener : MonoBehaviour
	{

		public Gen010NamedAssetEvent assetEvent;
		public Gen010NamedUnityEvent response;

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