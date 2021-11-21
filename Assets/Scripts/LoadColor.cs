using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadColor : MonoBehaviour
{
    public Material[] mat;
    public GameObject Car1body;


    private void Awake()
    {
        if (PlayerPrefs.GetFloat("C1") == 0)
        {
            Car1body.GetComponent<MeshRenderer>().material = mat[0];
        }
        if (PlayerPrefs.GetFloat("C1") == 1)
        {
            Car1body.GetComponent<MeshRenderer>().material = mat[1];
        }
        if (PlayerPrefs.GetFloat("C1") == 2)
        {
            Car1body.GetComponent<MeshRenderer>().material = mat[2];
        }
        if (PlayerPrefs.GetFloat("C1") == 3)
        {
            Car1body.GetComponent<MeshRenderer>().material = mat[3];
        }
        if (PlayerPrefs.GetFloat("C1") == 4)
        {
            Car1body.GetComponent<MeshRenderer>().material = mat[4];
        }

    }
}
