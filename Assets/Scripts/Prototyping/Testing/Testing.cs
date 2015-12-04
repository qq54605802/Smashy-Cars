using UnityEngine;
using System.Collections;

public class Testing : MonoBehaviour {

	public int testNumber;

	void Start () {
		ISSCBGrid grid = new ISSCBGrid (new ISSCBlockVector(10,10,10));



		for (int i = 0; i < testNumber; i++) {

			ISSCBlockVector pos = new ISSCBlockVector(Random.Range(0,9),Random.Range(0,9),Random.Range(0,9));
			int number2Set = Random.Range(0,10000);
			grid.SetBlock(pos,number2Set);
			if(grid.GetBlock(pos) == number2Set){
				Debug.Log("Test " + i.ToString() + "Passed !");
			}else{
				Debug.LogWarning("Test " + i.ToString() + "Failed...");
			}
		}

	}
}
