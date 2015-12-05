using UnityEngine;
using System.Collections;

public class ISSCBGridController : MonoBehaviour
{


	public ISSCBGridDescriber grid;
	ISSCBGrid gridData;
	ISSCDBlocksList blockList;
	GameObject[] blockObjects;

	void Start ()
	{
		blockList = ISSCDBlocksList.LoadList ();
		gridData = new ISSCBGrid (grid);

		blockObjects = new GameObject[gridData.gridSize.Length ()];
		
//		ApplyDataToScene();
		test ();
	}

	public Vector3 BlockToWorldPosition ()
	{
		return Vector3.zero;
	}

	IEnumerator ApplyDataToScene ()
	{
		int[] data = gridData.GetRawData ();

		for (int i = 0; i < data.Length; i++) {
			ISSCBlockVector b = gridData.DecodeIndex(i);
			if(data[i] <= 1) continue;
			if(!gridData.IsBlockVisiable(b)) continue;

			if (blockObjects [i]) {
				ISObjectPoolManager.Unspawn (blockObjects [i]);
			}

			blockObjects [i] = ISObjectPoolManager.Spawn (blockList.blocks [data [i]].gameObject, ISSCBGrid.GridPositionToWorldPosition (b, transform.position), Quaternion.identity) as GameObject;
			yield return null;
		}
	}
	
	public void test ()
	{
	
		ISSCBlockVector[] bvs = gridData.BlocksInRange (gridData.GetCenterBlock (), 10);
		foreach (ISSCBlockVector bv in bvs) {
			gridData.SetBlock (bv, Random.Range(2,6));
		}
		StartCoroutine (ApplyDataToScene ());
	}
	
	
}
