using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class CardDisplayController : MonoBehaviour {

    public Text Shuijing;
    public Text Attack;
    public Text Hp;
    public Text Name;
    public Text Des;
    public Image Ion;
    public GameObject Num;

    private ulong cardID;
        
    public void setCard(CARD_INFO cardInFo)
    {
        Dictionary<string, object> cardInfo = new Dictionary<string, object>();
        if (Data.data.card.TryGetValue(cardInFo.CardID, out cardInfo) == false)
        {
            Debug.LogFormat("卡牌数据获取失败：{0}", cardInFo.CardID);
            return;
        }
        cardID = cardInFo.CardID;
        Shuijing.text = cardInfo["cost"].ToString();
        Attack.text = cardInfo["att"].ToString();
        Hp.text = cardInfo["HP"].ToString();
        Name.text = cardInfo["name"].ToString();
        Des.text = cardInfo["des"].ToString();
        Ion.sprite = Resources.Load<Sprite>("card/"+ cardInFo.CardID.ToString());

        if (cardInFo.CardNum >1)
        {
            Num.GetComponent<Text>().text = "X"+cardInFo.CardNum.ToString();
            Num.SetActive(true);
        }
        else
        {
            Num.SetActive(false);
        }


    }
    public void SetOpenCard(ulong CardID)
    {
        Dictionary<string, object> cardInfo = new Dictionary<string, object>();
        if (Data.data.card.TryGetValue(CardID, out cardInfo) == false)
        {
            Debug.LogFormat("卡牌数据获取失败：{0}", CardID);
            return;
        }
        Shuijing.text = cardInfo["cost"].ToString();
        Attack.text = cardInfo["att"].ToString();
        Hp.text = cardInfo["HP"].ToString();
        Name.text = cardInfo["name"].ToString();
        Des.text = cardInfo["des"].ToString();
        Ion.sprite = Resources.Load<Sprite>("card/" + CardID.ToString());

            Num.SetActive(false);

    }

    public void Click()
    {
        Debug.LogFormat("Click:{0}", cardID);
        ShouCangManager.manager.AddCard(cardID);
    }
}
