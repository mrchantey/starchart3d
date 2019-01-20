



using UnityEngine;



public class TimeManager : MonoBehaviour
{



    [Range(-100000, 100000)]
    public float currentYear = 2018;

    public float yearsPerSecond = 10;

    public bool autoUpdate;
    public bool reset;

    void OnValidate()
    {
        SetJ2000Offset(currentYear);
        if (reset)
        {
            reset = false;
            ResetTime();
        }
    }

    void Update()
    {
        if (autoUpdate)
        {
            currentYear += yearsPerSecond * Time.deltaTime;
            SetJ2000Offset(currentYear);
        }
    }

    public void ToggleAutoUpdate()
    {
        autoUpdate = !autoUpdate;
    }

    public void ResetTime()
    {
        currentYear = 2018;
        SetJ2000Offset(currentYear);
    }

    public void SetCurrentYear(float year)
    {
        currentYear = year;
        SetJ2000Offset(currentYear);
    }
    public void MoveCurrentYear(float deltaYear)
    {
        currentYear += deltaYear;
        SetJ2000Offset(currentYear);
    }


    void SetJ2000Offset(float year)
    {
        Shader.SetGlobalFloat("J2000Offset", year - 2000);
    }

}