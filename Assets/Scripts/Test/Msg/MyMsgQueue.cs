using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MyMsgQueue
{
    private static MyMsgQueue inistance = null;

    public static MyMsgQueue GetInistance()
    {
        if (inistance == null) inistance = new MyMsgQueue();
       
        return inistance;
    }

    private bool isalive;

    private MyMsgQueue()
    {

    }
    public Func<int, string> _Fun;
    public Action<string> _Action;
    public delegate void sMsg(string str);
    public delegate string rMsg(string str);
    public event sMsg OnSendMsg;
    public event rMsg OnReviceMsg;

    public sMsg MysMsg;

    public void SendMsg(string msg)
    {
        Debug.Log("委托发送：" + msg);
        OnSendMsg?.Invoke(msg);
    }

    public string ReviceMsg(string str)
    {
        Debug.Log("委托接收：" + str);
        return OnReviceMsg?.Invoke(str);
    }
}
