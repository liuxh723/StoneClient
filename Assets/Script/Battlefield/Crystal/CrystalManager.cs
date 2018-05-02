using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalManager : MonoBehaviour {

    public CrystalDisplayController cdc;
    public Text self;
    public Text Animy;

    private int selfMaxCry;
    private int selfActiveCry;
    private int aniMaxCry;
    private int aniActiveCry;


    private void Awake()
    {
        

    }
    // Use this for initialization
    void Start () {

       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCrystal(int selfMax, int selfActive,int aniMax,int aniActive)
    {
        if(selfMax > -1)
        {
            selfMaxCry = selfMax;
        }
        if (selfActive > -1)
        {
            selfActiveCry = selfActive;
        }
        if (aniMax > -1)
        {
            aniMaxCry = aniMax;
        }
        if (aniActive > -1)
        {
            aniActiveCry = aniActive;
        }


    }

    public void UpdataDisplay()
    {
        self.text = selfActiveCry.ToString() + "/" + selfMaxCry.ToString();
        Animy.text = aniActiveCry.ToString() + "/" + aniMaxCry.ToString();
        cdc.SetCrystalDisplay(selfMaxCry, selfActiveCry);
    }

    private void OnGUI()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SetCrystal(8, 6, 7, 0);
            UpdataDisplay();
        }
    }
}
