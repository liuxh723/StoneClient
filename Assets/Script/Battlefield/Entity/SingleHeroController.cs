using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class SingleHeroController : BaseEntity {

    public Text textAttack;
    public Text textHp;
    public Text textArmor;
    public Image imageHero;

    public override void UpdateDisplay()
    {
        //textAttack.text = att;
        //textHp.text = HP;
        //textArmor.text = armor;
        //imageHero.sprite = common.GetSpriteByHeroIndex(int.Parse(cardID));

        //GetComponent<Outline>().enabled = (isAbled == "1");
        base.UpdateDisplay();
    }

    private void Start()
    {
        KBEngine.Event.registerOut("onHPchanged", this, "set_HP");
    }

    public void set_RoleType(int type)
    {
        Debug.LogFormat("set roletype:{0}", type);
        imageHero.sprite = common.GetSpriteByHeroIndex(type);
    }
}
