using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOffice
{
    public delegate string Subscribe(string msg);


    private string message;
    //-订阅
    public event Subscribe OnSubscribe;
 
    //存储注册的发布内容
    private Queue<string> messageQueue;
    public MessageOffice()
    {
        messageQueue = new Queue<string>();
    }
    //接受信息-注册发布
    public void AcceptsMsg(string msg)
    {
        messageQueue.Enqueue(msg);
    }
    //转发信息-发布
    public void ForwardsMsg()
    {
        
        if(messageQueue.Count<=0)
        {
            message += OnSubscribe?.Invoke("没有新的发布。。。"); 
            Debug.Log(message);
            return;
        }
         
        var msg = messageQueue.Dequeue();
        message += OnSubscribe?.Invoke(msg);
        
        if(message.Equals("1 shou dao:" +"好的(⊙o⊙)！")) Debug.Log("GGGGGGGGGGGGGGG");
        Debug.Log(message);
    }
 
}
