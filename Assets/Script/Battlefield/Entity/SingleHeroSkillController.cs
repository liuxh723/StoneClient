using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SingleHeroSkillController : BaseEntity {

    public Image imageSkill;

    public override void UpdateDisplay()
    {
        string index = cardID.Substring(cardID.Length - 1, 1);
        imageSkill.sprite = Resources.Load<Sprite>("HeroSkill/" + index);
        base.UpdateDisplay();
    }
}
