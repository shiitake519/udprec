using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using System.IO;

public class UDPReceive : MonoBehaviour
{
    int LOCA_LPORT = 3333;
    static UdpClient udp;
    Thread thread;
    public SerialHandler serialHandler;
    

    void Start ()
    {
        var local = new IPEndPoint(IPAddress.Any, 8001);
        //udp = new UdpClient(LOCA_LPORT);
        udp = new UdpClient(local);
        //udp.Client.ReceiveTimeout = 1000;
        thread = new Thread(new ThreadStart(ThreadMethod));
        thread.Start();
        }

    void Update ()
    {
        //serialHandler.Write("a\n");
        //タイムアウトするなら、何か違う文字を送り続け、その文字以外なら処理でいいかも
    }

    void OnApplicationQuit()
    {
        thread.Abort();
    }

    private void ThreadMethod()
    {
        while(true)
        {
            var remoteEP = new IPEndPoint(IPAddress.Any, 8001);
            //IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);
            //float recx = BitConverter.ToSingle(data, 0);
            string text = Encoding.ASCII.GetString(data);
            //text = "a";
            Debug.Log(text);
            //string s1 = recx.ToString("f1");
            //text = "a";
            serialHandler.Write(text);//受け取ったデータをシリアル通信でマイコンへ送信する部分をかく
                //Debug.Log("success");

        }
    } 
}