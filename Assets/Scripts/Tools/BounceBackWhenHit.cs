using UnityEngine;
using System.Collections;

public class BounceBackWhenHit : MonoBehaviour {

	public float forceFactor;

	void OnCollisionEnter(Collision other){
		Rigidbody r = other.gameObject.GetComponent<Rigidbody> ();
		if (r) {

			r.AddForce ((other.impulse / Time.fixedDeltaTime) * forceFactor);
		}
	}

}
