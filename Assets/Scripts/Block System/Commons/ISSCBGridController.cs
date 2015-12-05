using UnityEngine;
using System.Collections;

public class ISSCBGridController : MonoBehaviour {

	public const float ISSC_BLOCK_UNIT_SIZE = 1;

	public ISSCBGridDescriber grid;

	ISSCBGrid gridData;
	ISSCDBlocksList blockList;

	GameObject[] blockObjects;

	void Start(){
		blockList = ISSCDBlocksList.LoadList ();
		gridData = new ISSCBGrid (grid);

		blockObjects = new GameObject[gridData.gridSize.Length ()];
	}

	public Vector3 BlockToWorldPosition(){
		return Vector3.zero;
	}

	public void ApplyDataToScene(){
		int[] data = gridData.GetRawData ();

		for (int i = 0; i < data.Length; i++) {
			if(blockObjects[i]){
				ISObjectPoolManager.Unspawn(blockObjects[i]);
			}

			//blockObjects[i] = ISObjectPoolManager.Spawn(blockList.blocks[data[i]], ,Quaternion.identity) as GameObject;
		}
	}
}
