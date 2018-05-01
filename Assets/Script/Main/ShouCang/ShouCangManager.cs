using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class ShouCangManager : MonoBehaviour {

    public static ShouCangManager manager;
    public int page;
    public Text pageText;
    public CARD_LIST cardList = new CARD_LIST();
    public int zhiyeIndex;

    public GameObject per;
    public GameObject next;

    public ShoucangCardDisplayController scc;

    public int state = 0;
    public GROUP_CARD_LIST GroupCardList = new GROUP_CARD_LIST();
    public int RoleType;
    public string Name;
    public int index;

    public GameObject cardGroupDisplay;
    public GameObject groupCardDisplay;

    public GameObject zhiyeSelectDisplay;

    public Text btnText;


    private void OnEnable()
    {
        ChangeState(0);
    }
    public void ChangeState(int st)
    {
        if(st==0)
        {   //卡组列表
            cardGroupDisplay.SetActive(true);
            groupCardDisplay.SetActive(false);
            Name = "";
            RoleType = -1;
            index = -1;
            GroupCardList.values.Clear();
            btnText.text = "新建卡组";
            groupCardDisplay.GetComponent<CardGroupCardListDisplayController>().DisplayCardGroup(0, "SetName", GroupCardList);
            UpdataCardDisplay();
            state = 0;

            UpdataCardGroupDisplay();

        }
        if(st==1)
        {
            cardGroupDisplay.SetActive(false);
            groupCardDisplay.SetActive(true);
            Name = "";
            RoleType = -1;
            index = -1;
            GroupCardList.values.Clear();
            UpdataCardDisplay();
            btnText.text = "保存";
            state = 1;
        }

    }
    public void EditCardGroup(int groupIndex)
    {
        ChangeState(1);
        CARDGROUP_INFO info = Data.CardGroup_Info_list[groupIndex];
        Name = info.Name;
        index = groupIndex;
        RoleType = info.RoleType;
        GroupCardList = info.CardList;
        groupCardDisplay.GetComponent<CardGroupCardListDisplayController>().DisplayCardGroup(RoleType, Name, info.CardList);
        //for (int i= 0; i<info.CardList.values.Count;i++)
        //{
        //    AddCard(info.CardList.values[i].CardID);
        //}



    }
    public void SetCardGroup(string name,int zhiye)
    {
        if (state == 1)
        {
          
        }
    }

    public void SaveCardGroupInfo(string name, int zhiye)
    {
        zhiyeSelectDisplay.SetActive(false);
        ChangeState(1);
        Name = name;
        RoleType = zhiye;
        groupCardDisplay.GetComponent<CardGroupCardListDisplayController>().DisplayCardGroup(zhiye, name, null);
    }
    public void RemoveCard(ulong cardID)
    {
        Debug.LogFormat("state:{0}", state);
        if (state == 1)
        {

            for (int i = 0; i < GroupCardList.values.Count; i++)
            {
                if (GroupCardList.values[i].CardID == cardID)
                {

                    if(GroupCardList.values[i].CardNum == 2)
                    {
                        Debug.Log("减少卡牌");
                        GroupCardList.values[i].CardNum = 1;
                        groupCardDisplay.GetComponent<CardGroupCardListDisplayController>().DisplayCardGroup(RoleType, Name, GroupCardList);
                        return;
                    }
                    if (GroupCardList.values[i].CardNum == 1)
                    {
                        Debug.Log("移除卡牌");
                        GroupCardList.values.Remove(GroupCardList.values[i]);
                        groupCardDisplay.GetComponent<CardGroupCardListDisplayController>().DisplayCardGroup(RoleType, Name, GroupCardList);
                        return;
                    }



                    //}
                    //else
                    //{
                    //    Debug.LogFormat("CardID:{0} 超过2张", cardID);
                    //    return;
                    //}

                }
            }

            //CARD_INFO info = new CARD_INFO();
            //info.CardID = cardID;
            //info.CardNum = 1;
            //Debug.LogFormat("移除卡牌：{0}", cardID);
            //GroupCardList.values.Remove(cardID);
            //Debug.LogFormat("cardID:{0} 超过2张", cardID);
            //groupCardDisplay.GetComponent<CardGroupCardListDisplayController>().DisplayCardList(GroupCardList);
        }

    }
    public void DeleteCardGroup(int index)
    {
        Account me = KBEngineApp.app.player() as Account;
        if (me != null)
        {
            Debug.LogFormat("删除卡组 index：{0}", index);
            me.baseEntityCall.reqDelCardGroup((sbyte)index);
        }
    }
    public void AddCard(ulong cardID)
    {
        if (state == 1)
        {
           
          for(int i = 0;i<  GroupCardList.values.Count;i++)
          {
               if(  GroupCardList.values[i].CardID == cardID)
                {
                    if (GroupCardList.values[i].CardNum < 2)
                    {
                        foreach (CARD_INFO cardinfo in Data.CardList.values)
                        {
                            if (cardinfo.CardID == cardID)
                            {
                                if(cardinfo.CardNum <= 1)
                                {
                                    Debug.LogFormat("CardID:{0} 少于2张", cardID);
                                    return;
                                }
                            }
                        }

                       
                        GroupCardList.values[i].CardNum += 1;

                        groupCardDisplay.GetComponent<CardGroupCardListDisplayController>().DisplayCardGroup(RoleType, Name, GroupCardList);
                        return;
                    }
                    else
                    {
                        Debug.LogFormat("CardID:{0} 超过2张", cardID);
                        return;
                    }

                }
          }

            CARD_INFO info = new CARD_INFO();
            info.CardID = cardID;
            info.CardNum = 1;
            Debug.LogFormat("添加卡牌：{0}", cardID);
             GroupCardList.values.Add(info);
            groupCardDisplay.GetComponent<CardGroupCardListDisplayController>().DisplayCardList(GroupCardList);
        }
    }
    public void BtnClick()
    {
        if(state == 0)
        {

            ChangeState(1);
            zhiyeSelectDisplay.SetActive(true);
            index = -1;
            return;
        }
        if(state == 1)
        {
            Account me = KBEngineApp.app.player() as Account;
            if (me != null)
            {
                //CARDGROUP_INFO info = new CARDGROUP_INFO();
                ////info.CardGroupID = (sbyte)index;
                //info.RoleType = (byte)RoleType;
                //info.Name = Name;
                //info.CardList = GroupCardList;
                Debug.LogFormat("保存卡组 Name：{1}，RoleType：{1}", Name, (byte)RoleType);
                //me.baseCall("reqEditCardGroup", -1, Name, (byte)RoleType, GroupCardList);
                me.baseEntityCall.reqEditCardGroup((sbyte)index, Name, (byte)RoleType, GroupCardList);
               
            }
            ChangeState(0);
            return;
        }
    }
    public void UpdataCardGroupDisplay()
    {
        Debug.Log("更新卡牌显示");

            if (CardGroupDisplayManager.manager != null)
            {
                CardGroupDisplayManager.manager.DisplayCardGroup(Data.CardGroup_Info_list);
            }

    
    }

    public void setZhiyeDispaly(int index)
    {
        if (zhiyeIndex != index)
        {
            page = 0;
            cardList.values.Clear();
            foreach (CARD_INFO l in Data.CardList.values)
            {
                if(Data.data.card[l.CardID]["zhiye"].ToString()== index.ToString())
                {
                    cardList.values.Add(l);
                }
            }
            zhiyeIndex = index;
            UpdataCardDisplay();

        }


    }
    public void UpdataCardDisplay()
    {
       CARD_LIST displayList = new CARD_LIST();
        for(int i=0;i<8;i++)
        {
            int cardInedx = page * 8 + i;
            if(cardInedx<cardList.values.Count)
            {
                displayList.values.Add(cardList.values[cardInedx]);
            }
        }
        scc.DisplayCard(displayList);
        pageText.text = (page+1).ToString();
        if (page == 0)
        {
            per.SetActive(false);
        }
        else
        {
            per.SetActive(true);
        }

        if (page == (cardList.values.Count / 8))
        {
            next.SetActive(false);
        }
        else
        {
            if (page == (cardList.values.Count / 8) && (cardList.values.Count % 8 == 0))
            {
                next.SetActive(false);
            }
            else
            {
                next.SetActive(true);
            }
        }
    }
    public void PerPage()
    {
        if(page>=1)
        {
            page -= 1;
        }
        UpdataCardDisplay();
    }
    public void NextPage()
    {
        if (page < (cardList.values.Count / 8))
        {
            page += 1;
            UpdataCardDisplay();
        }

       
    }

    public void setPageDispaly()
    {

    }
    // Use this for initialization

    private void Awake()
    {
        manager = this;
        KBEngine.Event.registerOut("onGroupListChanged", this, "UpdataCardGroupDisplay");
    }
    void Start () {
        pageText.text = (page + 1).ToString();

        if (page > 1)
        {
            page -= 1;
        }
        if (page == 0)
        {
            per.SetActive(false);
        }
        else
        {
            per.SetActive(true);
        }
        if (page < (cardList.values.Count / 8))
        {
            page += 1;
            UpdataCardDisplay();
        }

        if (page == (cardList.values.Count / 8) + 1)
        {
            next.SetActive(false);
        }
        else
        {
            if (page == (cardList.values.Count / 8) && (cardList.values.Count % 8 == 0))
            {
                next.SetActive(false);
            }
            else
            {
                next.SetActive(true);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
