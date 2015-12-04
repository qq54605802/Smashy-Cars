using UnityEngine;
using System.Collections;

public class ISTimeScaleSetter : MonoBehaviour {

	public float timeScale;

	void Start () {
		Time.timeScale = timeScale;
	}
}
