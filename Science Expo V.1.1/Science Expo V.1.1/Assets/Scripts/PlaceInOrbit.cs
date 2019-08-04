using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceInOrbit : MonoBehaviour {

    ObjectSelector mm;

    public GameObject OrbitPrefab;
    public GameObject PlanetPrefab;

    public bool toggleTrails;

    GameObject Orbit;
    GameObject Planet;
    GameObject OrbitButton;
    Plane yPlane;
    Ray ray;
    Camera mainCamera;
    float raycastHit;
    Vector3 planetPos;
    

	// Use this for initialization
	void Start () {
        mm = FindObjectOfType<ObjectSelector>();
        OrbitButton = GameObject.Find("NewPlanet");
        yPlane = new Plane(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f));
        mainCamera = GameObject.FindObjectOfType<Camera>().GetComponent<Camera>();
    }

    void Update ()
    {        
        if (mm.selectedObject != null)
        {     
            OrbitButton.SetActive(true);
        }
        else if (mm.selectedObject == null)
        {
            OrbitButton.SetActive(false);
        }

    }

    // Update is called once per frame
    public void NewOrbit ()
    {
       // Orbit = Instantiate(OrbitPrefab, mm.selectedObject.transform.position, Quaternion.identity);
        //Planet = Instantiate(PlanetPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

        for (int i = 0; i < 1000; i++)
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (yPlane.Raycast(ray, out raycastHit))
            {
                planetPos = ray.GetPoint(raycastHit);
            }
            //Orbit.transform.position = mm.selectedObject.transform.position;
            float orbitScale = (planetPos - mm.selectedObject.transform.position).magnitude;
            //Orbit.transform.localScale = new Vector2(orbitScale, orbitScale);
            //Planet.transform.position = planetPos;
            Debug.Log(planetPos);
        }
        
    }
}
