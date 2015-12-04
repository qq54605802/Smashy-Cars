using UnityEngine;
using System.Collections;

public class RoundCalc : MonoBehaviour
{

	static public float RoundDown (float f)
	{
		if (f % 1f == 0f) {
			return f;
		} else if (f >= 0f) {
			f = (float)((int)f);
		} else if (f < 0f) {
			f -= 1f;
			f = (float)((int)f);
		}


		return f;
	}
}
