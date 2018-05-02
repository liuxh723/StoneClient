using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleFollowerController : BaseEntity {

    public Image imageFollower;
    public Text textAttcak;
    public Text textHp;

    public GameObject taunt;
    public GameObject divien;
    public GameObject steal;

    public GameObject enMove;

    public override void UpdateDisplay()
    {
        imageFollower.sprite = common.GetSpriteByCardID(ulong.Parse(cardID));
        textAttcak.text = att;
        textHp.text = HP;

        taunt.SetActive(bool.Parse(isTaunt));
        divien.SetActive(bool.Parse(isDivineShield));
        steal.SetActive(bool.Parse(isStealth));
        enMove.SetActive(bool.Parse(isAbled));

        base.UpdateDisplay();
    }

}
