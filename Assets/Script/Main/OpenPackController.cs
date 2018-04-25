using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class OpenPackController : MonoBehaviour {

    public Text PackNum;

    public Transform OpenArea;

   public  OpenPackResultController orc;
    public SinglePackController spc;

    public void OpenPack()
    {
        Debug.Log("请求开卡包");
        Account me = KBEngineApp.app.player() as Account;
        if (me != null)
        {
            me.baseEntityCall.reqOpenKabao();
            //me.baseCall("reqOpenKabao");
        }
    }

    public void GetOpenPackResult(OPEN_PACK_RUL relList)
    {
        Debug.LogFormat("获取到开包结果：{0}", relList.ToString());
        orc.Display(relList);
        spc.EndOpenPack();
    }

    private void OnGUI()
    {
        PackNum.text = Data.Kabao.ToString();
    }
    private void Start()
    {
        KBEngine.Event.registerOut("onOpenPack", this, "GetOpenPackResult");
    }

}
