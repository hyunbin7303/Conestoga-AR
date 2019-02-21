using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FocusComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var vuforia = VuforiaARController.Instance;
        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        vuforia.RegisterOnPauseCallback(OnPaused);
    }
    private void OnVuforiaStarted()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
    private void OnPaused(bool paused)
    {
        if(!paused)
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
        //Right now we have the focus mode set to “CONTINUOUSAUTO”. Vuforia recommends using this mode whenever possible. It works basically like an auto focus.
    }
}
