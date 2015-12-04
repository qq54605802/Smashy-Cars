using UnityEngine;
using System.Collections;

public class ISExplodion : MonoBehaviour {

	public float explodeRange;
	public float explodePower;
	public LayerMask layerMask;
	public bool atStart;

	void OnEnable () {
		if(atStart) Explode();
	}

	public void Explode(){
		Collider[] cols = Physics.OverlapSphere(transform.position,explodeRange,layerMask);

		foreach(Collider col in cols){
			if(col.GetComponent<Rigidbody>() != null){
				col.GetComponent<Rigidbody>().AddExplosionForce(explodePower,transform.position,explodeRange);
			}
		}
	}
}
