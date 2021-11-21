using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLock : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        if (Showfpslimit.fpslimit30==true)
        {
            Application.targetFrameRate = 30;
        }
        else
        {
            Application.targetFrameRate = 60;
        }
        
    }
}
