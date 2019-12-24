using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using Newtonsoft.Json.Converters;
using Newtonsoft;
using Newtonsoft.Json;
using HouYou;

public class JA
{
    public string aa;
    public string ss;
    public string cc;
}

public class LitjsonTest : MonoBehaviour
{
 
    //创建数据库
    public  static SufferBd _sufferBd = new SufferBd();
 
    void Start()
    {
  
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Train train = new Train();
            train.Id = 333;
            train.TrainName = "仰卧起坐";
            var message = ControlBD.AddTrain(ControlBD.Suffers()[0], train);
             
            print(message); 
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Train train = new Train();
            train.Id = 333;
            train.TrainName = "仰卧起坐";
            var message = ControlBD.RemoveTrain(train);
            print(message); 
        }
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            Train train = new Train();
            train.Id = 333;
            train.TrainName = "仰卧起坐";
            var message = ControlBD.HasTrain(train);
            print(message); 
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            var  mybd = ControlBD.PushSufferBD();
            User mary = new User();
            print(mybd.ToJson());
          
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            var  mybd = ControlBD.SaveBD();
          
            print(mybd);
            
        }
    }

    private void TestNewJson()
    {
        //往表中添加数据
        Suffer mary = new Suffer();
        mary.Id = 0;
        mary.Name = "mary";
        Suffer mary1 = new Suffer();
        mary1.Id = 1;
        mary1.Name = "mary1";
        Suffer mary2 = new Suffer();
        mary2.Id = 2;
        mary2.Name = "mary2";
        Suffer mary3 = new Suffer();
        mary3.Id = 3;
        mary3.Name = "mary3";
        _sufferBd.Sufferble.Suffer.Add(mary);
        _sufferBd.Sufferble.Suffer.Add(mary1);
        _sufferBd.Sufferble.Suffer.Add(mary2);
        _sufferBd.Sufferble.Suffer.Add(mary3);
        
        Estima estima = new Estima();
        estima.Id = 5;
        estima.EstimaName = "xxxx";
        Estima estima1 = new Estima();
        estima1.Id = 121;
        estima1.EstimaName = "xxxx2";
        Estima estima2 = new Estima();
        estima2.EstimaName = "xxxxxs";
        estima2.Id = 2;
        _sufferBd.Estimateble.Estima.Add(estima);
        _sufferBd.Estimateble.Estima.Add(estima1);
        _sufferBd.Estimateble.Estima.Add(estima2);
        
        Train train = new Train();
        train.Id = 2;
        Train train1 = new Train();
        train1.Id = 1;
 
        _sufferBd.Trainble.Train.Add(train);
        _sufferBd.Trainble.Train.Add(train1);
 
        print(_sufferBd.ToJson());
    }
    private void TestlitJson_unityJson()
    {
        string jsona = @"
                        {
                            ""aa"": ""sss"",
                            ""ss"": ""aaa""
                        }
                        ";

        #region 正常读写测试

//------------------------通过申明类转换实例
        var jaobj = JsonMapper.ToObject<JA>(jsona);
        print(jaobj.aa);
        print(jaobj.ss);
        print(jaobj.cc);

        var obj = JsonUtility.FromJson<JA>(jsona);
        print("JsonUtility:" + obj.aa);
        print("JsonUtility:" + obj.ss);
        print("JsonUtility:" + obj.cc);


//------------------------通过实例转换字符串
        JA _ja = new JA();

        //string空值为null
        var strja = JsonMapper.ToJson(_ja);
        print(strja);

        //string空值为""
        var strja2 = JsonUtility.ToJson(_ja);
        print("JsonUtility:" + strja2);
//-----------------------没有申明类转换实例

        var ja = JsonMapper.ToObject(jsona);
        foreach (var key in ja.Keys)
        {
            print(key + ":" + ja[key]);
        }
        //u3d 自带的必须指定申明类型
        //JsonUtility.FromJson(json,type);
        //JsonUtility.FromJson<T>(json);

//------------------------通过转换实例转字符串
        //互换实例对象        
        //转换正常
        var str = JsonMapper.ToJson(obj);
        print(str);

        //无法转换
        var str2 = JsonUtility.ToJson(ja);
        print("JsonUtility:" + str2);

        #endregion


        #region 字典测试

        #endregion


        #region 列表测试

        #endregion


        #region 其他测试

        #endregion
    }
}