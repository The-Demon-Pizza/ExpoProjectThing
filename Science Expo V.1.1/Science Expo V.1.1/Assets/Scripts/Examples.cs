using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Examples : MonoBehaviour {

    ObjectSelector mm;
    MoveCamera MainCamera;

    GameObject Sun;
    GameObject Mercury;
    GameObject Venus;
    GameObject Earth;
    GameObject Mars;
    GameObject Jupiter;
    GameObject Saturn;
    GameObject Uranus;
    GameObject Neptune;
    GameObject Moon;

    GameObject Text;

    public GameObject SunPrefab;
    public GameObject MercuryPrefab;
    public GameObject VenusPrefab;
    public GameObject EarthPrefab;
    public GameObject MarsPrefab;
    public GameObject JupiterPrefab;
    public GameObject SaturnPrefab;
    public GameObject UranusPrefab;
    public GameObject NeptunePrefab;
    public GameObject MoonPrefab;

    public GameObject TextPrefab;

    public float Scale = 1;

    // Use this for initialization
    void Start () {
        mm = GameObject.FindObjectOfType<ObjectSelector>();
        MainCamera = GameObject.FindObjectOfType<MoveCamera>();
        Sun = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SolarSystem()
    {
        Sun = Instantiate(SunPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Sun.SetActive(true);
        mm.selectedObject = Sun;
        InstantiateText(Sun, "Sun");

        Mercury = Instantiate(MercuryPrefab, new Vector3(0f, 0f, 4544.812f), Quaternion.identity);
        Mercury.SetActive(true);
        Mercury.GetComponent<AddForce>().forceX = 50000f;
        Mercury.GetComponent<AddForce>().forceY = 6139.23f;
        Mercury.GetComponent<AddForce>().forceZ = -25000f;        
        InstantiateText(Mercury, "Mercury");

        Venus = Instantiate(VenusPrefab, new Vector3(0f, 0f, 8492.3f), Quaternion.identity);
        Venus.SetActive(true);
        Venus.GetComponent<AddForce>().forceX = 850000f;
        InstantiateText(Venus, "Venus");

        Earth = Instantiate(EarthPrefab, new Vector3(0f, 0f, 11740.7f), Quaternion.identity);
        Earth.SetActive(true);
        Earth.GetComponent<AddForce>().forceX = 900000f;
        InstantiateText(Earth, "Earth");

        Mars = Instantiate(MarsPrefab, new Vector3(0f, 0f, 17885.73f), Quaternion.identity);
        Mars.SetActive(true);
        Mars.GetComponent<AddForce>().forceX = 75000f;
        InstantiateText(Mars, "Mars");
    }

    public void EarthMoon()
    {
        Earth = Instantiate(EarthPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Earth.SetActive(true);
        mm.selectedObject = Earth;
        InstantiateText(Earth, "Earth");


        Moon = Instantiate(MoonPrefab, new Vector3(0f, 0f, 120.67f), Quaternion.identity);
        Moon.SetActive(true);
        Moon.GetComponent<AddForce>().forceX = 2400f;
        InstantiateText(Moon, "Moon");

        MainCamera.CameraDistance = 90;
        MainCamera.transform.parent.rotation = new Quaternion(-35f, 0f, 0f, 0f);
    }

    void InstantiateText(GameObject planet, string planetName)
    {
        Text = Instantiate(TextPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Text.SetActive(true);
        Text.transform.SetParent(GameObject.Find("Canvas").transform);
        Text.transform.position = new Vector3(0f, 0f, 0f);
        Text.GetComponent<FollowPlanet>().Planet = planet;
        Text.GetComponent<Text>().text = planetName;
    }
}
