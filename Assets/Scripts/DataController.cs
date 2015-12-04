using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class DataController : MonoBehaviour
{
	private static DataController instant;
	
	void Awake(){
	instant = this;
	}
	
	public static DataController get(){
	if(instant == null){
	instant = GameObject.FindObjectOfType<DataController>() as DataController;
	if(instant == null){
	GameObject container = new GameObject();
	container.name = "DataController";
	instant = container.AddComponent<DataController>() as DataController;
	}
	}
	return instant;
	}
	
	// Use this for initialization
	void Start ()
	{
		
		
		

		
		
		
	}
	
	
	// Update is called once per frame
	void Update ()
	{
	
	}


}


