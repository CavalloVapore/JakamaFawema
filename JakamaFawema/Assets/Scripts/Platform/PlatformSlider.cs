using UnityEngine;
using System.Collections;


public class PlatformSlider : MonoBehaviour
{
    public float speed = 3f;
    public bool slider1 = true;
    public bool slider2 = false;
    public bool moveVertical = false;
    public float horizontalBounds = 5.0f;
    public float verticalBounds = 5.0f;
    private Vector3 start;

    // Use this for initialization
    void Start()
    {
        CheckSliderActive();
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckSliderActive();

        float sliderA = 0.0f;
        float sliderB = 0.0f;
        if (Controller.sharedInstance.getRunning())
        {
            string[] a_inputs = null;
            a_inputs = Controller.sharedInstance.getAnalog().Split();
            sliderA = (float)(System.Convert.ToInt32(a_inputs[1], 16) / 32767.5f) - 1;
            sliderB = (float)(System.Convert.ToInt32(a_inputs[0], 16) / 32767.5f) - 1;
            
            float slider = 0.0f;
            if (slider1)
                slider = sliderA;
            else if (slider2)
                slider = sliderB;

            if (!moveVertical)
                transform.position = new Vector3(transform.position.x + horizontalBounds * slider, transform.position.y);
            else
                transform.position = new Vector3(transform.position.x, transform.position.y + verticalBounds * slider);

        }
        else
        {
            float t = 0.0f;
            if (slider1)
            {
                t = Input.GetAxis("Slide");               
            }
            else
            {
                t = Input.GetAxis("Slide2");
            }
            if (!moveVertical && Mathf.Abs(start.x - (transform.position.x + t * speed * Time.deltaTime)) < horizontalBounds)
                transform.position = new Vector3(transform.position.x + t * speed * Time.deltaTime, transform.position.y);
            else if (moveVertical && Mathf.Abs(start.y - (transform.position.y + t * speed * Time.deltaTime)) < verticalBounds)
                transform.position = new Vector3(transform.position.x, transform.position.y + t * speed * Time.deltaTime);               
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
