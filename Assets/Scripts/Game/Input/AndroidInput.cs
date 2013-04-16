using UnityEngine;
using System.Collections;

public class AndroidInput : IInput {
	private const float TILT_LEFT_BOUND = -1;
	private const float TILT_RIGHT_BOUND = 1;
	
	/*
	 * A tilt factor of 1 means that there is 180 degrees freedom tilt.
	 * Horizontal Orientation is the default orientation and can be tilted
	 * 90 degrees left or right
	 * 
	 * Increasing the tilt factor will decrease the size of the angle of freedom.
	 * For example, a tilt factor of 2 will cause the angle of freedom to be from
	 * -50 to 50.
	 */
	private const float TILT_FACTOR = 1; 
	
	public float getHorizontalAxis(){
		
		Vector3 accel = Input.acceleration;
		float horAxis = accel.x * TILT_FACTOR;
		
		Debug.Log ("accel.x: " + accel.x);
		Debug.Log ("2x accel.x: " + accel.x * 2);
		
		if(horAxis < TILT_LEFT_BOUND)
			horAxis = TILT_LEFT_BOUND;
		else if(horAxis > TILT_LEFT_BOUND)
			horAxis = TILT_RIGHT_BOUND;
		
		//return horAxis;
		return accel.x;
	}
	
	public bool isBackButtonDown(){
		if (Input.GetKey(KeyCode.Escape)){
        	return true;
    	}
		
		return false;
	}
}
