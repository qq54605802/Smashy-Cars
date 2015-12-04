using UnityEngine;
using System.Collections;

public class ISMaxFPSSetter : MonoBehaviour {

	static public void SetMaxFPSRate(int rate){
		Application.targetFrameRate = rate;
	}

	public int maxFPS = 60; 
	
	void Start () {
		Application.targetFrameRate = maxFPS;
	}
}
