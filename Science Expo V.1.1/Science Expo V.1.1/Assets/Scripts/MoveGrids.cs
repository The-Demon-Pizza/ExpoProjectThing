using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGrids : MonoBehaviour {

    ObjectSelector mm;

	// Use this for initialization
	void Start () {
        mm = GameObject.FindObjectOfType<ObjectSelector>();	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject gridX = GameObject.Find("Grid_X");
        GameObject gridY = GameObject.Find("Grid_Y");
        GameObject gridZ = GameObject.Find("Grid_Z");
        GameObject cp = GameObject.Find("CameraPivot");

        if (mm.selectedObject != null)
        {

            gridX.transform.position = new Vector3(cp.transform.position.x, 0f, 0f);
            gridY.transform.position = new Vector3(0f, cp.transform.position.y, 0f);
            gridZ.transform.position = new Vector3(0f, 0f, cp.transform.position.z);
        }	
        else
        {
            gridX.transform.position = new Vector3(0f, 0f, 0f);
            gridY.transform.position = new Vector3(0f, 0f, 0f);
            gridZ.transform.position = new Vector3(0f, 0f, 0f);
        }
	}
}
