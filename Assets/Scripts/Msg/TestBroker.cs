using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBroker
{
    private TestBroker()
    {
        
    }
    private static TestBroker _inistance;

    public static TestBroker GetInistance()
    {
        if(_inistance==null) _inistance = new TestBroker();
        if(_inistance.msgConstain==null) _inistance.msgConstain = new Queue<string>();
        return _inistance;
    }
    
    public Queue<string> msgConstain;

    private string message;

    public string GetMsg()
    {
        return message;
    }
    public void Send(string msg)
    {
        _inistance.msgConstain.Enqueue(msg);
    }
    
    public string Receive()
    {
        if (_inistance.msgConstain == null)
        {
            return "not msg";
        }
        var tempMsg =   _inistance.msgConstain;
        if (tempMsg.Count > 0)
        {
            var msg = _inistance.msgConstain.Dequeue();
            _inistance.message += "\n" + msg;
            return  msg;
        }
        return "not msg";
    }
}
