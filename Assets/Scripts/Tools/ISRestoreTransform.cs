using UnityEngine;
using System.Collections;

public class ISRestoreTransform : MonoBehaviour {

	Vector3 pos;
	Quaternion rot;
	Transform selfT;

	void Awake () {
		selfT = transform;
		pos = selfT.localPosition;
		rot = selfT.localRotation;
	}
	
	void OnDisable(){
		selfT.localPosition = pos;
		selfT.localRotation = rot;
	}
}
