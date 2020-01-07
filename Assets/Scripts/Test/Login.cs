using System.Collections;
using System.Collections.Generic;
using HouYou;
using UnityEngine;
using UnityEngine.UI;


public class Login : MonoBehaviour
{
    private User user;

    private InputField inputname, inputpassword;

    private Button btnlogin,btnlogout;

    private bool isline;
    // Start is called before the first frame update
    void Start()
    {
         
        inputname = transform.Find("InputFieldName").GetComponent<InputField>();
        print(inputname.name);
        inputpassword = transform.Find("InputFieldPassword").GetComponent<InputField>();
        print(inputpassword.name);
        btnlogin = transform.Find("BtnLogin").GetComponent<Button>();
        btnlogout= transform.Find("BtnLogout").GetComponent<Button>();
        btnlogin.onClick.AddListener(delegate { OnClick(btnlogin); });
        
        btnlogout.onClick.AddListener(delegate { OnClick(btnlogout); });
    }

    private void OnClick(Button obj)
    {
        if (obj.name == btnlogin.name)
        {
            var str = OnLogin();
            print(str+"///===");
        }

        if (obj.name == btnlogout.name)
        {
          var str =  OnLogout();
          print(str);
        }
        
    }

    public string OnLogin()
    {
        user = new User();
        user.Name = inputname.text;
        if (!ControlBD.HasUser(user)) return "用户不存在";
        user.Pw = inputpassword.text;
        if (!ControlBD.InvailPassWord(user)) return "密码不正确";
        if (!isline)
        {
            isline = true;
            return "验证成功登陆中。。。";
        }
        else
        {
            return "已经登陆";
        }
    }

    public string OnLogout()
    {
        isline = false;
        return "已登出";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
