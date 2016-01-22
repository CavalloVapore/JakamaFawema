using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour
{

    private Door winCheck;

    public enum Color
    {
        red,
        green,
        blue,
        yellow,
    }

    public Color led;
    
    void Start()
    {
        winCheck = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();

        Controller.sharedInstance.switchOff();

        gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().color = new UnityEngine.Color(1, 1, 1);
        gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = false;
    }

 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switch (led)
            {
                case (Color.red):
                    Controller.sharedInstance.setLed(1, 1);

                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().color = new UnityEngine.Color(1, 0, 0);

                    winCheck.red = true;
                    break;

                case (Color.blue):
                    Controller.sharedInstance.setLed(0, 1);

                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().color = new UnityEngine.Color(0, 0, 1);

                    winCheck.blue = true;
                    break;

                case (Color.green):
                    Controller.sharedInstance.setLed(3, 1);

                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().color = new UnityEngine.Color(0, 1, 0);

                    winCheck.green = true;
                    break;

                case (Color.yellow):
                    Controller.sharedInstance.setLed(2, 1);

                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().color = new UnityEngine.Color(1, 1, 0);

                    winCheck.yellow = true;
                    break;
            }
        }
    }
}
