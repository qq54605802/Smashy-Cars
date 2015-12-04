using UnityEngine;
using System.Collections;

public class ISCollisionEventsRedirecter : MonoBehaviour {

	public GameObject target;

	void OnCollisionEnter(Collision other){
		target.SendMessage ("OnCollisionEnter", other, SendMessageOptions.DontRequireReceiver);
	}
}
