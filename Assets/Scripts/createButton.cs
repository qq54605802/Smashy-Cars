using UnityEngine;
using System.Collections;

public class createButton : MonoBehaviour {

public DragMoveType dmt;

bool canMouseDown;
public GameObject prefab;
public float rotateSpeed;
Vector3 defaultScale;
public float ScaleParams;
MouseDragMoveSystem mdms;
Material mt;

void Start(){
if(GetComponent<MeshRenderer>())
mt = GetComponent<MeshRenderer>().material;
canMouseDown = true;
defaultScale = transform.localScale;

}

void Update(){

transform.RotateAround(transform.position,Vector3.up,rotateSpeed*Time.deltaTime);

}

void OnMouseOver(){
transform.localScale = defaultScale*ScaleParams;

}
void OnMouseExit(){
transform.localScale = defaultScale;
}

void OnMouseDown(){
if (!canMouseDown)return;
canMouseDown = false;


		switch (dmt) {
		case DragMoveType.Move:
			GameObject go1 = Instantiate(prefab,transform.position,Quaternion.identity) as GameObject; 
			MeshRenderer[] mrs1  = go1.GetComponentsInChildren<MeshRenderer>();
			for(int i =0 ; i<mrs1.Length;i++){
			mrs1[i].material = mt;
			}
			mdms = go1.GetComponentInChildren<MouseDragMoveSystem>();
			mdms.OnMouseDown();
			break;
		case DragMoveType.Delete:
			GameObject go2 = Instantiate(prefab,transform.position,CameraMainGetter.GetCam().transform.rotation) as GameObject; 
			mdms = go2.GetComponentInChildren<MouseDragMoveSystem>();
			mdms.OnMouseDown();
			break;
		}

}

void OnMouseDrag(){
mdms.OnMouseDrag();
}

void OnMouseUp(){
mdms.OnMouseUp();
canMouseDown = true;
}


}
