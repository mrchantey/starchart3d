using UnityEngine;
using System.Linq;

namespace Ahoy.Shaders
{

	public class MaterialsManager : MonoBehaviour
	{

		[Header("will create new instance of renderer materials on awake")]
		public MeshRenderer[] meshRenderers;
		public Material[] materials;

		void Awake()
		{
			meshRenderers.ForEach(mr => mr.material = Object.Instantiate(mr.material));
		}

		public void Fade(float from, float target, float totalTime)
		{
			var colorsMats = materials.Select(mat => mat.GetColor("_Color")).ToArray();
			var colorsRend = meshRenderers.Select(mr => mr.material.GetColor("_Color")).ToArray();
			this.CoroutineTimedLoop((progress) =>
			{

				materials.ForEach((mat, i) =>
						mat.SetColor("_Color", new Color(
							colorsMats[i].r,
							colorsMats[i].g,
							colorsMats[i].b,
							Mathf.Lerp(from, target, progress)
							)
						)
					);
				meshRenderers.ForEach((mr, i) =>
				{
					mr.material.SetColor("_Color", new Color(
						colorsRend[i].r,
						colorsRend[i].g,
						colorsRend[i].b,
						Mathf.Lerp(from, target, progress)
						)
					);
				});
			}
			, totalTime);
		}

		public void FadeTo(float target, float totalTime)
		{
			var colorsMats = materials.Select(mat => mat.GetColor("_Color")).ToArray();
			var colorsRend = meshRenderers.Select(mr => mr.material.GetColor("_Color")).ToArray();
			this.CoroutineTimedLoop((progress) =>
			{

				materials.ForEach((mat, i) =>
						mat.SetColor("_Color", new Color(
							colorsMats[i].r,
							colorsMats[i].g,
							colorsMats[i].b,
							Mathf.Lerp(colorsMats[i].a, target, progress)
							)
						)
					);
				meshRenderers.ForEach((mr, i) =>
				{
					mr.material.SetColor("_Color", new Color(
						colorsRend[i].r,
						colorsRend[i].g,
						colorsRend[i].b,
						Mathf.Lerp(colorsRend[i].a, target, progress)
						)
					);
				});
			}
			, totalTime);
		}
		public void FadeFrom(float target, float totalTime)
		{
			var colorsMats = materials.Select(mat => mat.GetColor("_Color")).ToArray();
			var colorsRend = meshRenderers.Select(mr => mr.material.GetColor("_Color")).ToArray();
			this.CoroutineTimedLoop((progress) =>
			{

				materials.ForEach((mat, i) =>
						mat.SetColor("_Color", new Color(
							colorsMats[i].r,
							colorsMats[i].g,
							colorsMats[i].b,
							Mathf.Lerp(target, colorsMats[i].a, progress)
							)
						)
					);
				meshRenderers.ForEach((mr, i) =>
				{
					mr.material.SetColor("_Color", new Color(
						colorsRend[i].r,
						colorsRend[i].g,
						colorsRend[i].b,
						Mathf.Lerp(target, colorsRend[i].a, progress)
						)
					);
				});
			}
			, totalTime);
		}
	}
}