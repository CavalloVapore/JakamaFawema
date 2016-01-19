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

    public Color led;
    
    void Start()
    {

        //TODO
        Controller.sharedInstance.setLed(0, 0);
        Controller.sharedInstance.setLed(1, 0);
        Controller.sharedInstance.setLed(2, 0);
        Controller.sharedInstance.setLed(3, 0);
        //all LEDs off
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
                    //TODO
                    //LED red on
                    Controller.sharedInstance.setLed(1, 1);
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().color = new UnityEngine.Color(1, 0, 0);
                    break;

                case (Color.blue):
                    //TODO
                    //LED blue on
                    Controller.sharedInstance.setLed(0, 1);
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().color = new UnityEngine.Color(0, 0, 1);
                    break;

                case (Color.green):
                    //TODO
                    //LED green on
                    Controller.sharedInstance.setLed(3, 1);
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().color = new UnityEngine.Color(0, 1, 0);
                    break;

                case (Color.yellow):
                    //TODO
                    //LED yellow on
                    Controller.sharedInstance.setLed(2, 1);
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = true;
                    gameObject.transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().color = new UnityEngine.Color(1, 1, 0);
                    break;
            }
        }
    }
}
