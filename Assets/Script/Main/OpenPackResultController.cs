using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class OpenPackResultController : MonoBehaviour {


    public GameObject[] cards;
    public GameObject btn;
	// Use this for initialization
	void Start () {
        Show(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Display(OPEN_PACK_RUL cardList)
    {
        Show(true);
        for(int i= 0;i<5;i++)
        {
            //Debug.LogFormat("openPack card:{0}", cardList[i]);
            cards[i].GetComponent<CardDisplayController>().SetOpenCard(cardList[i]);
        }
    }
    public void Show(bool isPlay)
    {

            foreach (GameObject obj in cards)
            {
                obj.SetActive(isPlay);

            }
            btn.SetActive(isPlay);

    }
}
