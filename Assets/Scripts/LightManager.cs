using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light Sun;


    private void Awake()
    {
        if (Shadows.shadows == true)
        {
            Sun.shadows = LightShadows.Hard;
        }
        else
        {
            Sun.shadows = LightShadows.None;
        }
    }
}
