using System;
using UnityEngine;
using System.Collections;

public class PlatformTurning : MonoBehaviour
{

    public float speed = 3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float t = Input.GetAxis("Vertical");

        transform.RotateAround(transform.position, Vector3.forward, t * speed*Time.deltaTime);
    }
}
