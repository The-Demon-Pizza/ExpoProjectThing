using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICircle : MonoBehaviour {
    ObjectSelector mm;
    GameObject selector;
    GameObject mo;
    MoveCamera mc;
    GameObject camObj;
    Camera cam;
	// Use this for initialization
	void Start () {
        mm = GameObject.FindObjectOfType<ObjectSelector>();
        mc = GameObject.FindObjectOfType<MoveCamera>();
        camObj = GameObject.Find("Main Camera");
        cam = mc.GetComponent<Camera>();
        mo = GameObject.Find("MouseOver");
        selector = GameObject.Find("Selector");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (mm.selectedObject != null)
        {
            selector.SetActive(true);
             
                float selectedScale = 15 * mm.selectedObject.GetComponent<Transform>().localScale.x / (camObj.transform.position - mm.selectedObject.transform.position).magnitude;
            if (selectedScale >= 1)
            {
                selector.transform.localScale = new Vector2(selectedScale, selectedScale);
            }
            else
            {
                selector.transform.localScale = new Vector2(0.9f, 0.9f);
            }
            
        }
        else
        {
            selector.SetActive(false);
        }

        if (mm.mouseOverObject != null)
        {
            mo.SetActive(true);
            mo.transform.position = new Vector3(cam.WorldToScreenPoint(mm.mouseOverObject.transform.position).x, cam.WorldToScreenPoint(mm.mouseOverObject.transform.position).y, 0f);
            
                float scale = 15 * mm.mouseOverObject.GetComponent<Transform>().localScale.x / (camObj.transform.position - mm.mouseOverObject.transform.position).magnitude;
            if (scale >= 1.8)
            {
                mo.transform.localScale = new Vector2(scale, scale);
            }
            else
            {
                mo.transform.localScale = new Vector2(1.7f, 1.7f);
            }
            
        }
        else
        {
            mo.SetActive(false);
        }
    }
}
