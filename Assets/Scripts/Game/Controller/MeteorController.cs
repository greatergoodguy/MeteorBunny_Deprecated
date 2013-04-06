/**
 * This script is to provide control for the meteor (or other falling object).
 * It implements IBBCamera so that it may be the target of a BBCamera script.
 * 
 * @author Taylor McKinney, Bursting Brains
 */

using UnityEngine; 
using System;

public class MeteorController {
	
	private float maxInitialVerticalVelocity;
	private float gravityAccel;
	private float horizontalVelocity;
	
	private float verticalVelocity = 0;
	
	private GameObject planet;
	private GameObject meteor;
	private IInput input;
	
	private CharacterController characterController;
	
	public MeteorController(GameObject meteor, GameObject planet, IInput input, GameConstants gameConstants){
		this.planet = planet;
		this.meteor = meteor;
		this.input = input;
		
		this.characterController = meteor.GetComponent<CharacterController>();
		
		maxInitialVerticalVelocity 	= gameConstants.maxInitialVerticalVelocity;
		gravityAccel 				= gameConstants.gravityAcceleration;
		horizontalVelocity 			= gameConstants.horizontalVelocity;
		
		DebugUtils.Assert(maxInitialVerticalVelocity != 0);
		DebugUtils.Assert(gravityAccel != 0);
		DebugUtils.Assert(horizontalVelocity != 0);
	}
			
	public void ApplyController() {
		float horAxis = input.getHorizontalAxis();
		float horDistance = horAxis * horizontalVelocity * Time.deltaTime;
		characterController.Move(new Vector3(horDistance, 0, 0));
	}
		
	public void ApplyGravity() {
		verticalVelocity = verticalVelocity + gravityAccel * Time.deltaTime;
		verticalVelocity = Math.Min(verticalVelocity, maxInitialVerticalVelocity);
		
		float fallDistance = verticalVelocity * Time.deltaTime + (1 / 2.0f) * gravityAccel * Time.deltaTime * Time.deltaTime;
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
