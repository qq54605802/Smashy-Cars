using UnityEngine;
using System.Collections;

public class ISSCBEditorCore : MonoBehaviour {

	public ISSCECamera editorCamera;
	public ISSCBGrid data;
	public ISSCBGridController moniter;
	public ISSCEditorUserInterface view;
	public int rootBlock;
	public int currentFillingBlock;


	ISSCEMouseCaster caster;

	void Start(){
		caster = GetComponent<ISSCEMouseCaster> ();
		caster.core = this;
	}

	public void NewScene(ISSCBlockVector size){
		data = new ISSCBGrid (size);
		data.SetBlock (data.GetCenterBlock (), rootBlock);
		Debug.Log("New Scene Created");
		editorCamera.SetViewPoint (ISSCBGrid.GridPositionToWorldPosition(data.GetCenterBlock (), moniter.transform.position));
		moniter.SwitchData (data);
	}

	public void OpenDataSet(ISSCBGrid newDataSet){
		data = newDataSet;
		editorCamera.SetViewPoint (ISSCBGrid.GridPositionToWorldPosition(data.GetCenterBlock (), moniter.transform.position));
		moniter.SwitchData (data);
	}

	public void UpdateBlockForWorldPosition(Vector3 hitPoint, Vector3 hittedBlockPosition){
		Vector3 dir = hitPoint - hittedBlockPosition;
		Debug.Log (dir);
		dir = ISMath.Clip2NormalDirection (dir);
		Debug.Log (dir);
		ISSCBlockVector bv = ISSCBGrid.WorldPositionToGridPosition (hittedBlockPosition + dir.normalized,moniter.transform.position);
		//bv = data.ClosestEmptyBlock (bv);

		data.SetBlock(bv, currentFillingBlock);
	}

}
