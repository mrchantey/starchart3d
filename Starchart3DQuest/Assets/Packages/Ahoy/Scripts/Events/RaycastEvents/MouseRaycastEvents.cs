using UnityEngine;

namespace Ahoy
{

	public class MouseRaycastEvents : RaycastEvents
	{

		public bool debug;
		new Camera camera;

		void Awake()
		{
			camera = Ahoy.CameraUtility.CachedCamera();
		}

		protected override Ray GetRay()
		{
			return camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
		}

	}
}