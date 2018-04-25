using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class MainControler : MonoBehaviour {

    public GameObject nameSetObj;
    public GameObject shopObj;
    public GameObject kabaoObj;
    public GameObject shoucangObj;
	// Use this for initialization
	void Start () {

        nameSetObj.SetActive(Data.accountNama == string.Empty);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void MatchBtn()
    {

    }
    public void KabaoBtn()
    {
        kabaoObj.SetActive(true);
    }
    public void ShoucangBtn()
    {
        Account me = KBEngineApp.app.player() as Account; 
        if (me != null)
        {
            //me.baseCall("reqCardList");
           // me.baseEntityCall.reqCardList();
        }
        shoucangObj.SetActive(true);
    }
    public void ShopBtn()
    {
        shopObj.SetActive(true);
    }
    public void QuestBtn()
    {

    }
}
