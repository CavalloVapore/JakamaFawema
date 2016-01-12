using System;
using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class PlatformTurning : MonoBehaviour
{
    //SerialPort stream = new SerialPort("COM6", 115200);
    //string receivedData = "EMPTY";
    public float speed = 3f;
    public bool turner1 = true;
    public bool turner2 = false;

    // Use this for initialization
    void Start()
    {
        CheckTurnerActive();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTurnerActive();

        if (turner1)
        {
            float t = Input.GetAxis("Vertical");

            transform.RotateAround(transform.position, Vector3.forward, t * speed * Time.deltaTime);
        }
        else
        {
            float t = Input.GetAxis("Vertical2");

            transform.RotateAround(transform.position, Vector3.forward, t * speed * Time.deltaTime);
        }
    }

    void CheckTurnerActive()
    {
        if(turner1 == turner2)
        {
            turner2 = !turner2;
        }
    }
}
