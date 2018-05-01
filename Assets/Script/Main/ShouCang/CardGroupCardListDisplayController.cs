using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class CardGroupCardListDisplayController : MonoBehaviour {

    public Image groupImg;
    public Text groupName;
    public Text groupCardNum;

    public RectTransform rect;
    public GameObject cardPrefab;
    public GameObject Content;

    float high;

    public List<GameObject> cardList = new List<GameObject>();

    public void SetCardGroup()
    {

    }

    public void DisplayCardGroup(int heroIndex, string name, GROUP_CARD_LIST list)
    {
        groupImg.sprite = common.GetSpriteByHeroIndex(heroIndex);
        groupName.text = name;
        if (list != null)
        {
            DisplayCardList(list);
        }

    }
    public void DisplayCardList(GROUP_CARD_LIST list)
    {
        int num = 0;
        foreach (GameObject gb in cardList)
        {
            Destroy(gb);
        }
        cardList.Clear();
        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(Content.GetComponent<RectTransform>().sizeDelta.x, high * list.values.Count);
        for (int i=0;i< list.values.Count;i++)
        {
            GameObject obj = Instantiate(cardPrefab) as GameObject;
            obj.transform.SetParent(Content.transform);
            obj.GetComponent<SingleCardTiaoDisplayController>().SetIndex(i);
            obj.GetComponent<SingleCardTiaoDisplayController>().SetCard(list.values[i].CardID);
            obj.GetComponent<SingleCardTiaoDisplayController>().SetCardNum(list.values[i].CardNum);
            num += list.values[i].CardNum;
            cardList.Add(obj);
        }
        groupCardNum.text = num.ToString();
    }
    public void SetCardNum(int num)
    {
        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(Content.GetComponent<RectTransform>().sizeDelta.x, high * num);

        while (cardList.Count < num)
        {
            GameObject obj = Instantiate(cardPrefab) as GameObject;
            obj.transform.SetParent(Content.transform);
            cardList.Add(obj);

        }
        while (cardList.Count > num)
        {
            GameObject obj = cardList[cardList.Count - 1];
            cardList.Remove(obj);
            Destroy(obj);
        }

        for(int i=0;i<cardList.Count;i++)
        {
            cardList[i].GetComponent<SingleCardTiaoDisplayController>().SetIndex(i);
        }
    }
    // Use this for initialization
    void Start()
    {
        high = cardPrefab.GetComponent<RectTransform>().sizeDelta.y+5;
        //List<ulong> ls = common.GetRandCardList(30);
        //DisplayCardGroup(1, "cesgsu", ls);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
