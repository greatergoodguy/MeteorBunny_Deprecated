using UnityEngine;
using System.Collections;

public class GameConstants : MonoBehaviour {
	public float finalMaxVerticalVelocity = 30.0f;
	public float initialMaxVerticalVelocity = 10.0f;
	
	public float increaseFactor = 1.0f;
	
	public float horizontalVelocity = 10.0f;
	public float gravityAcceleration = 4.9f;
	
	public void printToConsole(){
		print ("Final Max Vertical Velocity: " + finalMaxVerticalVelocity);	
		print ("Initial Max Vertical Velocity: " + initialMaxVerticalVelocity);	
		print ("Increase Factor: " + increaseFactor);	
		print ("Horizontal Velocity: " + horizontalVelocity);	
		print ("Gravity: " + gravityAcceleration);	
	}
}

