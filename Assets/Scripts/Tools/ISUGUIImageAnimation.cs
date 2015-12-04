using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ISUGUIImageAnimation : MonoBehaviour {

	public Sprite[] images;
	public float time;

	Image image;
	int pointer = 0;

	void Start () {
		image = GetComponent<Image> ();
		StartCoroutine (Updateing ());
	}

	IEnumerator Updateing(){
		while (true) {
			image.sprite = images[pointer];
			pointer++;
			if(pointer > images.Length-1) pointer = 0;

			yield return new WaitForSeconds (time);
		}
	}

}
