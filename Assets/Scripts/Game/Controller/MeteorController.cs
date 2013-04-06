/**
 * This script is to provide control for the meteor (or other falling object).
 * It implements IBBCamera so that it may be the target of a BBCamera script.
 * 
 * @author Taylor McKinney, Bursting Brains
 */

using UnityEngine; 
using System;

public class MeteorController {
	
	private const float MAX_VERTICAL_VELOCITY = 10.0f;
	private const float GRAVITY_ACCELERATION = 9.8f / 2;
	
	private float horizontalVelocity = 10.0f;
	
	private float verticalVelocity = 0;
	
	private GameObject planet;
	private GameObject meteor;
	private IInput input;
	
	private CharacterController characterController;
	
	public MeteorController(GameObject meteor, GameObject planet, IInput input){
		this.planet = planet;
		this.meteor = meteor;
		this.input = input;
		
		this.characterController = meteor.GetComponent<CharacterController>();
	}
			
	public void ApplyController() {
		float horAxis = input.getHorizontalAxis();
		float horDistance = horAxis * horizontalVelocity * Time.deltaTime;
		characterController.Move(new Vector3(horDistance, 0, 0));
	}
		
	public void ApplyGravity() {
		verticalVelocity = verticalVelocity + GRAVITY_ACCELERATION * Time.deltaTime;
		verticalVelocity = Math.Min(verticalVelocity, MAX_VERTICAL_VELOCITY);
		
		float fallDistance = verticalVelocity * Time.deltaTime + (1 / 2.0f) * GRAVITY_ACCELERATION * Time.deltaTime * Time.deltaTime;
		characterController.Move(new Vector3(0, -fallDistance, 0));
	}
	
	public void resetVerticalVelocity() {
		verticalVelocity = 0;
	}
	
	public bool isGroundLevel(){
		if(meteor.transform.position.y < planet.transform.position.y)
			return true;
		
		return false;
	}
}
