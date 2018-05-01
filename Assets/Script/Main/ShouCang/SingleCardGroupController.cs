using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleCardGroupController : MonoBehaviour {

    public Image heroImg;
    public Text groupName;

    public int index;

    public void SetCardGroup(int heroIndex,string name)
    {
        heroImg.sprite = Resources.Load<Sprite>("hero/0" + heroIndex.ToString());
        groupName.text = name;
    }

    public void EditCardGroup()
    {
        Debug.LogFormat("修改卡组：{0}", index);
        ShouCangManager.manager.EditCardGroup(index);
    }
    public void DeleteCardGroup()
    {
        Debug.LogFormat("删除卡组：{0}", index);
        ShouCangManager.manager.DeleteCardGroup(index);
    }
    public void SetIndex(int i)
    {
        index = i;
    }
	// Use this for initialization
	void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
