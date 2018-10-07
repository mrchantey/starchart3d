

using System.Collections.Generic;
using UnityEngine;

public static class ColorUtility
{



    public static Color32 ColorIndexToRGB(float colorIndex)
    {

        float ciClamped = Mathf.Clamp(colorIndex, -0.4f, 2);
        float ciRounded = Mathf.Round(ciClamped * 10) / 10;
        Color32 col;
        colorLookup.TryGetValue(ciRounded, out col);
        return col;
    }


    //summarized from http://www.vendian.org/mncharity/dir3/starcolor/details.html
    static Dictionary<float, Color32> colorLookup = new Dictionary<float, Color32>
    {
        {-0.4f,new Color32(155,178,255,255)},
        {-0.3f,new Color32(163,185,255,255)},
        {-0.2f,new Color32(178,197,255,255)},
        {-0.1f,new Color32(196,210,255,255)},
        {0.0f,new Color32(211,221,255,255)},
        {0.1f,new Color32(223,229,255,255)},
        {0.2f,new Color32(233,236,255,255)},
        {0.3f,new Color32(243,242,255,255)},
        {0.4f,new Color32(254,249,255,255)},
        {0.5f,new Color32(255,247,245,255)},
        {0.6f,new Color32(255,243,234,255)},
        {0.7f,new Color32(255,239,224,255)},
        {0.8f,new Color32(255,235,214,255)},
        {0.9f,new Color32(255,232,206,255)},
        {1.0f,new Color32(255,229,198,255)},
        {1.1f,new Color32(255,226,191,255)},
        {1.2f,new Color32(255,223,184,255)},
        {1.3f,new Color32(255,219,176,255)},
        {1.4f,new Color32(255,216,169,255)},
        {1.5f,new Color32(255,213,161,255)},
        {1.6f,new Color32(255,208,150,255)},
        {1.7f,new Color32(255,200,133,255)},
        {1.8f,new Color32(255,183,101,255)},
        {1.9f,new Color32(255,149,35,255)},
        {2.0f,new Color32(255,82,0,255)}
    };


}