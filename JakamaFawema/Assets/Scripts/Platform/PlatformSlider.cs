using UnityEngine;
using System.Collections;

public class PlatformSlider : MonoBehaviour
{
    public float speed = 3f;

    public float playerspeed = 3f;

    private float move = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move = 0;

        float t = Input.GetAxis("Slide");

        transform.position = new Vector3(transform.position.x + t*speed*Time.deltaTime,transform.position.y);

        move = t * speed * Time.deltaTime;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Blubb");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("1");
            other.transform.position = new Vector3(transform.position.x, other.transform.position.y);
        }
    }
}
