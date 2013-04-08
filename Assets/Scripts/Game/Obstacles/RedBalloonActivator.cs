using UnityEngine;
using System.Collections;

public class RedBalloonActivator : MonoBehaviour {
	
	private RedBalloonAI redBalloonAI;
	
	// Use this for initialization
	void Start () {
		redBalloonAI = transform.parent.Find("RedBalloonSprite").GetComponent<RedBalloonAI>();
		redBalloonAI.enabled = false;
		
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Meteor"){
			redBalloonAI.enabled = true;;
		}
    }
}
