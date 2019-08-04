using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailToggle : MonoBehaviour {

    public bool TrailBool = false;

    public void ToggleTrail()
        {
            TrailBool = !TrailBool;
        }
}
