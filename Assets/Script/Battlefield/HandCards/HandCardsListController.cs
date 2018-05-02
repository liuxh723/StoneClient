using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandCardsListController : MonoBehaviour {

    public List<GameObject> Cardslist = new List<GameObject>();

    public GameObject cardPrefab;

    public Transform[] listArea;
    public Transform useCardPoint;

    public float xOffset;

    public void UpdataHandCardlist()
    {
        for (int i = 0; i < Cardslist.Count; i++)
        {
            //Cards[i].transform.Rotate(0, 0, 30-i*6);
            Cardslist[i].transform.position = listArea[0].position + new Vector3(xOffset*i, 0, 0);

        }
    }
    
    public BaseEntity AddCard()
    {
        GameObject obj = Instantiate(cardPrefab);
        Cardslist.Add(obj);
        obj.transform.SetParent(transform);
        UpdataHandCardlist();
        return obj.GetComponent<SingleHandCardController>();
    }

    public void RemoveCard(BaseEntity shcc)
    {
        GameObject tagObj = null;

        foreach(GameObject obj in Cardslist)
        {
            if(obj.GetComponent<SingleHandCardController>() == shcc)
            {
                tagObj = obj;
            }
        }
        if(tagObj != null)
        {
            Cardslist.Remove(tagObj);
            Destroy(tagObj);
            UpdataHandCardlist();

        }
        else
        {
            Debug.Log("移除手牌失败");
        }


    }
	// Use this for initialization
	void Start () {

        xOffset = (listArea[1].position.x - listArea[0].position.x) / 9;

        AddCard();
        AddCard();
        AddCard();
        AddCard();
        //for (int j = 5; j < 10; j++)
        //{
        //    Cards[j].transform.Rotate(0, 0, -(j-4) * 6);
        //    Cards[j].transform.position = new Vector3(140 + j * 30, 180 - (j-5)* 5, 0);

        //}

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
