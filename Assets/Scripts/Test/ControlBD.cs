using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HouYou;
using UnityEngine;

public static class ControlBD
{
    public static string path = Application.dataPath + "/Datas/data";
    private static SufferBd bd;
    private static Dictionary<string, User> _users;
    private static Dictionary<int, Suffer> _suffersDic;
    private static Dictionary<int, Train> _trainsDic;
    private static Dictionary<int, Estima> _estimasDic;
    static ControlBD()
    {
        string jsonstring = File.ReadAllText(path);
        bd = SufferBd.FromJson(jsonstring);
        _users = new Dictionary<string, User>();
        _suffersDic = new Dictionary<int, Suffer>();
        _trainsDic = new Dictionary<int, Train>();
        _estimasDic = new Dictionary<int, Estima>();
        foreach (var user in bd.Users)
        {
            _users[user.Name] = user;
        }
        
        foreach (var sfer in bd.Sufferble.Suffer)
        {
            _suffersDic[sfer.Id] = sfer;
        }
        foreach (var train in bd.Trainble.Train)
        {
            _trainsDic[train.Id] = train;
        }
        foreach (var estima in bd.Estimateble.Estima)
        {
            _estimasDic[estima.Id] = estima;
        }
    }
    public static SufferBd PushSufferBD()
    {
        bd.Users = _users.Values.ToList();
        bd.Sufferble.Suffer = _suffersDic.Values.ToList();
        bd.Trainble.Train = _trainsDic.Values.ToList();
        bd.Estimateble.Estima = _estimasDic.Values.ToList();
        return bd;
    }

    public static string SaveBD()
    {
        var savebd = PushSufferBD();
        try
        {
            File.WriteAllText(path,savebd.ToJson());
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return "保存成功";
    }
 
    public static string AddUser(User user)
    {
        if(_users.ContainsKey(user.Name)) return "已经存在此对象";
        _users.Add(user.Name,user);
        return "创建"+user.Name+"成功";
    }
    public static bool HasUser(User user)
    {
        return _users.ContainsKey(user.Name);
    }
    public static string RemoveUser(User user)
    {
        return _users.Remove(user.Name).ToString();
    }

    public static bool InvailPassWord(User user)
    {
        return _users[user.Name].Pw.Equals(user.Pw);
    }
    
    
    public static string AddSuffer(Suffer suffer)
    {
        if(_suffersDic.ContainsKey(suffer.Id)) return "已经存在此对象";
        _suffersDic.Add(suffer.Id,suffer);
        return "创建"+suffer.Name+"成功";
    }
    public static bool HasSuffer(Suffer suffer)
    {
      return _suffersDic.ContainsKey(suffer.Id);
    }
    public static string RemoveSuffer(Suffer suffer)
    {
        return _suffersDic.Remove(suffer.Id).ToString();
    }
    
    public static List<Suffer> Suffers()
    {
        return _suffersDic.Values.ToList();
    }
    
    
    public static string AddTrain(Suffer suffer, Train train)
    {
         if (!HasSuffer(suffer)) return "用户不存在";
         if(_trainsDic.ContainsKey(train.Id)) return "你已添加这条记录了";
         train.SufferId = suffer.Id; 
         _trainsDic.Add(train.Id,train);
         
         return "创建"+train.TrainName+"成功";
    }
    public static bool HasTrain(Train train)
    {
        return _trainsDic.ContainsKey(train.Id);//?"存在id为"+train.Id+"的用户":"不存在";
    }
    public static string RemoveTrain(Train train)
    {
        return _trainsDic.Remove(train.Id) ? "移除成功" : "移除失败，不存在记录";
    }
 
    public static string AddEstimas(Suffer suffer, Estima estima)
    {
        if (!HasSuffer(suffer)) return "不存在用户";
        if(_estimasDic.ContainsKey(estima.Id)) return "你已添加这条记录了";
        estima.SufferId = suffer.Id;
        _estimasDic.Add(estima.Id,estima);
        return "创建"+estima.EstimaName+"成功";
    }
    public static bool HasEstimas(Estima suffer)
    {
        return _estimasDic.ContainsKey(suffer.Id);
    }
    public static string RemoveEstimas(Estima suffer)
    {
        return _estimasDic.Remove(suffer.Id)?"移除成功":"移除失败，不存在记录";;
    }
}
