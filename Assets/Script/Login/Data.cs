using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using KBEngine;

public class Data : MonoBehaviour {

    public static Data data;
    public static string accountNama;
    public static int Gold;
    public static int Kabao;
    public static CARD_LIST CardList;
    public static CARDGROUP_INFO_LIST CardGroup_Info_list;

    public Dictionary<ulong, Dictionary<string, object>> card = new Dictionary<ulong, Dictionary<string, object>>();


    public static string[] HeroCareer = {
        "法师",
        "猎人",
        "圣骑士",
        "战士",
        "德鲁伊",
        "术士",
        "萨满祭司",
        "牧师",
        "潜行者",
        "死亡骑士",
        "通用"

    };


    public static string[] HeroName = {
        "吉安娜·普罗德摩尔",
        "雷克萨",
        "乌瑟尔•光明使者",
        "加尔鲁什•地狱咆哮",
        "玛法里奥•怒风",
        "古尔丹",
        "萨尔",
        "安杜因•乌瑞恩",
        "瓦莉拉•萨古纳尔",
        "阿尔萨斯 "
    };

    private void Awake()
    {
        data = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Set_Name(object obj)
    {
        Debug.LogFormat("修改名称数据:{0}", obj.ToString());
        accountNama = obj.ToString();

    }
    public void Set_Gold(object obj)
    {
        Debug.LogFormat("修改金币数据:{0}", obj.ToString());
        Gold = int.Parse(obj.ToString());

    }
    public void Set_Kabao(object obj)
    {
        Debug.LogFormat("修改卡包数据:{0}", obj.ToString());
        Kabao = int.Parse(obj.ToString());

    }
    public void Set_CardList(object obj)
    {
        Debug.LogFormat("修改卡牌数据:{0}", obj.ToString());
        CardList = (CARD_LIST)obj;
    }

    public void onReqCardList(object obj,object obj2)
    {
        CardList = (CARD_LIST)obj;
        CardGroup_Info_list = (CARDGROUP_INFO_LIST)obj2;

    }
    private void Update()
    {
       // Debug.LogFormat("修改卡牌数据:{0}", CardList.Count.ToString());
    }
    public void onCardGroupListChanged(object obj)
    {
        Debug.LogFormat("修改卡组数据:{0}", obj.ToString());
        CardGroup_Info_list = (CARDGROUP_INFO_LIST)obj;
        KBEngine.Event.fireOut("onGroupListChanged");
     
    }
    private void Start()
    {
        KBEngine.Event.registerOut("Set_Name", this, "Set_Name");
        KBEngine.Event.registerOut("Set_Gold", this, "Set_Gold");
        KBEngine.Event.registerOut("Set_Kabao", this, "Set_Kabao");
        KBEngine.Event.registerOut("Set_CardList", this, "Set_CardList");
        KBEngine.Event.registerOut("onCardGroupListChanged", this, "onCardGroupListChanged");
        KBEngine.Event.registerOut("onReqCardList", this, "onReqCardList");
        CardList = new CARD_LIST();
        LoadResources();
    }
    
    public void LoadResources()
    {
        string strCard = "";
        strCard = Resources.Load<TextAsset>("d_card_dis.py.datas").text;
        Debug.Log(strCard);

        JsonData cardJson = JasontoDictionary(strCard);
        foreach(string key in cardJson.Keys)
        {
            Dictionary<string, object> cardDic = new Dictionary<string, object>();
            JsonData dic2 = cardJson[key];
            foreach(string key2 in dic2.Keys)
            {
                cardDic.Add(key2, dic2[key2]);
                
            }
            cardDic.Add("sum", 0);
            card.Add(Convert.ToUInt32(key.ToString()), cardDic);
        }


    }

    private JsonData JasontoDictionary(string data)
    {
        try
        {
            return JsonMapper.ToObject(data);
        }catch(Exception exp)
        {
            throw exp;
        }
    }
}
