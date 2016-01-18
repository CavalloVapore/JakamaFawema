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

        float turnerA = 0.0f;
        float turnerB = 0.0f;
        if (Controller.sharedInstance.getRunning())
        {
            string[] a_inputs = null;
            a_inputs = Controller.sharedInstance.getAnalog().Split();
            turnerA = (float)(System.Convert.ToInt32(a_inputs[1], 16) / 65535.0f);
            turnerB = (float)(System.Convert.ToInt32(a_inputs[0], 16) / 65535.0f);

            float turner = 0.0f;
            if (turner1)
                turner = turnerA;
            else if (turner2)
                turner = turnerB;

            transform.RotateAround(transform.position, Vector3.forward, turner);
        }
        else
        {
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
    }

    void CheckTurnerActive()
    {
        if(turner1 == turner2)
        {
            turner2 = !turner2;
        }
    }
}
