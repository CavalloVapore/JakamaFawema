﻿using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Controller : MonoBehaviour{

    static SerialPort stream = new SerialPort("COM6", 115200);
    static string receivedData = "EMPTY";

    public static Controller sharedInstance = new Controller();

    private bool running = false;

	// Use this for initialization

    private Controller(){
        streamStart();
    }

    private void streamStart()
    {
        try
        {
            if (!stream.IsOpen)
            {
                stream.Open();
                running = true;
            }            
            Debug.Log("SerialPort open and running");

        }
        catch (System.Exception e)
        {
            Debug.Log("SerialPort missing");
        }
        
    }

    public void switchOff()
    {
        Controller.sharedInstance.setLed(0, 0);
        Controller.sharedInstance.setLed(1, 0);
        Controller.sharedInstance.setLed(2, 0);
        Controller.sharedInstance.setLed(3, 0);
    }


    private string write(string toWrite)
    {
        try
        {
            stream.Write(toWrite);
            receivedData = stream.ReadLine();
            return receivedData;
        }
        catch (System.Exception e)
        {
            return "";
        }

    }

    public string getButtonVal() {
        //Debug.Log("getButton called");
        return write("1");
    }

    public string getAnalog()
    {
        return write("4");
    }

    public bool getRunning()
    {
        return running;
    }

    public string setLed(int number, int status)
    {
        return write("l " + number + " " + status + "\r\n");
    }
}
