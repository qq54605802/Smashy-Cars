using UnityEngine;
using System.Collections;

public class PingPongShaderFloat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
		float shininess = Mathf.PingPong(Time.time*0.5f, 1.0F);

		GetComponent<Renderer>().material.SetFloat("_Amount", shininess);
	}
}
