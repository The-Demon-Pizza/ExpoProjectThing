using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateOrbit : MonoBehaviour
{

    public Vector3[] orbitPoints;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        orbitPoints = new Vector3[10];
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        orbitPoints[0] = this.transform.position;
        for (int i = 1; i < 10; i++)
        {
            Vector3 totalForce;
            totalForce = new Vector3(0, 0, 0);

            Attractor[] attractors = FindObjectsOfType<Attractor>();
            foreach (Attractor attractor in attractors)
            {
                
                if (attractor != this)
                {
                    Rigidbody rbToAttract = attractor.rb;

                    Vector3 direction = orbitPoints[i - 1] - rbToAttract.position;
                    float distanceSqr = direction.sqrMagnitude;

                    float forceMagnitude = this.GetComponent<Attractor>().G * (rb.mass * rbToAttract.mass) / distanceSqr / rb.mass;
                    Vector3 force = direction.normalized * forceMagnitude;

                     totalForce = totalForce + force / rb.mass;
                }

            }

            orbitPoints[i] = orbitPoints[i - 1] + totalForce;
        }
        this.GetComponentInChildren<LineRenderer>().SetPositions(orbitPoints);
    }
}
