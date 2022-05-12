using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;


public class Landmark
{
    public Vector3 pos;
    public float cooldown;
}
public class ReceiveScript : MonoBehaviour
{
    public OSCReceiver receiver;
    public Landmark[] landmarks;
    void Start()
    {
        landmarks = new Landmark[33];
        for (int i = 0; i < 33; i++)
        {
            receiver.Bind($"/message/landmark{i}", MessageReceived);
            landmarks[i] = new Landmark();
        }
        
    }


    protected void MessageReceived(OSCMessage message)
    {
        string messageString = message.Values[0].StringValue;
        string[] messageArray = messageString.Split(';');
        Landmark landmark = new Landmark();
        int id = int.Parse(messageArray[0]);
        landmarks[id].pos = new Vector3(float.Parse(messageArray[1]), float.Parse(messageArray[2]), float.Parse(messageArray[3]));
        landmarks[id].cooldown = 0.2f;
    }
}
