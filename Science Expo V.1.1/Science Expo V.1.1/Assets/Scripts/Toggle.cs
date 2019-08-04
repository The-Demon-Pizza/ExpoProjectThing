using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour {

    TrailRenderer tr;

    private void Start()
    {
        tr = this.GetComponentInChildren<TrailRenderer>();
    }


    void Update () {
        if (GameObject.Find("Toggle_Trails").GetComponent<TrailToggle>().TrailBool)
        {
            tr.time = 40f;
            tr.startColor = new Color(tr.startColor.r, tr.startColor.g, tr.startColor.g, 1);
            tr.endColor = new Color(tr.endColor.r, tr.endColor.g, tr.endColor.g, 1);
        }
        else
        {
            tr.time = 40f;
            tr.startColor = new Color(tr.startColor.r, tr.startColor.g, tr.startColor.g, 0);
            tr.endColor = new Color(tr.endColor.r, tr.endColor.g, tr.endColor.g, 0);
        }
        
	}

}