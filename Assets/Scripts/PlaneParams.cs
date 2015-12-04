using UnityEngine;
using System.Collections;

public class PlaneParams : MonoBehaviour {

	public Offset offset;
	public float colorR;
	public float colorG;
	public float colorB;
	public float colorA;
	
	MeshRenderer mr;
	
	public void myParams(){
		mr = GetComponent<MeshRenderer>();
		colorR = mr.material.color.r;
		colorG = mr.material.color.g;
		colorB = mr.material.color.b;
		colorA = mr.material.color.a;
	}
}
