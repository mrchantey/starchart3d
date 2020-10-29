using UnityEngine;
using System;

namespace Ahoy
{

	public static class CameraUtility
	{

		public static Func<Camera> CachedCamera = InitCamera;
		static Camera cachedCamera;
		static Camera InitCamera()
		{
			cachedCamera = Camera.main;
			CachedCamera = M_CachedCamera;
			return cachedCamera;
		}

		static Camera M_CachedCamera()
		{
			return cachedCamera;
		}


	}
}