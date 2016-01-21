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
    private GameObject character;
    private float lastSlider = 0f;

    private ControllerInput input;

    // Use this for initialization
    void Start()
    {
        CheckSliderActive();
        start = transform.position;
        character = GameObject.FindGameObjectWithTag("Player");

        input = GameObject.FindGameObjectWithTag("ControllerInput").GetComponent<ControllerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSliderActive();


        if (input.running && Vector3.Distance(transform.position, character.transform.position) < 30.0f)
        {
            float slider = 0.0f;
            if (slider1)
                slider = input.slider1;
            else if (slider2)
                slider = input.slider2;


            if (Mathf.Abs(slider-lastSlider) >0.03)
            {
                if (!moveVertical && Mathf.Abs(start.x - (transform.position.x + horizontalBounds * slider)) < horizontalBounds)
                    transform.position = new Vector3(start.x + horizontalBounds * slider, transform.position.y);
                else if (moveVertical && Mathf.Abs(start.y - (transform.position.y + verticalBounds * slider)) < verticalBounds)
                    transform.position = new Vector3(transform.position.x, start.y + verticalBounds * slider);
                lastSlider = slider;
            }


        }
        else if (Vector3.Distance(transform.position, character.transform.position) < 30.0f)
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
