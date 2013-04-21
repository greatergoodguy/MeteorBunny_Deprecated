using UnityEngine;
using System.Collections;

public class SatelliteAI : MonoBehaviour, IObstacleAI {
	public float floatRate = 1.0f;
	public float subtractVelocity = 2.0f;
	
	private MeteorController meteorController;
	
	void Start () {
		GameObject code = GameObject.Find("Code");
		GameCode gameCode = code.GetComponent<GameCode>();
		
		meteorController = gameCode.getMeteorController();
	}
	
	void Update () {
		Vector3 movement = new Vector3 (floatRate, 0, 0) * Time.deltaTime;
		transform.position += movement;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Meteor"){
			meteorController.decreaseVerticalVelocity(subtractVelocity);
		}
    }
	
	public void reset(){}
}
