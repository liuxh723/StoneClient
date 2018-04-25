using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePackController : MonoBehaviour {

    public OpenPackController openPackController;

    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseDrag()
    {
        transform.position = Input.mousePosition;
    }

    public void OnMouseDragEnd()
    {
        // if (transform.position.)
        //RectTransform.c.
       
        Rect rect = openPackController.OpenArea.GetComponent<RectTransform>().rect;
        Debug.LogFormat("mouse:{0},{1}", openPackController.OpenArea.position.x, openPackController.OpenArea.position.y);
        Debug.LogFormat("rect:{0}，{1}，{2}，{3}", rect.xMin, rect.yMax, rect.xMax, rect.yMin);
        if (Input.mousePosition.x > openPackController.OpenArea.position.x+rect.x && Input.mousePosition.x < openPackController.OpenArea.position.x+rect.xMax && Input.mousePosition.y > openPackController.OpenArea.position.y+rect.y && Input.mousePosition.y < openPackController.OpenArea.position.y+rect.yMax)
        {
            Debug.Log("IN");
            transform.position = openPackController.OpenArea.position;
            openPackController.OpenPack();

        }
        else
        {
            transform.position = startPosition;
        }
    }

    public void EndOpenPack()
    {
        transform.position = startPosition;
    }
}
