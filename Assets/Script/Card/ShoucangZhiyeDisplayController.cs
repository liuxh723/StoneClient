using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoucangZhiyeDisplayController : MonoBehaviour {

    public Transform zhiyeDisplayArea;
    public Text zhiyeName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseZhiye(int index)
    {
        Debug.LogFormat("当前选择职业：{0}", index);
        zhiyeName.text = Data.HeroCareer[index];
        ShouCangManager.manager.setZhiyeDispaly(index);
    }
}
