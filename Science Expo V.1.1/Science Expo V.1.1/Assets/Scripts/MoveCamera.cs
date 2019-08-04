
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    private Transform xFormCamera;
    private Transform xFormParent;

    private Vector3 LocalRotation;
    public float CameraDistance = 10f;
    private float scale;

    public float MoveSpeed;
    public float MouseSensitivity = 4f;
    public float ScrollSensitivity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;

    public bool CameraDisabled = false;
    private bool CameraIndependent;
    private ObjectSelector mm;

	// Use this for initialization
	void Start () {
        this.xFormCamera = this.transform;
        this.xFormParent = this.transform.parent;
        mm = GameObject.FindObjectOfType<ObjectSelector>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        CameraDisabled = !(Input.GetKey(KeyCode.Mouse1));

        if (mm.selectedObject != null)
        {
            if (CameraIndependent)
            {
                CameraIndependent = false;
                CameraDistance = 10f * mm.selectedObject.transform.localScale.x;
                scale = mm.selectedObject.transform.localScale.z;
            }

        }
        else
        {
            CameraDistance = 0f;
            if (!CameraIndependent)
            {
                transform.parent.position += transform.forward * -10f * scale;
                CameraIndependent = true;
            }

        }

        if (!CameraDisabled)
        {

            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                LocalRotation.y = Mathf.Clamp(LocalRotation.y, -90f, 90f);
            }            
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;
            ScrollAmount *= (this.CameraDistance * 0.3f);
            this.CameraDistance += ScrollAmount * -1f;
        }

        if (mm.selectedObject != null)
        {
            this.CameraDistance = Mathf.Clamp(this.CameraDistance, 1.5f * mm.selectedObject.transform.localScale.x, 100000f);
        }     
        
        Quaternion QT = Quaternion.Euler(LocalRotation.y, LocalRotation.x, 0);
        this.xFormParent.rotation = Quaternion.Lerp(this.xFormParent.rotation, QT, Time.deltaTime * OrbitDampening);

        if(this.xFormCamera.localPosition.z != this.CameraDistance * -1f)
        {
            this.xFormCamera.localPosition = new Vector3(this.xFormCamera.localPosition.x, 0f, Mathf.Lerp(this.xFormCamera.localPosition.z, this.CameraDistance * -1f, Time.deltaTime * ScrollDampening));
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 50f;
        }
        else
        { 
            MoveSpeed = 15f;
        }

        if (mm.selectedObject != null)
        {
            transform.parent.position = mm.selectedObject.transform.position;
        }
        else
        {

            if (Input.GetKey(KeyCode.W))
            {
                transform.parent.position += transform.forward * Time.deltaTime * MoveSpeed;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.parent.position += transform.forward * Time.deltaTime * -MoveSpeed;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.parent.position += transform.right * Time.deltaTime * MoveSpeed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.parent.position += transform.right * Time.deltaTime * -MoveSpeed;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                transform.parent.position += transform.up * Time.deltaTime * MoveSpeed * 0.5f;
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.parent.position += transform.up * Time.deltaTime * -MoveSpeed * 0.5f;
            }
        }

        if (CameraDistance >= 20)
        {
            if (CameraDistance >= 40)
            {
                GameObject.Find("Grid_X").GetComponent<Renderer>().material.mainTextureScale = new Vector2(1500f, 1500f);
                GameObject.Find("Grid_Y").GetComponent<Renderer>().material.mainTextureScale = new Vector2(1500f, 1500f);
                GameObject.Find("Grid_Z").GetComponent<Renderer>().material.mainTextureScale = new Vector2(1500f, 1500f);
            }
            else
            {
                GameObject.Find("Grid_X").GetComponent<Renderer>().material.mainTextureScale = new Vector2(3000f, 3000f);
                GameObject.Find("Grid_Y").GetComponent<Renderer>().material.mainTextureScale = new Vector2(3000f, 3000f);
                GameObject.Find("Grid_Z").GetComponent<Renderer>().material.mainTextureScale = new Vector2(3000f, 3000f);
            }
        }
        else
        {
            GameObject.Find("Grid_X").GetComponent<Renderer>().material.mainTextureScale = new Vector2(6000f, 6000f);
            GameObject.Find("Grid_Y").GetComponent<Renderer>().material.mainTextureScale = new Vector2(6000f, 6000f);
            GameObject.Find("Grid_Z").GetComponent<Renderer>().material.mainTextureScale = new Vector2(6000f, 6000f);
        }


    }
}
