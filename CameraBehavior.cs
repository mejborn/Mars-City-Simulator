using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
    [SerializeField]
    float movementSpeed = 5f;
    [SerializeField]
    float zoomSpeed = 50f;
    [SerializeField]
    float rotationSpeed = 10f;
    [SerializeField]
    float mouseMovementZone = 10f;

    Vector2 currentMousePosition;
    Vector2 lastMousePosition;

    bool currentMouseWheel;
    bool lastMouseWheel;
    Vector3 rotationPoint;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        currentMousePosition = Input.mousePosition;
        currentMouseWheel = Input.GetMouseButton(2);

        Vector3 forward3D = this.transform.rotation * Vector3.forward;
        Vector3 forward = forward3D; forward.y = 0;
        Vector3 left = this.transform.rotation * Vector3.left; left.y = 0;
        Vector3 up = Vector3.up;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || (Input.mousePosition.y > Screen.height - mouseMovementZone) && !currentMouseWheel)
            this.transform.position += forward * movementSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || (Input.mousePosition.y < mouseMovementZone) && !currentMouseWheel)
            this.transform.position -= forward * movementSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || (Input.mousePosition.x < mouseMovementZone) && !currentMouseWheel)
            this.transform.position += left * movementSpeed * Time.deltaTime;
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || (Input.mousePosition.x > Screen.width - mouseMovementZone) && !currentMouseWheel)
            this.transform.position -= left * movementSpeed * Time.deltaTime;

        if (currentMouseWheel && !lastMouseWheel)
        {
            RaycastHit hit;
            Physics.Raycast(new Ray(this.transform.position, forward3D), out hit);
            rotationPoint = hit.point;
        }
            

        if (Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")) > 0)
            this.transform.position += forward3D * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;

        if (currentMouseWheel)
            this.transform.RotateAround(rotationPoint, Vector3.up, -(currentMousePosition.x - lastMousePosition.x) * rotationSpeed * Time.deltaTime);


        lastMousePosition = currentMousePosition;
        lastMouseWheel = currentMouseWheel;
    }
}
