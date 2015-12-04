using UnityEngine;
using System.Collections;

public class ISShakeWithiTween : MonoBehaviour {

	public Vector3 powerOfShake;
	public float time;
	
	void Start () {
		iTween.ShakeRotation (gameObject, powerOfShake, time);
	}
}
