using UnityEngine;
using System.Collections;

public class CubeParams : MonoBehaviour {
public float PositionX;
public float PositionY;
public float PositionZ;

public PlaneParams[] pp;

public void refreshParams(){
myParams();
childsParams();
}

public void myParams(){
PositionX = transform.position.x;
PositionY = transform.position.y;
PositionZ = transform.position.z;
}

public void childsParams(){
pp = GetComponentsInChildren<PlaneParams>();
foreach(PlaneParams i in pp){
i.myParams();
}
}

}
