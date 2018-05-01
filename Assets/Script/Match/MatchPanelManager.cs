using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class MatchPanelManager : MonoBehaviour {

    public Text time;
    public Text title;

    float startTime = 0f;

    int selectIndex;

    public void QuitMatch()
    {
        Account me = KBEngineApp.app.player() as Account;
        if (me != null)
        {
            Debug.LogFormat("取消匹配");
            me.baseEntityCall.reqStopMatch();
        }
    }
    public void StartMatch(int cgIndex)
    {
        title.text = "开始匹配";
        startTime = Time.time;
        Account me = KBEngineApp.app.player() as Account;
        if (me != null)
        {
            Debug.LogFormat("开始匹配 index：{0}", cgIndex);
            me.baseEntityCall.reqStartMatch((sbyte)cgIndex);
        }

    }
    public void GetSelCardGroup(int index)
    {

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnEnable()
    {
        
    }
    private void OnGUI()
    {
        if(startTime == 0f)
        {
            time.text = "";
        }
        else
        {
            time.text = (Time.time - startTime).ToString();
        }
        
    }
}
