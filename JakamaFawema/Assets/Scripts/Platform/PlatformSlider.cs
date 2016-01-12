using UnityEngine;
using System.Collections;


public class PlatformSlider : MonoBehaviour
{
    public float speed = 3f;
    public bool slider1 = true;
    public bool slider2 = false;

    // Use this for initialization
    void Start()
    {
        CheckSliderAcive();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSliderAcive();

        if (slider1)
        {
            float t = Input.GetAxis("Slide");

            transform.position = new Vector3(transform.position.x + t * speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            float t = Input.GetAxis("Slide2");

            transform.position = new Vector3(transform.position.x + t * speed * Time.deltaTime, transform.position.y);
        }
    }

    void CheckSliderAcive()
    {
        if (slider1 == slider2)
        {
            slider2 = !slider2;
        }
    }
}
