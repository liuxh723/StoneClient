using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleWeaponController : BaseEntity {

    public Image weaponImage;
    public Text textAttcak;
    public Text textHp;

    public override void UpdateDisplay()
    {
        textAttcak.text = att;
        textHp.text = HP;
        weaponImage.sprite = common.GetSpriteByCardID(ulong.Parse(cardID));
        base.UpdateDisplay();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
