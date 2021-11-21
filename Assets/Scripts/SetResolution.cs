using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetResolution : MonoBehaviour
{
    public static bool done = false;
    public Text nativetext;
    public Text midtext;
    public Text lowtext;


    public Text currentrestext;
    private void Start()
    {
        if(done == false)
        {
            int i = Screen.currentResolution.height;
            int j = Screen.currentResolution.width;

            PlayerPrefs.SetInt("H", i);
            PlayerPrefs.SetInt("W", j);
            done = true;
        }
       
    }
    public void Native()
    {
        
        Screen.SetResolution(PlayerPrefs.GetInt("W"), PlayerPrefs.GetInt("H"), true);
    }
    public void Medium()
    {
        Screen.SetResolution(Mathf.FloorToInt(PlayerPrefs.GetInt("W")*0.7f), Mathf.FloorToInt(PlayerPrefs.GetInt("H") * 0.7f), true);
    }
    public void Low()
    {
        Screen.SetResolution(Mathf.FloorToInt(PlayerPrefs.GetInt("W") * 0.5f), Mathf.FloorToInt(PlayerPrefs.GetInt("H") * 0.5f), true);
    }
    public void UltraLow()
    {
        Screen.SetResolution(640, 360, true);
    }
    private void Update()
    {
        currentresol();
        nativetext.text = "High "+(PlayerPrefs.GetInt("H"))+"p";
        midtext.text="Medium " + (Mathf.FloorToInt(PlayerPrefs.GetInt("H"))*0.7) + "p";
        lowtext.text = "Low " + (Mathf.FloorToInt(PlayerPrefs.GetInt("H")) * 0.5) + "p";
    }
    public void currentresol()
    {

        int a = Screen.currentResolution.height;
        int b = Screen.currentResolution.width;
        currentrestext.text = "Resolution: " + b+ "*" + a;
    }
}