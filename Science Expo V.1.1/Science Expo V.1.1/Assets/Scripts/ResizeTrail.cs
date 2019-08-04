using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeTrail : MonoBehaviour {

    TrailRenderer tr;
    GameObject CamObj;
    Slider TrailSlider;
    Slider TimeSlider;

	// Use this for initialization
	void Start () {
        tr = this.GetComponentInChildren<TrailRenderer>();
        CamObj = GameObject.Find("Main Camera");
        TrailSlider = GameObject.Find("TrailSlider").GetComponent<Slider>();
        TimeSlider = GameObject.Find("TimeSlider").GetComponent<Slider>();

    }
	
	// Update is called once per frame
	void Update () {
        tr.widthMultiplier = 0.05f * (CamObj.transform.position - this.transform.position).magnitude;
        tr.widthMultiplier = Mathf.Clamp(tr.widthMultiplier, this.transform.localScale.x, 10000);
        tr.time = TrailSlider.value / TimeSlider.value;
    }
}
