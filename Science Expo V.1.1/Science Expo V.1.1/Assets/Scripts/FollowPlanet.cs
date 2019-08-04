using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlanet : MonoBehaviour {

    public GameObject Planet;
    Camera mc;

	// Use this for initialization
	void Start () {
        mc = GameObject.Find("Main Camera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.position = mc.WorldToScreenPoint(Planet.transform.position);
        Mathf.Clamp(this.GetComponent<RectTransform>().position.z, -10f, 10f);
            if (this.transform.localPosition.z > 0)
        {
            this.GetComponent<Text>().enabled = true;
        }
        else
        {
            this.GetComponent<Text>().enabled = false;
        }
	}
}
