using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ControllerInput : MonoBehaviour
{

    [HideInInspector]
    public float turner1;
    [HideInInspector]
    public float turner2;
    [HideInInspector]
    public float slider1;
    [HideInInspector]
    public float slider2;
    [HideInInspector]
    public bool running;

    // Use this for initialization
    void Start()
    {
        turner1 = 0f;
        turner2 = 0f;
        slider1 = 0f;
        slider2 = 0f;

        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.sharedInstance.getRunning())
        {
            running = true;
            string[] a_inputs = null;
            a_inputs = Controller.sharedInstance.getAnalog().Split();

            turner1 = (float)(System.Convert.ToInt32(a_inputs[2], 16) / 4100f);
            turner2 = (float)(System.Convert.ToInt32(a_inputs[1], 16) / 4100f);

            slider1 = (float)(System.Convert.ToInt32(a_inputs[4], 16) / 2000f) - 1;
            slider2 = (float)(System.Convert.ToInt32(a_inputs[3], 16) / 2000f) - 1;
        }
        else
            running = false;
    }
}
