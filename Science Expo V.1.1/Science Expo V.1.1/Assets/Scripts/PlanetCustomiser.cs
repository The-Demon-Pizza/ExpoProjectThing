using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetCustomiser : MonoBehaviour {

    public bool CustomiserOpen = false;
    GameObject OpenButton;
    GameObject mc;

	// Use this for initialization
	void Start () {
        OpenButton = GameObject.Find("Customise");
        mc = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenCustomiser()
    {
        if (!CustomiserOpen)
        {
            
            this.GetComponent<Image>().enabled = true;
            OpenButton.GetComponent<Image>().enabled = false;
            OpenButton.GetComponent<Button>().enabled = false;
            OpenButton.GetComponentInChildren<Text>().enabled = false;
        }
    }
}
