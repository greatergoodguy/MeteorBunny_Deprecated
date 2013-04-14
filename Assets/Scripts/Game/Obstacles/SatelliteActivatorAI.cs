using UnityEngine;
using System.Collections;

public class SatelliteActivatorAI : MonoBehaviour {
	
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
}
