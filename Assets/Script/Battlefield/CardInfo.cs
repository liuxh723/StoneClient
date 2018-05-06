using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class CardInfo : CardInfoBase {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void onEnterWorld()
    {
        base.onEnterWorld();
        
        if(this.pos == "")
        {
            Debug.LogAssertionFormat("card[{0}] enter world", this.cardID);
        }
    }
}
