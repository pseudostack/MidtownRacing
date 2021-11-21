using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCar : MonoBehaviour
{
  
    public GameObject car1;


    public GameObject car2;

    public GameObject car3;

    public GameObject car4;
    public GameObject car5;
    public GameObject car6;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Carid") == 0)
        {
            car2.SetActive(false);
            car3.SetActive(false);
            car4.SetActive(false);
            car5.SetActive(false);
            car6.SetActive(false);
            car1.SetActive(true);
            
        }
        if (PlayerPrefs.GetInt("Carid") == 1)
        {
            car1.SetActive(false);
            car3.SetActive(false);
            car4.SetActive(false);
            car5.SetActive(false);
            car6.SetActive(false);
            car2.SetActive(true);
         
        }
        if (PlayerPrefs.GetInt("Carid") == 2)
        {
            car1.SetActive(false);
            car2.SetActive(false);
            car4.SetActive(false);
            car5.SetActive(false);
            car6.SetActive(false);
            car3.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Carid") == 3)
        {
            car1.SetActive(false);
            car2.SetActive(false);
            car3.SetActive(false);
            car5.SetActive(false);
            car6.SetActive(false);
            car4.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Carid") == 4)
        {
            car1.SetActive(false);
            car2.SetActive(false);
            car3.SetActive(false);
            car4.SetActive(false);
            car6.SetActive(false);
            car5.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Carid") == 5)
        {
            car1.SetActive(false);
            car2.SetActive(false);
            car3.SetActive(false);
            car4.SetActive(false);
            car5.SetActive(false);
            car6.SetActive(true);

        }


    }
}
