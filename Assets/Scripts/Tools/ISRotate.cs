using UnityEngine;
using System.Collections;

public class ISRotate : MonoBehaviour {

	public Vector3 direction;
	
	private Transform thisT;
	
	// Use this for initialization
	void Start () {
		thisT=transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		thisT.Rotate(direction*Time.deltaTime*35);
	}
}
