using UnityEngine;
using System.Collections;

public class ISRandomMatEnable : MonoBehaviour {

	public Material[] mats;

	public MeshRenderer meshRenderer;

	void Awake(){
		if(!meshRenderer)meshRenderer = GetComponent<MeshRenderer> ();
	}

	void OnEnable(){
		meshRenderer.material = mats [Random.Range (0, mats.Length)];
	}
}
