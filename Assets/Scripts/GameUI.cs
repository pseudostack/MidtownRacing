using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject carcam;
    public GameObject fpscam;
    public GameObject frontcam;
    public int camno = 0;

    public GameObject speedtext;
    public Text fpstext;
    public Rigidbody carRb;
    public GameObject car;

    public static bool showfps = false;


   
    public void changecam()
    {
        if (camno < 2)
        {
            camno++;
        }
        else
        {
            camno = 0;
        }
    }
    public void UpdateCam()
    {
        if (camno == 0)
        {
            fpscam.SetActive(false);
            frontcam.SetActive(false);
            carcam.SetActive(true);
        }
        if (camno == 1)
        {
            frontcam.SetActive(false);
            carcam.SetActive(true);
            fpscam.SetActive(true);
        }
        if(camno == 2)
        {
            carcam.SetActive(false);
            fpscam.SetActive(false);
            frontcam.SetActive(true);
        }
    }
    public void UpdateSpeed()
    {
        speedtext.GetComponent<Text>().text = "" + Mathf.FloorToInt(carRb.velocity.magnitude*3.6f)+" km/h";
    }
    
    public void UpdateFPS()
    {
        float current;
        current = (int)(1f / Time.unscaledDeltaTime);
        fpstext.text = current + " FPS";

    }
    public void CarMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    private void Update()
    {
        UpdateSpeed();
        UpdateCam();

        if (showfps == true)
        {
            UpdateFPS();
        }
       
    }
    public void Respawnpos()
    {
        car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y + 10, car.transform.position.z);

        Quaternion rotation1 =  Quaternion.Euler(0, car.transform.rotation.y, 0);
        car.transform.rotation = rotation1;
    }
}
