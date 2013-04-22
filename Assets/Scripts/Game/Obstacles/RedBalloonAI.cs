using UnityEngine;
using System.Collections;

public class RedBalloonAI : MonoBehaviour, IObstacleAI {
	
	public float floatRate = 1.0f;
	public float subtractVelocity = 2.0f;
	
	private MeteorController meteorController;
	private tk2dAnimatedSprite balloonAnimSprite;
	
	private Vector3 startPos;
	
	void Start () {
		GameObject code = GameObject.Find("Code");
		GameCode gameCode = code.GetComponent<GameCode>();
		
		meteorController = gameCode.getMeteorController();
		balloonAnimSprite = GetComponent<tk2dAnimatedSprite>();
		
		startPos = transform.localPosition;
	}
	
	void Update () {
		Vector3 movement = new Vector3 (0, floatRate, 0) * Time.deltaTime;
		transform.position += movement;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Meteor"){
			meteorController.decreaseVerticalVelocity(subtractVelocity);
			balloonAnimSprite.Play();
			audio.Play();
		}
    }
	
	public void reset(){
		balloonAnimSprite.StopAndResetFrame();
		transform.localPosition = startPos;
	}
}
