using UnityEngine;
using System.Collections;

public class PlatformSlider : MonoBehaviour
{
    public float speed = 3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float t = Input.GetAxis("Slide");

        transform.position = new Vector3(transform.position.x + t*speed*Time.deltaTime,transform.position.y);
    }
}
