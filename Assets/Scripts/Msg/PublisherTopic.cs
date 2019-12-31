using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublisherTopic
{
 public delegate void Topic(string msg);

 public event Topic PubTopic;

 public void CreatePub()
 {
     PubTopic += TestTopic.GetInistance().PubMsg;
 }
 
 
 public void Pub(string msg)
 {
   PubTopic?.Invoke(msg);
 }
}
