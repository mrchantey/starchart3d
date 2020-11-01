using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Ahoy.Compute
{
	[ExecuteAlways]
	public class ComputeRenderDispatcher : MonoBehaviour
	{

		public new Camera camera;

		public List<ComputeRenderer> computeRenderers;

		UnityEngine.Matrix4x4 V, P, VP;

		Vector4 screenParams;

		void OnEnable()
		{
			RenderPipelineManager.beginFrameRendering += OnPreRenderURP;
			HandleDefaultValues();
		}

		void OnDisable()
		{
			RenderPipelineManager.beginFrameRendering -= OnPreRenderURP;
		}

		void OnPreRenderURP(ScriptableRenderContext context, Camera[] cameras)
		{
			Render();
		}

		void Render()
		{
			// Debug.Log($"ComputeRenderDispatcher - {Time.frameCount}");
			var renderers = computeRenderers
			.Where(i =>
				i.gameObject.activeInHierarchy &&
				i.isInitialized
				)
			.ToArray();
			HandleTime();
			HandleMatrices(renderers);
			HandleScreenParams();
			renderers.ForEach(m => m.Render(camera));
		}

		void HandleDefaultValues()
		{
			Shader.SetGlobalFloat("_Size", 1);
			Shader.SetGlobalFloat("_ScaleDivisor", 1);
			Shader.SetGlobalFloat("_ScaleRange", 0);
			Shader.SetGlobalFloat("_ScaleMax", 1);
			Shader.SetGlobalInt("_ScreenSpace", 0);
			Shader.SetGlobalColor("_Color", Color.white);
		}

		// UnityEngine.Rendering.

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

		void HandleMatrices(ComputeRenderer[] renderers)
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

	}
}