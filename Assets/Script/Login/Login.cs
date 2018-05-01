using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using KBEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

    public InputField id;
    public InputField pwd;

    public Text msg;

    public void onLogin()
    {
        string strID = id.text;
        string strPWD = pwd.text;
        KBEngine.Event.fireIn("login", strID, strPWD, System.Text.Encoding.UTF8.GetBytes("PC"));
    }
    
    public void onLoginFailed(UInt16 failID)
    {
        Debug.LogErrorFormat("登录失败，错误码：{0},原因：{1}", failID,KBEngineApp.app.serverErr(failID));
        msg.text = string.Format("登录失败，错误码：{0},原因：{1}", failID, KBEngineApp.app.serverErr(failID));
    }

    public void onLoginSuccessfully()
    {
        msg.text = string.Format("登录成功");
        Account me = KBEngineApp.app.player() as Account;
        Data.accountNama = me.Name;
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        string path = Application.streamingAssetsPath;
        if(path.Contains("copy"))
        {
            id.text = "222";
            pwd.text = "222";

        }
        else
        {
            id.text = "111";
            pwd.text = "111";
        }
        KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
        KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
    }

}
