using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    [Range(-100000, 100000)]
    public float currentYear = 2018;
    public bool reset;
    public bool autoUpdate;
    [Range(-10000, 10000)]
    public float timeScale = 10;

    void OnValidate()
    {
        Shader.SetGlobalFloat("J2000offset", currentYear - 2000);
        if (reset)
        {
            reset = !reset;
            currentYear = 2018;
        }
    }

    void Update()
    {
        if (autoUpdate)
        {
            currentYear += Time.deltaTime * timeScale;
            Shader.SetGlobalFloat("J2000offset", currentYear - 2000);
        }
    }


}
