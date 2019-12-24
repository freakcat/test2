using System.Collections.Generic;
using HouYou;
using UnityEngine;
using UnityEngine.UI;

public class CreateOne : MonoBehaviour 
{
    private User user;

    private InputField inputname, inputpassword;

    private Button btnlogin;
    
    void Start()
    {
        inputname = transform.Find("InputFieldName").GetComponent<InputField>();
   
        inputpassword = transform.Find("InputFieldPassword").GetComponent<InputField>();
    
        btnlogin = transform.Find("BtnJoin").GetComponent<Button>();
         
        btnlogin.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        var str = BtnJoin();
        print(str);
    }

    public string BtnJoin()
    {
        user = new User();
        user.Name = inputname.text;
        user.Pw = inputpassword.text;
        return ControlBD.AddUser(user);
    }
}
