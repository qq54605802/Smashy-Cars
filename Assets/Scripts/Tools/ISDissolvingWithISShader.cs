using UnityEngine;
using System.Collections;

public class ISDissolvingWithISShader : MonoBehaviour {

	public float speed;
	public float startingValue;
	public MeshRenderer targetRenderer;

	Material mat;
	int pID;
	float curValue;

	void Start () {
		if(!targetRenderer) targetRenderer = GetComponent<MeshRenderer>();
		mat = targetRenderer.material;
		if(!mat) enabled = false;
		pID = Shader.PropertyToID ("_Amount");
		curValue = startingValue;
	}
	
	void OnEnable(){
		curValue = startingValue;
	}

	void Update () {
		if(curValue >= 1f) return;
		curValue += speed * Time.deltaTime;
		mat.SetFloat (pID, curValue);
	}
}
