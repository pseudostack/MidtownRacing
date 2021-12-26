using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMenuRotate : MonoBehaviour
{
    public float speed=15;

    private void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0,Space.World);
    }
}
