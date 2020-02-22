using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deb : MonoBehaviour
{
    public SerialHandler serialHandler;
    // Start is called before the first frame update
    void Start()
    {
        serialHandler.OnDataReceived += OnDataReceived;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDataReceived(string message)
    {
        //string[] data = message.Split(',');
        //if (data.Length < 2) return;

        try 
        {
            Debug.Log(message);


        } catch (System.Exception e) {
            Debug.LogWarning(e.Message);
        }
    }
}
