using UnityEngine;
using System.Collections;

public class ISAnimatorBoolTrigger : MonoBehaviour {

	public Animator target;
	public string paraName;
	public bool reverse;

	void OnTriggerEnter(Collider other){
		target.SetBool (paraName, !reverse);
	}

	void OnTriggerExit(Collider other){
		target.SetBool (paraName, reverse);
	}
}
