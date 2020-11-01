using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Ahoy.Compute
{

	public class ComputeRenderDispatcher : MonoBehaviour
	{

		public new Camera camera;

		public List<ComputeRendererBase> computeRenderers;

		UnityEngine.Matrix4x4 V, P, VP;

		Vector4 screenParams;

		void Start()
		{

		}

		void HandleScreenParams()
		{
			if (Screen.width != screenParams.x || Screen.height != screenParams.y)
			{
				screenParams.x = Screen.width;
				screenParams.y = Screen.height;
				screenParams.z = 1 + 1f / Screen.width;
				screenParams.w = 1 + 1f / Screen.height;
				Shader.SetGlobalVector("Ahoy_ScreenParams", screenParams);
			}
		}

		void HandleMatrices(ComputeRendererBase[] renderers)
		{
			MatrixUtility.CalculateViewProjectionMatrices(camera, out V, out P, out VP);
			Shader.SetGlobalMatrix("Ahoy_V", V);
			Shader.SetGlobalMatrix("Ahoy_P", P);
			Shader.SetGlobalMatrix("Ahoy_VP", VP);

			renderers.ForEach(renderer =>
						{
							Matrix4x4 M, MV, MVP;
							MatrixUtility.CalculateModelMatrices(
								renderer.transform,
								V,
								VP,
								out M,
								out MV,
								out MVP);
							renderer.computeInstance.SetMatrix("Ahoy_M", M);
							renderer.computeInstance.SetMatrix("Ahoy_MV", MV);
							renderer.computeInstance.SetMatrix("Ahoy_MVP", MVP);
						});
		}

		void HandleTime()
		{
			Shader.SetGlobalFloat("Ahoy_DeltaTime", Time.deltaTime);
			Shader.SetGlobalFloat("Ahoy_Time", Time.time);
		}

		void Update()
		{
			var renderers = computeRenderers
			.Where(i =>
				i.gameObject.activeInHierarchy &&
				i.computeInstance != null &&
				i.computeInstance.base_isInitialized)
			.ToArray();
			HandleTime();
			HandleMatrices(renderers);
			HandleScreenParams();
			renderers.ForEach(m =>
			{
				m.computeInstance.Dispatch();
				m.materialInstance.Render(camera);
			});
		}

	}
}