using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class CardGroupSelectController : MonoBehaviour {

    public Image heroImg;
    public Text groupName;
    private int CGIdex;
    public GameObject prefab;
    public List<GameObject> GroupList = new List<GameObject>();

    public GameObject displayArea;

    public GameObject selectPanel;
    public GameObject matchPanel;

    public static CardGroupSelectController controller;


    public void CardGroupSelected(int index)
    {
        heroImg.sprite = Resources.Load<Sprite>("hero/hero" + (Data.CardGroup_Info_list[index].RoleType + 1).ToString());
        groupName.text = Data.CardGroup_Info_list[index].Name;
        CGIdex = index;
    }

    public void StartMatch()
    {
        selectPanel.SetActive(false);
        matchPanel.SetActive(true);
        matchPanel.GetComponent<MatchPanelManager>().StartMatch(CGIdex);
        Debug.LogFormat("开始匹配 index:{0}", groupName.text, CGIdex);
       
    }
    private void Awake()
    {
        controller = this;
        if (Data.CardGroup_Info_list.Count == 0)
        {
            groupName.text = "没有卡组";
            return;
        }
        for (int i = 0; i < Data.CardGroup_Info_list.Count; i++)
        {
            GameObject obj = Instantiate(prefab) as GameObject;
            obj.transform.SetParent(displayArea.transform);
            obj.GetComponent<SingleCardGroupPanelController>().SetInfo(Data.CardGroup_Info_list[i].RoleType, Data.CardGroup_Info_list[i].Name, i);
            GroupList.Add(obj);
        }
        CardGroupSelected(0);
    }
}
