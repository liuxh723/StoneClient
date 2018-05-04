using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class BattlefieldController : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Account me = KBEngineApp.app.player() as Account;
        if(me != null)
        {
            me.baseEntityCall.onEnterBattlefieldFinished();
        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
