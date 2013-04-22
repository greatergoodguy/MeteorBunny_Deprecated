/**
 * This script is to provide control for the meteor (or other falling object).
 * It implements IBBCamera so that it may be the target of a BBCamera script.
 * 
 * @author Taylor McKinney, Bursting Brains
 */

using UnityEngine; 
using System;

public class MeteorController {
	private Vector3 meteorStartPos;
	
	private float FINAL_MAX_VERTICAL_VELOCITY;
	private float INITIAL_MAX_VERTICAL_VELOCITY;
	private float INCREASE_FACTOR;
	private float GRAVITY_ACCEL;
	
	private float maxVerticalVelocity;
	private float horizontalVelocity;
	private float verticalVelocity;
	
	private GameObject planet;
	private GameObject meteor;
	private IInput input;
	
	private CharacterController characterController;
	private AudioSource fallingSound;
	
	public MeteorController(GameObject meteor, IInput input, GameConstants gameConstants){
		this.planet = planet;
		this.meteor = meteor;
		this.input = input;
		
		this.characterController = meteor.GetComponent<CharacterController>();
		this.fallingSound = meteor.audio;
		
		meteorStartPos = meteor.transform.position;
		
		FINAL_MAX_VERTICAL_VELOCITY		= gameConstants.finalMaxVerticalVelocity;
		INITIAL_MAX_VERTICAL_VELOCITY 	= gameConstants.initialMaxVerticalVelocity;
		INCREASE_FACTOR 				= gameConstants.increaseFactor;
		maxVerticalVelocity				= INITIAL_MAX_VERTICAL_VELOCITY;
		GRAVITY_ACCEL 					= gameConstants.gravityAcceleration;
		horizontalVelocity 				= gameConstants.horizontalVelocity;
		verticalVelocity 				= 0;
		
		DebugUtils.Assert(INITIAL_MAX_VERTICAL_VELOCITY != 0);
		DebugUtils.Assert(maxVerticalVelocity != 0);
		DebugUtils.Assert(GRAVITY_ACCEL != 0);
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
		verticalVelocity = verticalVelocity + GRAVITY_ACCEL * Time.deltaTime;
		verticalVelocity = Math.Min(verticalVelocity, maxVerticalVelocity);
		
		float fallDistance = verticalVelocity * Time.deltaTime + (1 / 2.0f) * GRAVITY_ACCEL * Time.deltaTime * Time.deltaTime;
		characterController.Move(new Vector3(0, -fallDistance, 0));
		
		if(verticalVelocity >= maxVerticalVelocity){
		
			if(maxVerticalVelocity < FINAL_MAX_VERTICAL_VELOCITY)
				maxVerticalVelocity += Time.deltaTime * INCREASE_FACTOR;
		}
	}
	
	public void resetVerticalVelocity() {
		verticalVelocity = 0;
	}
	
	public void decreaseVerticalVelocity() {
		float DEFAULT_DECREASE_AMOUNT = -3;
		decreaseVerticalVelocity(DEFAULT_DECREASE_AMOUNT);
	}
	
	public void decreaseVerticalVelocity(float decreaseAmount) {
		if(isAtMaxVelocity())
			maxVerticalVelocity -= decreaseAmount;
			
		verticalVelocity -= decreaseAmount;
		
		
		if(maxVerticalVelocity < INITIAL_MAX_VERTICAL_VELOCITY)
			maxVerticalVelocity = INITIAL_MAX_VERTICAL_VELOCITY;
		
		if(maxVerticalVelocity > FINAL_MAX_VERTICAL_VELOCITY)
			maxVerticalVelocity = FINAL_MAX_VERTICAL_VELOCITY;
		
		if(verticalVelocity < 0)
			verticalVelocity = 0;
	}
	
	public float getVerticalVelocity(){
		return verticalVelocity;
	}
	
	public void reset(){
		resetVerticalVelocity();
		meteor.transform.position = meteorStartPos;
	}
	
	private bool isAtMaxVelocity(){
		float FAULT_TOLERANCE = 0.7f;
		if(verticalVelocity >= maxVerticalVelocity - FAULT_TOLERANCE)
			return true;
		
		return false;
	}
}
