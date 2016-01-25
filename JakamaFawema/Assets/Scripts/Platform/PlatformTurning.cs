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
    private GameObject character;
    private float lastTurner = 0f;

    private ControllerInput input;

    // Use this for initialization
    void Start()
    {
        CheckTurnerActive();
        character = GameObject.FindGameObjectWithTag("Player");

        input = GameObject.FindGameObjectWithTag("ControllerInput").GetComponent<ControllerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTurnerActive();

        if (input.running && Vector3.Distance(transform.position, character.transform.position) < 20.0f)
        { 
            float turner = 0.0f;
            if (turner1)
                turner = input.turner1;
            else if (turner2)
                turner = input.turner2;
            turner = Mathf.Round(turner * 360.0f);

            if (Mathf.Abs(turner - lastTurner)>3)
            {
                transform.rotation = Quaternion.AngleAxis(turner, Vector3.forward);
                lastTurner = turner;
            }
        }
        else if (Vector3.Distance(transform.position, character.transform.position) < 30.0f)
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
