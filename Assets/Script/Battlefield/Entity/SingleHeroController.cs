using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleHeroController : BaseEntity {

    public Text textAttack;
    public Text textHp;
    public Text textArmor;
    public Image imageHero;

    public override void UpdateDisplay()
    {
        textAttack.text = att;
        textHp.text = HP;
        textArmor.text = armor;
        imageHero.sprite = common.GetSpriteByHeroIndex(int.Parse(cardID));

        GetComponent<Outline>().enabled = (isAbled == "1");
        base.UpdateDisplay();
    }
}
