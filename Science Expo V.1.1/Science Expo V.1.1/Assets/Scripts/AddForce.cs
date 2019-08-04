using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {
    public float forceX;
    public float forceY;
    public float forceZ;

    // Use this for initialization
    void Start () {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(forceX, forceY, forceZ));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
