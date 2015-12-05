using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {

	public int testNumber;

	void Start () {
		ISSCBGrid grid = new ISSCBGrid (new ISSCBlockVector(10,10,10));


		/*
		for (int i = 0; i < testNumber; i++) {

			ISSCBlockVector pos = new ISSCBlockVector(Random.Range(0,9),Random.Range(0,9),Random.Range(0,9));
			int id = grid.EncodeIndex(pos);
			if(grid.DecodeIndex(id).x == pos.x && grid.DecodeIndex(id).y == pos.y && grid.DecodeIndex(id).z == pos.z){
				Debug.Log("Test " + i.ToString() + "Passed !");
			}else{
//				Debug.LogError("Test " + i.ToString() + "Failed..." + pos.x.ToString() + pos.y.ToString() + pos.z.ToString() + " " + grid.DecodeIndex(id).x.ToString() + grid.DecodeIndex(id).y.ToString() + grid.DecodeIndex(id).z.ToString());
				Debug.Log(pos.x + " " + grid.DecodeIndex(id).x);
				
			}
		}
		*/
	}
}
