using System;
using System.Collections;
using System.Collections.Generic;
using Msg;
using UnityEngine;
using UnityEngine.UI;

public class MplayerMgr : MonoBehaviour
{
    private MessagePlayer _player0, _player1;
    private PublisherTopic _publisher;
    private SubscriberTopic _subscriber;
    
    public bool isgaming;

    public float fpsTime;
    // Start is called before the first frame update
    void Start()
    {
        isgaming = true;
        _player0 = new Mplayer0();
        _player1 = new Mplayer1();

        StartCoroutine(Receive());
 
        
        
        _publisher = new PublisherTopic();
        _publisher.CreatePub();
         
        _subscriber = new SubscriberTopic();
        _subscriber.Sub();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateText()
    {
        GameObject.Find("UpdataText").GetComponent<Text>().text = TestBroker.GetInistance().GetMsg();
        GameObject.Find("Updata2Text").GetComponent<Text>().text = TestTopic.GetInistance().GetMsg();
    }

    public void PlayerZeroSend(string msg)
    {
        _player0.Send("player0--" +msg+"\n"+DateTime.Now);
    }
    public void PlayerOneSend(string msg)
    {
        _player1.Send("player1--" +msg+"\n"+DateTime.Now);
    }


    public void PubMsg(string msg)
    {
        _publisher.Pub(""+msg);
    }
    IEnumerator Receive()
    {
        yield return null;
        while (isgaming)
        {
           var playMsg = TestBroker.GetInistance().Receive();
           print(string.Format("player:{0}",playMsg));
           yield return new WaitForSeconds(fpsTime);
           UpdateText();
        }
    }
}
