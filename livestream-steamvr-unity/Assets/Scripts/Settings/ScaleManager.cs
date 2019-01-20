



using UnityEngine;



public class ScaleManager : MonoBehaviour
{

    const float minScale = 0.0001f;
    const float maxScale = 10;

    [Range(minScale, maxScale)]
    public float scale = 1;

    void OnValidate()
    {
        SetScaleOffset(scale);

    }


    public void ResetScale()
    {
        scale = 1;
        SetScaleOffset(scale);
    }

    public void MoveScale(float deltaPos)
    {
        float newScale = scale + deltaPos;
        if (newScale > maxScale || newScale < minScale)
            return;
        scale = newScale;
        SetScaleOffset(scale);
    }

    void SetScaleOffset(float scale)
    {
        Shader.SetGlobalFloat("scaleOffset", scale);
    }

}