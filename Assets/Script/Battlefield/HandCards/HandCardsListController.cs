using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandCardsListController : MonoBehaviour {

    public GameObject[] Cards;
	// Use this for initialization
	void Start () {

        for(int i = 0;i<10;i++)
        {
            //Cards[i].transform.Rotate(0, 0, 30-i*6);
            Cards[i].transform.position = new Vector3(140+i * 30, 160,0);

        }
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
