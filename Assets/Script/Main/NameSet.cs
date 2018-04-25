using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class NameSet : MonoBehaviour {

    public InputField name;
	// Use this for initialization
	public void setName()
    {

        Account me = KBEngineApp.app.player() as Account;
        if (name.text == "")
        {
            Debug.LogError("名称不能为空");
            return;
        }
        if(me != null)
        {
            me.baseCall("reqChangeName", name.text);
        }
    }
    private void Start()
    {
      
    }
}
