using UnityEngine;
using System.Collections;

public class ISSCECamera : MonoBehaviour {

	public Vector3 viewPoint;
	public Transform cameraChild;
	public float rotateSpeed;
	public float scaleSpeed;
	public float minDistance;
	public float maxDistance;

	private float currentScale;
	private Vector3 currentRotation;
	private Vector3 lastMousePosition;
	
	void Start () {
		//Initialization of "current" values, we use settings in scene at the start.
		currentScale = cameraChild.position.z;
		currentRotation = transform.eulerAngles;

		//The very first "last" mouse position should be the position while the game start.
		lastMousePosition = Input.mousePosition;
	}

	public void SetViewPoint(Vector3 newViewPoint){
		viewPoint = newViewPoint;
	}

	void Update () {
		//Calculate the movement delta value of mouse.
		Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
		lastMousePosition = Input.mousePosition;

		//Calculate wanted rotation based on mouse movement.
		//ONLY if player hold left mouse button.
		if (Input.GetMouseButton (1)) {
			currentRotation.x += mouseDelta.y * rotateSpeed * Time.deltaTime;
			currentRotation.y += mouseDelta.x * rotateSpeed * Time.deltaTime;

		}

		//Calculate wanted scale/child camera position based on scroll wheel delta.
		currentScale += -Input.mouseScrollDelta.y * scaleSpeed * Time.deltaTime;
		currentScale = Mathf.Clamp (currentScale, minDistance, maxDistance); //Let currentScale always comfirmed to [minDistance,maxDistance].

		//Apply wanted values to camera
		transform.position = viewPoint;
		transform.eulerAngles = currentRotation;
		cameraChild.localPosition = new Vector3 (0, 0, currentScale);
	}
}
