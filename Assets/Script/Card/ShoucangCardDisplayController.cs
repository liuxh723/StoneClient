using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class ShoucangCardDisplayController : MonoBehaviour {

    public GameObject[] CardDisplayList;

    public void DisplayCard(CARD_LIST list)
    {
        int displayNum = list.values.Count;

        if(displayNum >8)
        {
            return;
        }
        for (int j = 0; j < 8; j++)
        {
            CardDisplayList[j].SetActive(false);
           
        }
        for (int i=0;i< displayNum; i++)
        {
            CardDisplayList[i].SetActive(true);
            CardDisplayList[i].GetComponent<CardDisplayController>().setCard(list.values[i]);
        }

    }
	// Use this for initialization
	void Start () {
        //List<ulong> list = new List<ulong>();
        //list.Add(10000001);
        //list.Add(10000002);
        //list.Add(10000003);
        //list.Add(10000004);
        //list.Add(10000005);

        //DisplayCard(list);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
