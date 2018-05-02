using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerManager : MonoBehaviour {

    public GameObject FollowerPrefab;
    public List<GameObject> FollowerList = new List<GameObject>();

    private float weight;
    private float height;

    public BaseEntity AddFollower()
    {
        GameObject obj = Instantiate(FollowerPrefab);
        FollowerList.Add(obj);
        obj.transform.SetParent(transform);
        UpdataFollowerlist();
        return obj.GetComponent<SingleFollowerController>();
    }

    public void UpdataFollowerlist()
    {
        for (int i = 0; i < FollowerList.Count; i++)
        {
            //Cards[i].transform.Rotate(0, 0, 30-i*6);
            FollowerList[i].transform.position = transform.position + new Vector3(-(FollowerList.Count/2.0f-i-0.5f)* weight, 0, 0);

        }
    }
    public void RemoveFollower(BaseEntity sfc)
    {
        GameObject tagObj = null;

        foreach (GameObject obj in FollowerList)
        {
            if (obj.GetComponent<SingleFollowerController>() == sfc)
            {
                tagObj = obj;
            }
        }
        if (tagObj != null)
        {
            FollowerList.Remove(tagObj);
            Destroy(tagObj);
            UpdataFollowerlist();

        }
        else
        {
            Debug.Log("移除手牌失败");
        }


    }

    // Use this for initialization
    void Start () {
        weight = GetComponent<RectTransform>().rect.size.x/7;
        height = GetComponent<RectTransform>().rect.size.y;
        AddFollower();
        AddFollower();
        AddFollower();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
