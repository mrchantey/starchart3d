
using UnityEngine;
using UnityEngine.UI;
namespace Starchart3D
{

	[ExecuteInEditMode]
	public class ConstellationOverlayText : MonoBehaviour
	{
		public bool debug = false;

		public Text text;
		public ConstellationInfo constellationInfo;

		public Transform parent3d;
		int fontSize = 10;
		public void SetConstellation(ConstellationInfo info, Transform parent3d)
		{
			constellationInfo = info;
			text.text = constellationInfo.name;
			this.parent3d = parent3d;
		}

		void Update()
		{
			if (constellationInfo != null)
				UpdateTextPosition();
		}

		void UpdateTextPosition()
		{
			var canvasSize = text.canvas.GetComponent<RectTransform>().sizeDelta;
			var worldPos = parent3d.TransformPoint(constellationInfo.position);

			if (debug) Debug.Log($"ConstellationOverlayText - parent: {parent3d.name} pos: {constellationInfo.position}\tworldPos: {worldPos}");
			// Vector3 viewPortPos = Camera.main.WorldToViewportPoint(constellationInfo.position);
			Vector3 viewPortPos = Camera.main.WorldToViewportPoint(worldPos);
			Vector2 screenPos = viewPortPos * canvasSize;
			text.rectTransform.anchoredPosition = screenPos;
			text.fontSize = fontSize;
			text.gameObject.SetActive(viewPortPos.z > 0);
		}


	}
}