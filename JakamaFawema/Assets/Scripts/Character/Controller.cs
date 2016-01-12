using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Controller : MonoBehaviour{

    static SerialPort stream = new SerialPort("COM6", 115200);
    static string receivedData = "EMPTY";

    public static bool c_Jump = false; 

    public static Controller sharedInstance = new Controller();

	// Use this for initialization

    private Controller(){
        streamStart();
    }

    private void streamStart()
    {
        if (!stream.IsOpen) stream.Open();
        Debug.Log("baum");
    }

    private int write(string toWrite)
    {
        stream.Write(toWrite);
        receivedData = stream.ReadLine();
        return System.Convert.ToInt32(receivedData, 16);

    }

    public int getButtonVal() {
        return write("1");
    }
}
