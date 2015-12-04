using UnityEngine;
using System.Collections;

public class ISDestroyTimeUp : MonoBehaviour {

	public float time;

	void OnEnable () {
		StartCoroutine(TimeUp());
	}
	
	IEnumerator TimeUp(){
		yield return new WaitForSeconds(time);
		ISObjectPoolManager.Unspawn(this.gameObject);
	}
}
