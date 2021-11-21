using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapSelect : MonoBehaviour
{
    public GameObject MapSelector;
    public GameObject CarSelector;
    

    public int mid;

    public void Map1()
    {
        PlayerPrefs.SetInt("mid", 0);
        

    }
    public void Map2()
    {
        PlayerPrefs.SetInt("mid", 1);



    }


}
