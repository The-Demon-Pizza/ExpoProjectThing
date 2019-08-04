using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour {

    public GameObject mouseOverObject;
    public GameObject selectedObject;

	// Use this for initialization
	void Start () {
        mouseOverObject = null;
        selectedObject = null;
	}
	
	// Update is called once per frame
	void Update () {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject.transform.parent.gameObject;
                
                if (Input.GetMouseButtonDown(0))
                {
                    SelectObject(hitObject);                    
                }
                else
                {
                    MouseOverObject(hitObject);
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (Input.mousePosition.x >= Screen.width / 7 && Input.mousePosition.x <= Screen.width -(Screen.width / 3))
                    {
                        selectedObject = null;
                    }   
                }
                else
                {
                    mouseOverObject = null;
                }
            }
	}

    private void SelectObject(GameObject obj)
    {
        if ((obj != null) && (obj != GameObject.Find("Grid_X")) && (obj != GameObject.Find("Grid_Y")) && (obj != GameObject.Find("Grid_Z")))
        {
            selectedObject = obj;
        }
    }

    private void MouseOverObject(GameObject obj)
    {
        if (obj != null && obj != selectedObject)
        {
            mouseOverObject = obj;
        }
    }
}
