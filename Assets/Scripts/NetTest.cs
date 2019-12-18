using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
 

public class NetTest : MonoBehaviour
{
    bool IsClose = false;
    /// <summary>
    /// 当前管理对象
    /// </summary>
    Socket sk;
    /// <summary>
    /// 客户端
    /// </summary>
    TcpClient client;
    /// <summary>
    /// 当前连接服务端地址
    /// </summary>
    IPAddress Ipaddress;
    /// <summary>
    /// 当前连接服务端端口号
    /// </summary>
    int Port;
    /// <summary>
    /// 服务端IP+端口
    /// </summary>
    IPEndPoint ip;
    /// <summary>
    /// 发送与接收使用的流
    /// </summary>
    NetworkStream nStream;

    private void Start()
    {
        SocketConnect();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ExitSocketConnect();
        }
 
    }

    
    public  void SocketConnect()
    {
        client = new TcpClient();
        client.Connect("192.168.0.8",4040);
    }
    
    /// <summary>
    /// 退出socket
    /// </summary>
    public void ExitSocketConnect()
    {
        if (client != null)
        {
            if (client.Connected)
            {
                client.Close();
                client.Dispose();   
            }
        }
    }

    private void OnApplicationQuit()
    {
        ExitSocketConnect();
    }
}
