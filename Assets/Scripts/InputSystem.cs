using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public enum ControlMode { Keyboard=1,Touch = 2};

public class InputSystem : MonoBehaviour
{
    public ControlMode control;
    public float Accel;
    public float Steer;
    public float Brake;
    public GameObject UI;
    // Start is called before the first frame update
    public void AccelInput(float input) { Accel = input; }
    public void SteerInput(float input) { Steer = input; }
    public void BrakeInput(float input) { Brake = input; }

    CarController Car;

    private void Start()
    {
        Car = GetComponent<CarController>();
    }

    void Update()
    {
        if (control == ControlMode.Keyboard)
        {
            Accel = Input.GetAxis("Vertical");
            Steer = Input.GetAxis("Horizontal");
            Brake = Input.GetAxis("Jump");

            UI.SetActive(false);

        }
        else
        {
            UI.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        Car.Move(Steer, Accel,Accel, Brake);
    }
}
