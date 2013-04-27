using UnityEngine;
using System.Collections;

public class CloudBaseAI : MonoBehaviour, IObstacleAI {
	public float subtractVelocity = 3.0f;
	
	private MeteorController meteorController;
	
	void Start (){
		GameObject code = GameObject.Find("Code");
		GameCode gameCode = code.GetComponent<GameCode>();
		
		meteorController = gameCode.getMeteorController();
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Meteor"){
			meteorController.decreaseVerticalVelocity(subtractVelocity);
		}
    }
	
	public void reset(){}
}
