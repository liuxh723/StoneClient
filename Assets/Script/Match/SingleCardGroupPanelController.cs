using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleCardGroupPanelController : MonoBehaviour {

    // Use this for initialization
    public Image img;
    public Text nameText;

    private int index;
	void Start () {
		
	}
    public void SetInfo(int RolyType,string cgname,int cgIndex)
    {
        img.sprite = Resources.Load<Sprite>("hero/" + (index + 1).ToString());
        nameText.text = cgname;
        index = cgIndex;


    }
	public void click()
    {
        CardGroupSelectController.controller.CardGroupSelected(index);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
