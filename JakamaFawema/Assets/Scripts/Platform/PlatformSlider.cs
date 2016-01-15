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
        CheckSliderActive();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSliderActive();

        int sliderA = 0;
        if (Controller.sharedInstance != null){
            string[] a_inputs = null;
            a_inputs = Controller.sharedInstance.getAnalog().Split();
            sliderA = System.Convert.ToInt32(a_inputs[1], 16);
        }

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

    void CheckSliderActive()
    {
        if (slider1 == slider2)
        {
            slider2 = !slider2;
        }
    }
}
