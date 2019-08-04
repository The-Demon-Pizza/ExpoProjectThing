using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attractor : MonoBehaviour {

	public float G;
	public Rigidbody rb;
    public float localT = 1;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        G = GameObject.FindObjectOfType<GravityConstant>().G;
    }

    void FixedUpdate (){

        if (GameObject.FindObjectOfType<ChangeTime>().T != localT)
        {
            rb.velocity = (rb.velocity / localT) * GameObject.FindObjectOfType<ChangeTime>().T;
        }

        localT = GameObject.FindObjectOfType<ChangeTime>().T;

        Attractor[] attractors = FindObjectsOfType<Attractor>();
		foreach (Attractor attractor in attractors){
			Attract (attractor);
		}        
	}

    void Attract (Attractor objToAttract)
    {

        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rbToAttract.position - rb.position;
        float distanceSqr = direction.sqrMagnitude;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / distanceSqr;
        Vector3 force = direction.normalized * forceMagnitude * Mathf.Pow(localT, 2);
        rb.AddForce(force);
    }
}
