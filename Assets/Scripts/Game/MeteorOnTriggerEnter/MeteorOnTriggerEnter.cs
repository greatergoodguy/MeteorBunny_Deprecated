using UnityEngine;
using System.Collections;

public class MeteorOnTriggerEnter : MonoBehaviour {
	
	private MeteorController meteorController;
	
	void Start (){
		GameObject code = GameObject.Find("Code");
		GameCode gameCode = code.GetComponent<GameCode>();
		
		meteorController = gameCode.getMeteorController();
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("OnTriggerEnter");	
		
		if(other.tag == "Cloud"){
			Debug.Log ("Enter Cloud");
			meteorController.resetVerticalVelocity();
		}
    }
}
