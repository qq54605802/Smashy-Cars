using UnityEngine;
using System.Collections;

public class ISTranslate : MonoBehaviour {

	public Vector3 speedAndDir;

	private Transform thisT;

	void Start(){
		thisT = transform;
	}

	void Update () {
		thisT.Translate(speedAndDir*Time.deltaTime);
	}
}
