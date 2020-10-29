using UnityEngine;

namespace Ahoy
{

	public class ApplicationEvents : MonoBehaviour
	{


		public NullUnityEvent onApplicationEditor;
		public NullUnityEvent onApplicationMobile;


		void Awake()
		{
			if (Application.isEditor)
				onApplicationEditor.Invoke();
			if (Application.isMobilePlatform)
				onApplicationMobile.Invoke();
		}
		public void Quit()
		{
			Application.Quit();
		}

	}
}