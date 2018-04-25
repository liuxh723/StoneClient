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
    public CARD_LIST GroupCardList = new CARD_LIST();
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
        {
            cardGroupDisplay.SetActive(true);
            groupCardDisplay.SetActive(false);
            Name = "";
            RoleType = -1;
            index = -1;
            GroupCardList.Clear();
            btnText.text = "新建卡组";
            UpdataCardDisplay();
            state = 0;


        }
        if(st==1)
        {
            cardGroupDisplay.SetActive(false);
            groupCardDisplay.SetActive(true);
            Name = "";
            RoleType = -1;
            index = -1;
            GroupCardList.Clear();
            UpdataCardDisplay();
            btnText.text = "保存";
            state = 1;
        }

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
    public void AddCard(ulong cardID)
    {
        if (state == 1)
        {
           
          for(int i = 0;i< GroupCardList.Count;i++)
          {
               if( GroupCardList[i].CardID == cardID)
                {
                    if(GroupCardList[i].CardNum <2)
                    {
                        GroupCardList[i].CardNum += 1;

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
            GroupCardList.Add(info);
            groupCardDisplay.GetComponent<CardGroupCardListDisplayController>().DisplayCardList(GroupCardList);
        }
    }
    public void BtnClick()
    {
        if(state == 0)
        {
            ChangeState(1);
            zhiyeSelectDisplay.SetActive(true);
            return;
        }
        if(state == 1)
        {
            Account me = KBEngineApp.app.player() as Account;
            if (me != null)
            {
                CARDGROUP_INFO info = new CARDGROUP_INFO();
                //info.CardGroupID = (sbyte)index;
                info.RoleType = (byte)RoleType;
                info.Name = Name;
                info.CardList = GroupCardList;

                me.baseEntityCall.reqEditCardGroup(info);
               
            }
            ChangeState(0);
            return;
        }
    }
    public void UpdataCardGroupDisplay()
    {

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
            cardList.Clear();
            foreach (CARD_INFO l in Data.CardList)
            {
                if(Data.data.card[l.CardID]["zhiye"].ToString()== index.ToString())
                {
                    cardList.Add(l);
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
            if(cardInedx<cardList.Count)
            {
                displayList.Add(cardList[cardInedx]);
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

        if (page == (cardList.Count / 8))
        {
            next.SetActive(false);
        }
        else
        {
            if (page == (cardList.Count / 8) && (cardList.Count % 8 == 0))
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
        if (page < (cardList.Count / 8))
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
        if (page < (cardList.Count / 8))
        {
            page += 1;
            UpdataCardDisplay();
        }

        if (page == (cardList.Count / 8) + 1)
        {
            next.SetActive(false);
        }
        else
        {
            if (page == (cardList.Count / 8) && (cardList.Count % 8 == 0))
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
