using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour
{

    public enum Color
    {
        red,
        green,
        blue,
        yellow,
    }

    public Color LED;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
        }
    }
}
