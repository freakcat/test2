#define LOG_INFO
using System;

namespace BaseLearn
{
    using UnityEngine;

    public class DefinDemo : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            TestDefine testDefine = new TestDefine();
            testDefine.Haha();


            PartMain.Id = 1;
            print(PartMain.Id);
            print(PartMain.Num);
            PartMain.Part = Part.Learn;
            var format = Enum.Format(typeof(Part), PartMain.Part,"d");
            print(format);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}