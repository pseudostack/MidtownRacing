using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraShdows : MonoBehaviour
{
    private float SD;
    private void OnPreRender()
    {
       
        QualitySettings.shadows = ShadowQuality.Disable;

    }
    private void OnPostRender()
    {

        QualitySettings.shadows = ShadowQuality.HardOnly;
    }
}
