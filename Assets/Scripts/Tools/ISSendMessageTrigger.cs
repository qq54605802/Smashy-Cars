using UnityEngine;
using System.Collections;

public class ISSendMessageTrigger : MonoBehaviour {

	public string message;
	public GameObject target;
	public bool once;

	void OnTriggerEnter(Collider other){
		target.SendMessage (message, SendMessageOptions.DontRequireReceiver);
		if (once) {
			gameObject.SetActive(false);
		}
	}
}
