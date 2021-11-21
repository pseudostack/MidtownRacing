using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showfpslimit : MonoBehaviour
{
    public Text toggletext;
    public static bool fpslimit30 = false;

   
    public void togglefps()
    {
        fpslimit30 =!fpslimit30;
    }
  
    public void Update()
    {
        if (fpslimit30 == true)
        {
            toggletext.text = "30";
            
        }
        if(fpslimit30==false)
        {
            toggletext.text = "60";
            
        }

      



    }
   

}
