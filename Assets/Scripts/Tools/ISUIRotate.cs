using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ISUIRotate : MonoBehaviour {

	public Vector3 direction;

	RectTransform selfRT;

	void Start () {
		selfRT = GetComponent<RectTransform> ();
	}

	void Update () {
		selfRT.Rotate (direction * Time.unscaledDeltaTime);
	}
}
