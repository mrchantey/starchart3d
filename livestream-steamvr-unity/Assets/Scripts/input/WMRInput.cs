using UnityEngine;
using System.Linq;
using Valve.VR;


public class WMRInput : MonoBehaviour
{

    const float joystickThreshold = 0.1f;
    [Range(0.01f, 2)]
    public float scaleSensitivity = 1;
    [Range(1, 100000)]
    public float deltaYearsPerSecond = 50000;

    public SteamVR_Action_Vector2 joystickPos;
    public SteamVR_Action_Boolean trackpadClick;
    public SteamVR_Action_Boolean gripClick;


    public TimeManager timeManager;
    public ScaleManager scaleManager;


    private void Start()
    {
    }

    private void Update()
    {
        SetScale();
        SetTime();

    }


    void SetTime()
    {
        if (trackpadClick.GetStateUp(SteamVR_Input_Sources.LeftHand))
            timeManager.ResetTime();
        if (gripClick.GetStateUp(SteamVR_Input_Sources.LeftHand))
            timeManager.ToggleAutoUpdate();
        float x = joystickPos.GetAxis(SteamVR_Input_Sources.LeftHand).x;
        if (Mathf.Abs(x) >= joystickThreshold)
            timeManager.MoveCurrentYear(x * deltaYearsPerSecond * Time.deltaTime);
    }

    void SetScale()
    {
        if (trackpadClick.GetStateUp(SteamVR_Input_Sources.RightHand))
            scaleManager.ResetScale();

        float x = joystickPos.GetAxis(SteamVR_Input_Sources.RightHand).x;
        if (Mathf.Abs(x) >= joystickThreshold)
            scaleManager.MoveScale(x * scaleSensitivity);


    }

    // Vector2 LeftThumbpadPress()
    // {
    //     return thumbpadPos.GetAxis(SteamVR_Input_Sources.LeftHand);
    // }
    // Vector2 RightThumbpadPress()
    // {
    //     return thumbpadPos.GetAxis(SteamVR_Input_Sources.RightHand);
    // }

}