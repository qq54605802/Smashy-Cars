using UnityEngine;
using System.Collections;

public enum DragMoveType
{
	Move,
	Delete
}

public class MouseDragMoveSystem : MonoBehaviour
{
	public DragMoveType dmt;
	Vector3 DefaultScale;
	public Camera MainCamera;
	public float cubeYOffset = 0.5f;
	public float cubeXOffset = 0.5f;
	public float cubeZOffset = 0.5f;
	public RaycastHit hitInfo;
	Vector3 RecordHitPoint;
	Offset RecordOffset;
	Collider RecordCollider;
	public GameObject TipsGO;
	GameObject TmpGO;
	public Layers LTag;
	
	void Awake ()
	{
		DefaultScale = transform.parent.localScale;
		RecordOffset = Offset.empty;
	}

	void Start ()
	{
		MainCamera = CameraMainGetter.GetCam ();
		RecordHitPoint = transform.parent.position;

	}

	void Update ()
	{
		switch (dmt) {
		case DragMoveType.Move:
			
			break;
		case DragMoveType.Delete:
			
			break;
		}
	}
	
	void OnMouseOver ()
	{
		switch (dmt) {
		case DragMoveType.Move:
			
			break;
		case DragMoveType.Delete:
			
			break;
		}

	
	}
	
	void OnMouseExit ()
	{
		switch (dmt) {
		case DragMoveType.Move:
			
			break;
		case DragMoveType.Delete:
			
			break;
		}

	
	}
	
	public void OnMouseDown ()
	{
		switch (dmt) {
		case DragMoveType.Move:
		
		
			RecordHitPoint = transform.parent.position;
			ChangeLayer (true);
			transform.parent.localScale = DefaultScale * 0.618f;
			TmpGO = Instantiate (TipsGO, transform.parent.position, Quaternion.identity) as GameObject;
			
			
			
			break;
		case DragMoveType.Delete:
			ChangeLayer (true);
			TmpGO = Instantiate (TipsGO, transform.parent.position, Quaternion.identity) as GameObject;
	
			break;
		}
	}
	
	public void OnMouseDrag ()
	{
		switch (dmt) {
		case DragMoveType.Move:
		
		
			Ray r1 = MainCamera.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (r1, out hitInfo, 1000f, 1 << DesinerController.GetLayer (LTag))) {
				transform.parent.position = hitInfo.point;
				TmpGO.transform.position = CalOffsetForMove (hitInfo.point);
				RecordHitPoint = hitInfo.point;
				if (hitInfo.collider != null) {
					RecordOffset = hitInfo.collider.GetComponent<PlaneParams> ().offset;
				}
			}
			
			
			
			break;
		case DragMoveType.Delete:
		
			Ray r2 = MainCamera.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (r2, out hitInfo, 1000f, 1 << DesinerController.GetLayer (LTag))) {
				transform.parent.position = MainCamera.ScreenToWorldPoint(Input.mousePosition+new Vector3(-5,-4,3));
				
//				RecordHitPoint = hitInfo.point;
				if (hitInfo.collider != null) {
					
					RecordCollider = hitInfo.collider;
					if(RecordCollider.transform.parent!=null){
					TmpGO.transform.position = RecordCollider.transform.parent.position;
					}else {
						TmpGO.transform.position = RecordCollider.transform.position;
					}
//					RecordOffset = hitInfo.collider.GetComponent<PlaneParams> ().offset;
				}
			}
		
			break;
		
		}

	}
	
	public void OnMouseUp ()
	{
		switch (dmt) {
		case DragMoveType.Move:
		
		
			transform.parent.localScale = DefaultScale;
			Destroy (TmpGO);
			transform.parent.position = CalOffsetForMove (RecordHitPoint);
			hitInfo = new RaycastHit ();
			ChangeLayer (false);
			
			
			
			break;
		case DragMoveType.Delete:
			
			if(RecordCollider.transform.parent!=null){
			Destroy(RecordCollider.transform.parent.gameObject);
			}
			Destroy(TmpGO);
			Destroy(transform.parent.gameObject);
			hitInfo = new RaycastHit();
		
			break;
		}
		
		
	}
	
	Vector3 CalOffsetForMove (Vector3 record)
	{
		Vector3 v3 = new Vector3 ();
		switch (RecordOffset) {
		case Offset.XLeft: 
			v3.x = record.x - cubeXOffset;
			v3.y = RoundCalc.RoundDown (record.y) + cubeYOffset;
			v3.z = RoundCalc.RoundDown (record.z) + cubeZOffset;
			break;
		case Offset.XRight: 
			v3.x = record.x + cubeXOffset;
			v3.y = RoundCalc.RoundDown (record.y) + cubeYOffset;
			v3.z = RoundCalc.RoundDown (record.z) + cubeZOffset;
			break;
		case Offset.YUp: 
			v3.x = RoundCalc.RoundDown (record.x) + cubeXOffset;
			v3.y = record.y + cubeYOffset;
			v3.z = RoundCalc.RoundDown (record.z) + cubeZOffset;
			break;
		case Offset.YDown: 
			v3.x = RoundCalc.RoundDown (record.x) + cubeXOffset;
			v3.y = record.y - cubeYOffset;
			v3.z = RoundCalc.RoundDown (record.z) + cubeZOffset;
			break;
		case Offset.ZForward: 
			v3.x = RoundCalc.RoundDown (record.x) + cubeXOffset;
			v3.y = RoundCalc.RoundDown (record.y) + cubeYOffset;
			v3.z = record.z + cubeZOffset;
			break;
		case Offset.ZBack: 
			v3.x = RoundCalc.RoundDown (record.x) + cubeXOffset;
			v3.y = RoundCalc.RoundDown (record.y) + cubeYOffset;
			v3.z = record.z - cubeZOffset;
			break;
		case Offset.empty: 
			v3.x = RoundCalc.RoundDown (record.x) + cubeXOffset;
			v3.y = RoundCalc.RoundDown (record.y) + cubeYOffset;
			v3.z = RoundCalc.RoundDown (record.z) + cubeZOffset;
			break;
		}
	
		return v3;
		
	}
	
	void ChangeLayer (bool b)
	{
		transform.parent.gameObject.layer = LayerInt (b);
		for (int i = 0; i<transform.parent.childCount; i++) {
			transform.parent.GetChild (i).gameObject.layer = LayerInt (b);
		}
	}
	
	int LayerInt (bool b)
	{
		if (b) {
			return DesinerController.GetLayer (LTag) - 1;
		} else {
			return DesinerController.GetLayer (LTag);
		}
	}
}
