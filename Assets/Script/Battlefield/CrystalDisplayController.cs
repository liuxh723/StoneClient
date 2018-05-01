using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalDisplayController : MonoBehaviour {

    public List<GameObject> crystalList = new List<GameObject>();

    public Sprite actve;
    public Sprite used;


	// Use this for initialization


	void Start () {
		for(int i=0;i<10;i++)
        {
            GameObject obj = transform.Find("Image (" + i.ToString() + ")").gameObject;
            crystalList.Add(obj);

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCrystalDisplay(int max,int activeNum)
    {
        Debug.LogFormat("count:{0}", crystalList.Count.ToString());
        for(int i=0;i<10;i++)
        {
            if(i >= max)
            { 
            crystalList[i].GetComponent<Image>().enabled = false;
            }
            if(i >= activeNum)
            {
                crystalList[i].GetComponent<Image>().sprite = used;
            }
            else
            {
                crystalList[i].GetComponent<Image>().sprite = actve;
            }
        }
    }
}
