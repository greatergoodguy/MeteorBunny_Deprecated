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
		
		/*
		if(other.tag == "Cloud"){
			Debug.Log ("Enter Cloud");
			meteorController.resetVerticalVelocity();
		}
		*/
		
		if(other.tag == "Balloon"){
			Debug.Log ("Enter Balloon");
			//meteorController.resetVerticalVelocity();
			
			tk2dAnimatedSprite balloonAnimSprite = other.GetComponent<tk2dAnimatedSprite>();
			balloonAnimSprite.Play();
			
			AudioSource popSFX = other.audio;
			popSFX.Play();
			
		}
    }
}
