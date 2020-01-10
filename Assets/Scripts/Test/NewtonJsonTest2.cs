using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace Test
{
    public class NewtonJsonTest2: MonoBehaviour
    {
        private void Start()
        {
            Test0();
        }

        public void Test0()
        {
            JArray array = new JArray();
            array.Add("Manual text");
            array.Add(new DateTime(2000, 5, 23));

            JObject o = new JObject();
            o["MyArray"] = array;

            string json = o.ToString();
 
            JArray arrayRoot = new JArray();
            arrayRoot.Add(array);
            JObject oRoot = new JObject();
            oRoot["Root"] = arrayRoot;
            string jsonRoot = oRoot.ToString();
 
            print(jsonRoot);
        }

    }
}