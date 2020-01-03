using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscriberTopic  
{
    public SubscriberTopic()
    {
       
    }

    public void Sub()
    {
        TestTopic.GetInistance().SubTopic += (msg) =>
        {
            var result = string.Format("成功接收信息： {0}", msg); 
            return  result;
        };
    }
}
