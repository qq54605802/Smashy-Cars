using UnityEngine;
using System.Collections;

public class ISTriggerLoadScene : MonoBehaviour {

	public string targetScene;
	public string onlyWhenTag;

	void OnTriggerEnter(Collider other){
		if (!string.IsNullOrEmpty (onlyWhenTag) && other.gameObject.tag != onlyWhenTag) return;
		Application.LoadLevel (targetScene);
	}
}
