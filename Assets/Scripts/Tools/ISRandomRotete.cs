using UnityEngine;
using System.Collections;

public class ISRandomRotete : MonoBehaviour {

	public Vector3 minDir;
	public Vector3 maxDir;

	private Vector3 rotDir;
	private Transform selfT;

	void Awake(){
		selfT = transform;
		rotDir = new Vector3(Random.Range(minDir.x,maxDir.x),Random.Range(minDir.y,maxDir.y),Random.Range(minDir.z,maxDir.z));
	}

	void Update () {
		selfT.Rotate(rotDir*Time.deltaTime);
	}
}
