using UnityEngine;
using System.Collections;

public class CloudAI : MonoBehaviour {
	private MeteorController meteorController;
	
	void Start (){
		GameObject code = GameObject.Find("Code");
		GameCode gameCode = code.GetComponent<GameCode>();
		
		meteorController = gameCode.getMeteorController();
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Meteor"){
			meteorController.resetVerticalVelocity();
		}
    }
}
