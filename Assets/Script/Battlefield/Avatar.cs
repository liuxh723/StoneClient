using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class Avatar : AvatarBase {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void onHPChanged(short oldValue)
    {
        KBEngine.Event.fireOut("onHPchanged", HP);
    }

    public override void onRoleTypeChanged(byte oldValue)
    {
        KBEngine.Event.fireOut("onRoleTypechanged", new object[] { this, RoleType });
        base.onRoleTypeChanged(oldValue);
    }

    public override void onEnterWorld()
    {
        base.onEnterWorld();
        if (isPlayer())
        {
            Debug.LogFormat("Avata[{0}] enter world", this.id);
            KBEngine.Event.fireOut("onAvatarEnterWorld", new object[] { KBEngineApp.app.entity_uuid, id, this });
          


        }
        else
        {
            KBEngine.Event.fireOut("onOtherAvatarEnterWorld", new object[] { KBEngineApp.app.entity_uuid, id, this });
            Debug.LogFormat("other Avata[{0}] enter world", this.id);
        }
    }
}

