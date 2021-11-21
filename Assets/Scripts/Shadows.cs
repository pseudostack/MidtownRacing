using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shadows : MonoBehaviour
{
    public Text toggletext;
   public static bool shadows = true;

   
    public void togglefps()
    {
        shadows =!shadows;
    }
  
    public void Update()
    {
        if (shadows == true)
        {
            toggletext.text = "ON";
            GameUI.showfps = true;
        }
        if(shadows==false)
        {
            toggletext.text = "OFF";
            GameUI.showfps = false;
        }

      



    }
   

}
