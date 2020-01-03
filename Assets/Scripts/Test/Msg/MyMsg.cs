using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMsg : MonoBehaviour
{
    public string  localName;
    public virtual void  Start()
    {
        MyMsgQueue.GetInistance().OnSendMsg += Send;

        MyMsgQueue.GetInistance().OnReviceMsg += Recive;

        MyMsgQueue.GetInistance().MysMsg += Send;

        localName = gameObject.name;
    }
    
    public void SendMsg(string msg)
    {
        var str = localName + ":" + msg;
       MyMsgQueue.GetInistance().MysMsg(str);
    }

    protected virtual void Send(string msg)
    {
       var str = msg.Split(':');
        if(!str[0].Equals(gameObject.name))
        print(gameObject.name + ":"+ str[1]);
    }
    
    protected virtual string Recive(string msg)
    {
        print(msg);
        return msg;
    }
}
