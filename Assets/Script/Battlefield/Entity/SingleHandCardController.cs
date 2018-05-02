using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleHandCardController : BaseEntity {

    public Text textShuijing;
    public Text textAttack;
    public Text textHp;
    public Text textName;
    public Text textDes;
    public Image Ion;

    public override void UpdateDisplay()
    {
        textShuijing.text = cost;
        textAttack.text = att;
        textHp.text = HP;
        textName.text = common.GetCardNameByCardID(ulong.Parse(cardID));
        textDes.text = common.GetCardDesByCardID(ulong.Parse(cardID));
        Ion.sprite = common.GetSpriteByCardID(ulong.Parse(cardID));

        base.UpdateDisplay();
    }
}
