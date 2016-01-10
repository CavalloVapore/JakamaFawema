using System;
using UnityEngine;
using System.Collections;

public class PlatformTurning : MonoBehaviour
{

    public float speed = 3f;
    public bool turner1 = true;
    public bool turner2 = false;

    // Use this for initialization
    void Start()
    {
        CheckTurnerAcive();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTurnerAcive();

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

    void CheckTurnerAcive()
    {
        if(turner1 == turner2)
        {
            turner2 = !turner2;
        }
    }
}
