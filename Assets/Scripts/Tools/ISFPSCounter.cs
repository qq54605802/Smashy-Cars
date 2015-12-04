using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ISFPSCounter : MonoBehaviour {

	public string prefix = "FPS : ";
	public float updateRate = 0.1f;
	public Text label;

	void Start () {
		StartCoroutine(UpdateM());
	}

	IEnumerator UpdateM(){
		while(true){
			label.text = prefix+(1/Time.deltaTime).ToString();
			yield return new WaitForSeconds(updateRate);
		}
	}
}
