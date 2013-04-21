using UnityEngine;
using System.Collections;

public class RedBalloonActivator : MonoBehaviour, IObstacleAI {
	
	private RedBalloonAI redBalloonAI;
	
	// Use this for initialization
	void Start () {
		redBalloonAI = transform.parent.Find("RedBalloonSprite").GetComponent<RedBalloonAI>();
		redBalloonAI.enabled = false;
		
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Meteor"){
			redBalloonAI.enabled = true;
		}
    }
	
	public void reset(){
		redBalloonAI.enabled = false;
	}
}
