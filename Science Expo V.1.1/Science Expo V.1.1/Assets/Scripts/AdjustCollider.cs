using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustCollider : MonoBehaviour {

    SphereCollider planetCollider;
    GameObject CamObj;
    ObjectSelector mm;

	// Use this for initialization
	void Start () {
        planetCollider = this.GetComponent<SphereCollider>();
        CamObj = GameObject.Find("Main Camera");
        mm = GameObject.FindObjectOfType<ObjectSelector>();
    }
	
	// Update is called once per frame
	void Update () {
        if (this != mm.selectedObject)
        {
            planetCollider.radius = 15f * Mathf.Sqrt(Mathf.Abs((CamObj.transform.position - this.transform.position).magnitude));
            planetCollider.radius = Mathf.Clamp(planetCollider.radius, 0.5f, (CamObj.transform.position - this.transform.position).magnitude * 0.3f / this.transform.localScale.x);
        }
        else
        {
            planetCollider.radius = 0.5f;
        }

	}
}
