using UnityEngine;
using System.Collections;

public class ISWaypointManager : MonoBehaviour {

	public Transform[] waypoints;

	static private ISWaypointManager self;

	void Awake(){
		self = this;
	}

	static public Transform getRandomWaypoint(){
		return self.waypoints [Random.Range (0, self.waypoints.Length)];
	}
}
