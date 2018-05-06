using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using KBEngine;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour {

    public GameObject selfHeroPrefab;
    public GameObject otherHeroPrefab;
    public GameObject self;
    public GameObject other;
	// Use this for initialization
	void Start () {

        installEvents();

    }
    void installEvents()
    {
        // in world
        //KBEngine.Event.registerOut("addSpaceGeometryMapping", this, "addSpaceGeometryMapping");
        //KBEngine.Event.registerOut("onEnterWorld", this, "onEnterWorld");
        //KBEngine.Event.registerOut("onLeaveWorld", this, "onLeaveWorld");
        //KBEngine.Event.registerOut("set_position", this, "set_position");
        //KBEngine.Event.registerOut("set_direction", this, "set_direction");
        //KBEngine.Event.registerOut("updatePosition", this, "updatePosition");
        //KBEngine.Event.registerOut("onControlled", this, "onControlled");

        // in world(register by scripts)
        KBEngine.Event.registerOut("onAvatarEnterWorld", this, "onAvatarEnterWorld");
        KBEngine.Event.registerOut("onOtherAvatarEnterWorld", this, "onOtherAvatarEnterWorld");
        KBEngine.Event.registerOut("onRoleTypechanged", this, "onRoleTypechanged");
        //KBEngine.Event.registerOut("set_MP", this, "set_MP");
        //KBEngine.Event.registerOut("set_HP_Max", this, "set_HP_Max");
        //KBEngine.Event.registerOut("set_MP_Max", this, "set_MP_Max");
        //KBEngine.Event.registerOut("set_level", this, "set_level");
        //KBEngine.Event.registerOut("set_name", this, "set_entityName");
        //KBEngine.Event.registerOut("set_state", this, "set_state");
        //KBEngine.Event.registerOut("set_moveSpeed", this, "set_moveSpeed");
        //KBEngine.Event.registerOut("set_modelScale", this, "set_modelScale");
        //KBEngine.Event.registerOut("set_modelID", this, "set_modelID");
        //KBEngine.Event.registerOut("recvDamage", this, "recvDamage");
        //KBEngine.Event.registerOut("otherAvatarOnJump", this, "otherAvatarOnJump");
        //KBEngine.Event.registerOut("onAddSkill", this, "onAddSkill");
    }
    // Update is called once per frame
    void Update () {
		
	}

    public void onAvatarEnterWorld(UInt64 rndUUID, Int32 eid, Avatar avatar)
    {
        if (!avatar.isPlayer())
        {
            return;
        }

        //UI.inst.info("loading scene...(加载场景中...)");
        Debug.Log("loading scene...");
        GameObject obj = Instantiate(selfHeroPrefab) as GameObject;
        obj.transform.SetParent(self.transform);
       // obj.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
        avatar.renderObj = obj;

    }

    public void onOtherAvatarEnterWorld(UInt64 rndUUID, Int32 eid, Avatar avatar)
    {
        //UI.inst.info("loading scene...(加载场景中...)");
        Debug.Log("loading scene...");
        GameObject obj = Instantiate(otherHeroPrefab) as GameObject;
        obj.transform.SetParent(other.transform);
       // obj.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);
        avatar.renderObj = obj;

    }

    public void onRoleTypechanged(Avatar avatar,Int32 roleType)
    {
        GameObject obj = avatar.renderObj as GameObject;
        obj.GetComponent<SingleHeroController>().set_RoleType(roleType);
    }
}
