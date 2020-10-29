//
//
//	THS FILE IS AUTO GENERATED
//	DO NOT EDIT DIRECTLY
//



/*AUTO SCRIPT*/using UnityEngine;
/*AUTO SCRIPT*/using UnityEngine.Events;
/*AUTO SCRIPT*/using System.Collections.Generic;
/*AUTO SCRIPT*/using System;
/*AUTO SCRIPT*/using System.Linq;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/namespace Ahoy
/*AUTO SCRIPT*/{
/*AUTO SCRIPT*/	public class TimedQuaternionNamedAssetEventListener : MonoBehaviour
/*AUTO SCRIPT*/	{
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		public TimedQuaternionNamedAssetEvent assetEvent;
/*AUTO SCRIPT*/		public TimedQuaternionNamedUnityEvent response;
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/		protected virtual void OnEnable()
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			assetEvent.AddListener(response);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/		protected virtual void OnDisable()
/*AUTO SCRIPT*/		{
/*AUTO SCRIPT*/			assetEvent.RemoveListener(response);
/*AUTO SCRIPT*/		}
/*AUTO SCRIPT*/	}
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/
/*AUTO SCRIPT*/}