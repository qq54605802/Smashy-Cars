using UnityEngine;
using System.Collections;

public class ISSCDBlocksList : MonoBehaviour {

	public ISSCBlock[] blocks;

	static public ISSCDBlocksList LoadList(){
		GameObject obj = Resources.Load("BlocksList", typeof(GameObject)) as GameObject;
		return obj.GetComponent<ISSCDBlocksList> ();
	}
}
