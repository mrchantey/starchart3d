
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ConstellationOverlayText : MonoBehaviour
{


    public Text text;
    public ConstellationInfo constellationInfo;

    public void SetConstellation(ConstellationInfo _info)
    {
        constellationInfo = _info;
        text.text = constellationInfo.name;
    }

    void Update()
    {
        if (constellationInfo != null)
            UpdateTextPosition();
    }

    void UpdateTextPosition()
    {
        var canvasSize = text.canvas.GetComponent<RectTransform>().sizeDelta;
        Vector3 viewPortPos = Camera.main.WorldToViewportPoint(constellationInfo.position);
        Vector2 screenPos = viewPortPos * canvasSize;
        text.rectTransform.anchoredPosition = screenPos;
        text.gameObject.SetActive(viewPortPos.z > 0);
    }


}