using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTopic  
{
    public delegate string Topic(string msg);

    public event Topic SubTopic;

    private static TestTopic _inistance;

    public static TestTopic GetInistance()
    {
        if (_inistance == null)
        {
            _inistance = new TestTopic();
        }

        return _inistance;
    }

    private string message;
 
    public string GetMsg()
    {
        return _inistance.message;
    }
    public void PubMsg(string msg)
    {
      _inistance.message += "\n"+ SubTopic?.Invoke(msg);
    }
}
