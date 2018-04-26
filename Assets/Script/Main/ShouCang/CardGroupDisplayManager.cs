using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KBEngine;

public class CardGroupDisplayManager : MonoBehaviour {

    public RectTransform rect;
    public GameObject cardGroupPrefab;
    public static CardGroupDisplayManager manager;

    float high;
    private void Awake()
    {
        manager = this;
    }
    public List<GameObject> cardGroupList = new List<GameObject>();



    public void DisplayCardGroup(CARDGROUP_INFO_LIST cardgroup_info_list)
    {
        Clear();
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, high * cardgroup_info_list.Count);
        for(int i=0;i< cardgroup_info_list.Count;i++)
        {
            GameObject obj = Instantiate(cardGroupPrefab) as GameObject;
            obj.transform.SetParent(transform);
            obj.GetComponent<SingleCardGroupController>().SetIndex(i);
            obj.GetComponent<SingleCardGroupController>().SetCardGroup(cardgroup_info_list[i].RoleType,cardgroup_info_list[i].Name);
            cardGroupList.Add(obj);
        }
    }
    private void Clear()
    {
        for (int i = 0; i < cardGroupList.Count; i++)
        {

            Destroy(cardGroupList[i]);
          
        }
        cardGroupList.Clear();
    }
    public void SetViewNum(int num)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, high * num);

        while(cardGroupList.Count < num)
        {
            GameObject obj = Instantiate(cardGroupPrefab) as GameObject;
            obj.transform.SetParent(transform);
            cardGroupList.Add(obj);

        }
        while (cardGroupList.Count > num)
        {
            GameObject obj = cardGroupList[cardGroupList.Count - 1];
            cardGroupList.Remove(obj);
            Destroy(obj);
        }
        for (int i = 0; i < cardGroupList.Count; i++)
        {
            cardGroupList[i].GetComponent<SingleCardGroupController>().SetIndex(i);
        }
    }
	// Use this for initialization
	void Start () {
        high = cardGroupPrefab.GetComponent<RectTransform>().sizeDelta.y+15;
        //SetViewNum(30);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
