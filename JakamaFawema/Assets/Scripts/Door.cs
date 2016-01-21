using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [HideInInspector]
    public bool red;
    [HideInInspector]
    public bool blue;
    [HideInInspector]
    public bool green;
    [HideInInspector]
    public bool yellow;

    void Start()
    {
        red = false;
        blue = false;
        green = false;
        yellow = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if( red && blue && green && yellow)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
}
