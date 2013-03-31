/**
 * This script is to provide control for the meteor (or other falling object).
 * It implements IBBCamera so that it may be the target of a BBCamera script.
 * 
 * @author Taylor McKinney, Bursting Brains
 */

using UnityEngine; 
using System;

public class MeteorController {

	public float horizontalVelocity = 10.0f;
	
	private float accel = 9.8f;
	private float verticalVelocity = 0;
	
	private GameObject planet;
	private GameObject meteor;
	
	private CharacterController characterController;
	
	public MeteorController(GameObject meteor, GameObject planet){
		this.planet = planet;
		this.meteor = meteor;
		
		this.characterController = meteor.GetComponent<CharacterController>();
	}
			
	public void ApplyController() {
		float horAxis = Input.GetAxis("Horizontal");
		float horDistance = horAxis * horizontalVelocity * Time.deltaTime;
		characterController.Move(new Vector3(horDistance, 0, 0));
	}
		
	public void ApplyGravity() {
		verticalVelocity = verticalVelocity + accel * Time.deltaTime;
		float fallDistance = verticalVelocity * Time.deltaTime + (1 / 2.0f) * accel * Time.deltaTime * Time.deltaTime;
		characterController.Move(new Vector3(0, -fallDistance, 0));
	}
	
	public bool isGroundLevel(){
		if(meteor.transform.position.y < planet.transform.position.y)
			return true;
		
		return false;
	}
}
