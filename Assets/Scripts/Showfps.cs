using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showfps : MonoBehaviour
{
    public Text toggletext;
    public static bool fps = false;

   
    public void togglefps()
    {
        fps =!fps;
    }
  
    public void Update()
    {
        if (fps == true)
        {
            toggletext.text = "ON";
            GameUI.showfps = true;
        }
        if(fps==false)
        {
            toggletext.text = "OFF";
            GameUI.showfps = false;
        }

      



    }
   

}
