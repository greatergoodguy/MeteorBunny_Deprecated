using UnityEngine;
using System.Collections;

public class SatelliteActivatorAI : MonoBehaviour, IObstacleAI {
	
	private SatelliteAI satelliteAI;
	
	// Use this for initialization
	void Start () {
		satelliteAI = transform.parent.Find("SatelliteAnim").GetComponent<SatelliteAI>();
		satelliteAI.enabled = false;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Meteor"){
			satelliteAI.enabled = true;;
		}
    }
	
	public void reset(){
		satelliteAI.enabled = false;
	}
}
