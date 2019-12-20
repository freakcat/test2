using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class JA
{
    public string aa;
    public string ss;
    public string cc;
}

public class LitjsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
    }
}