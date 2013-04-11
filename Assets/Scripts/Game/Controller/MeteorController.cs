/**
 * This script is to provide control for the meteor (or other falling object).
 * It implements IBBCamera so that it may be the target of a BBCamera script.
 * 
 * @author Taylor McKinney, Bursting Brains
 */

using UnityEngine; 
using System;

public class MeteorController {
	private float FINAL_MAX_VERTICAL_VELOCITY;
	private float INITIAL_MAX_VERTICAL_VELOCITY;
	
	private float maxVerticalVelocity;
	private float gravityAccel;
	private float horizontalVelocity;
	private float verticalVelocity;
	
	private GameObject planet;
	private GameObject meteor;
	private IInput input;
	
	private CharacterController characterController;
	private AudioSource fallingSound;
	
	public MeteorController(GameObject meteor, GameObject planet, IInput input, GameConstants gameConstants){
		this.planet = planet;
		this.meteor = meteor;
		this.input = input;
		
		this.characterController = meteor.GetComponent<CharacterController>();
		this.fallingSound = meteor.audio;
		
		FINAL_MAX_VERTICAL_VELOCITY		= gameConstants.finalMaxVerticalVelocity;
		INITIAL_MAX_VERTICAL_VELOCITY 	= gameConstants.initialMaxVerticalVelocity;
		maxVerticalVelocity				= INITIAL_MAX_VERTICAL_VELOCITY;
		gravityAccel 					= gameConstants.gravityAcceleration;
		horizontalVelocity 				= gameConstants.horizontalVelocity;
		verticalVelocity 				= 0;
		
		DebugUtils.Assert(INITIAL_MAX_VERTICAL_VELOCITY != 0);
		DebugUtils.Assert(maxVerticalVelocity != 0);
		DebugUtils.Assert(gravityAccel != 0);
		DebugUtils.Assert(horizontalVelocity != 0);
		
		DebugUtils.Assert(verticalVelocity == 0);
	}
			
	public void ApplyController() {
		const float SCALE_FACTOR = (1 / 5.0f); 
		const float MIN_PITCH = 0.4f;
		const float MAX_PITCH = 2.0f;
		
		float horAxis = input.getHorizontalAxis();
		float horDistance = horAxis * horizontalVelocity * Time.deltaTime;
		characterController.Move(new Vector3(horDistance, 0, 0));
		
		/*
		 * 	Code regarding sound. This will be 
		 * 	refactored if the sound logic gets more complicated.
		 */ 
		fallingSound.pitch += horDistance * SCALE_FACTOR;
		if(fallingSound.pitch > MAX_PITCH){
			fallingSound.pitch = MAX_PITCH;
		}
		else if(fallingSound.pitch < MIN_PITCH){
			fallingSound.pitch = MIN_PITCH;
		}
		// =========================
	}
		
	public void ApplyGravity() {
		verticalVelocity = verticalVelocity + gravityAccel * Time.deltaTime;
		verticalVelocity = Math.Min(verticalVelocity, maxVerticalVelocity);
		
		float fallDistance = verticalVelocity * Time.deltaTime + (1 / 2.0f) * gravityAccel * Time.deltaTime * Time.deltaTime;
		characterController.Move(new Vector3(0, -fallDistance, 0));
		
		if(maxVerticalVelocity < FINAL_MAX_VERTICAL_VELOCITY)
			maxVerticalVelocity += Time.deltaTime;
	}
	
	public void resetVerticalVelocity() {
		verticalVelocity = 0;
	}
	
	public void decreaseMaxVerticalVelocity() {
		maxVerticalVelocity -= 5;
		if(maxVerticalVelocity < INITIAL_MAX_VERTICAL_VELOCITY)
			maxVerticalVelocity = INITIAL_MAX_VERTICAL_VELOCITY;
	}
	
	public bool isGroundLevel(){
		if(meteor.transform.position.y < planet.transform.position.y)
			return true;
		
		return false;
	}
	
	public float getVerticalVelocity(){
		return verticalVelocity;
	}
}
