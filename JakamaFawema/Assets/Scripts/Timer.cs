using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public float timer = 0.0f;
    public Text timerLabel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        var minutes = (int)(timer / 60); //Divide the guiTime by sixty to get the minutes.  //aus dem Inet funzt nicht ganz wies soll
        var seconds = timer % 60;//Use the euclidean division for the seconds.
        var fraction = (timer * 100) % 100;

        //update the label value
        timerLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);

        if (timer <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
	}
}
