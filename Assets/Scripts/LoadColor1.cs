using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadColor1 : MonoBehaviour
{
    public Material[] mat;
    public GameObject Car1body;
    public GameObject Car1body2;

    private void Awake()
    {
        if (PlayerPrefs.GetFloat("C2") == 0)
        {
            Car1body.GetComponent<MeshRenderer>().material = mat[0];
            Car1body2.GetComponent<MeshRenderer>().material = mat[0];
        }
        if (PlayerPrefs.GetFloat("C2") == 1)
        {
            Car1body.GetComponent<MeshRenderer>().material = mat[1];
            Car1body2.GetComponent<MeshRenderer>().material = mat[1];
        }
        if (PlayerPrefs.GetFloat("C2") == 2)
        {
            Car1body.GetComponent<MeshRenderer>().material = mat[2];
            Car1body2.GetComponent<MeshRenderer>().material = mat[2];
        }
        if (PlayerPrefs.GetFloat("C2") == 3)
        {
            Car1body.GetComponent<MeshRenderer>().material = mat[3];
            Car1body2.GetComponent<MeshRenderer>().material = mat[3];
        }
        if (PlayerPrefs.GetFloat("C2") == 4)
        {
            Car1body.GetComponent<MeshRenderer>().material = mat[4];
            Car1body2.GetComponent<MeshRenderer>().material = mat[4];
        }

    }
}
