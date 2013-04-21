using UnityEngine;
using System.Collections;

public class UfoActivatorAI : MonoBehaviour, IObstacleAI {
	
	private UfoAI ufoAI;
	
	// Use this for initialization
	void Start () {
		ufoAI = transform.parent.Find("UfoAnim").GetComponent<UfoAI>();
		ufoAI.enabled = false;
		
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Meteor"){
			ufoAI.enabled = true;;
		}
    }
	
	public void reset(){
		ufoAI.enabled = false;
	}
}
