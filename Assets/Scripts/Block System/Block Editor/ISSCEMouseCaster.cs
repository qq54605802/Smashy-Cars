using UnityEngine;
using System.Collections;

public class ISSCEMouseCaster : MonoBehaviour {

	public Camera viewingCamera;
	public ISSCBEditorCore core;

	LayerMask maskedLayer;

	void Awake(){
		maskedLayer = 1 << ISSCLayerManager.blockLayer;
	}

	void Update () {
		//core.UpdateBlockForWorldPosition()
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray r = viewingCamera.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(r,out hit, maskedLayer)){
				Debug.Log(hit.point);
				core.UpdateBlockForWorldPosition(hit.point,hit.transform.position);
			}
		}
	}
}
