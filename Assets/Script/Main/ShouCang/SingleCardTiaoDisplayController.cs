using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class SingleCardTiaoDisplayController : MonoBehaviour {

    public Image img;
    public Text cardName;
    public Text cardNum;

    public int index;
    public void SetCard(CARD_INFO info)
    {
        img.sprite = common.GetSpriteByCardID(info.CardID);
        cardName.text = Data.data.card[info.CardID]["name"].ToString();
        cardNum.text = info.CardNum.ToString();
    }

    public void Delete()
    {
        Debug.LogFormat("移除卡牌：{0}", index);
    }

    public void SetIndex(int i)
    {
        index = i;
    }
	// Use this for initialization

    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
