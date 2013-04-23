using UnityEngine;
using System.Collections;

public class UfoAI : MonoBehaviour, IObstacleAI {

	public float floatRate = 1.0f;
	public float subtractVelocity = 2.0f;
	
	private MeteorController meteorController;
	
	private Vector3 startPos;
	
	void Start () {
		GameObject code = GameObject.Find("Code");
		GameCode gameCode = code.GetComponent<GameCode>();
		
		meteorController = gameCode.getMeteorController();
		
		startPos = transform.localPosition;
	}
	
	void Update () {
		const float MOVEMENT_MULTIPLIER = 70f;
		Vector3 movement = new Vector3 (-floatRate, 0, 0) * Time.deltaTime * MOVEMENT_MULTIPLIER;
		
		transform.position += movement;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Meteor"){
			meteorController.decreaseVerticalVelocity(subtractVelocity);
		}
    }
	
	public void reset(){
		transform.localPosition = startPos;
	}
}
