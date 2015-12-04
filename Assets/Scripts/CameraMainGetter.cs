using UnityEngine;
using System.Collections;

public class CameraMainGetter : MonoBehaviour {

	private static CameraMainGetter cmg;

	void Awake(){
	cmg = this;
	}

	public static Camera GetCam(){
	return cmg.GetComponent<Camera>();
	}
}
