using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;


public class ShopControler : MonoBehaviour {

    public InputField buyNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Buy()
    {
        int num = int.Parse(buyNum.text);
        if(num<=0)
        {
            Debug.Log("输入数字不合法");
        }
        else
        {
            BuyKabao(num);
        }
    }
    private void BuyKabao(int num)
    {
        Account me = KBEngineApp.app.player() as Account;
        if(me != null)
        {
            Debug.Log("购买卡包");
            me.baseCall("reqBuyKabao", num);
        }
    }
}
