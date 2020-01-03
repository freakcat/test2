using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    private MessageOffice moffoce;
    // Start is called before the first frame update
    void Start()
    {
        moffoce = new MessageOffice();
        moffoce.AcceptsMsg("回家吃饭了!");

        moffoce.OnSubscribe += msg =>
        {
            print(msg);
            if (msg.Equals("回家吃饭了!"))
            {
                return "1 shou dao:" +"好的(⊙o⊙)！";
            }
            return "1 shou dao:" +msg;
        };
//        moffoce.OnSubscribe += msg =>
//        {
//            print(msg);
//            return "2 shou dao:" +"不吃了";
//        };
//        moffoce.OnSubscribe += msg =>
//        {
//            print(msg);
//            return "3 shou dao:" +"等一下";
//        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
                 {
                     moffoce.ForwardsMsg();
                 }
    }
}
