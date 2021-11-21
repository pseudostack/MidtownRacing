using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    public GameObject DrownText;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<Rigidbody>().drag = 13;
   
        StartCoroutine(Drown());
       
    }
    IEnumerator Drown()
    {
        DrownText.SetActive(true);
        yield return new WaitForSeconds(3f);
       
        SceneManager.LoadScene(2);
        DrownText.SetActive(false);
    }
}

