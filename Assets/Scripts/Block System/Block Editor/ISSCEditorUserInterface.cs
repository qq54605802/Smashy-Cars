using UnityEngine;
using System.Collections;

public class ISSCEditorUserInterface : MonoBehaviour {

	public ISSCBEditorCore core;

	public void FillingBlockSelectorValueChange(string newValue){
		Debug.Log (newValue);
		core.currentFillingBlock = int.Parse (newValue);
	}

	public void NewScene(){
		core.NewScene (new ISSCBlockVector (21, 21, 21));
	}
}
