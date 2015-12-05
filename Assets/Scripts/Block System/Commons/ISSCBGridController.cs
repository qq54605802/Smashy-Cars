using UnityEngine;
using System.Collections;

public class ISSCBGridController : MonoBehaviour
{

	public ISSCBGridDescriber grid;

	ISSCBGrid gridData;
	int currentVersion = 0;

	ISSCDBlocksList blockList;
	GameObject[] blockObjects;

	void Start ()
	{
		blockList = ISSCDBlocksList.LoadList ();
		gridData = new ISSCBGrid (grid);

		int length = gridData.gridSize.Length ();
		blockObjects = new GameObject[length];
		
//		ApplyDataToScene();
		//test ();
	}

	public Vector3 BlockToWorldPosition ()
	{
		return Vector3.zero;
	}

	void Update(){
		UpdateSceneWithData ();
			testSetRandomBlock ();
	}

	void UpdateSceneWithData ()
	{
		int versionCheckResult = gridData.IsLastestVersion (currentVersion);
		if(versionCheckResult == -1) return;

		Debug.Log("New version detected, updating " + (versionCheckResult - currentVersion).ToString() + " changes...");

		int[] data = gridData.GetRawData ();

		for (int i = 0; i < data.Length; i++) {
			ISSCBlockVector b = gridData.DecodeIndex(i);
			if(data[i] <= 1) continue;
			if(!gridData.IsBlockVisiable(b)) continue;

			if (blockObjects [i]) {
				ISObjectPoolManager.Unspawn (blockObjects [i]);
			}

			Vector3 position = ISSCBGrid.GridPositionToWorldPosition (b, transform.position);
			blockObjects [i] = ISObjectPoolManager.Spawn (blockList.blocks [data [i]].gameObject, position, Quaternion.identity) as GameObject;
		}

		currentVersion = versionCheckResult;
	}
	
	public void test ()
	{
	
		ISSCBlockVector[] bvs = gridData.BlocksInRange (gridData.GetCenterBlock (), 10);
		foreach (ISSCBlockVector bv in bvs) {
			gridData.SetBlock (bv, Random.Range(2,6));
		}
		//StartCoroutine (ApplyDataToScene ());
	}

	public void testSetRandomBlock(){
		gridData.SetBlock (new ISSCBlockVector (Random.Range (0, 20), Random.Range (0, 20), Random.Range (0, 20)), Random.Range (0, 6));
	}
	
}
