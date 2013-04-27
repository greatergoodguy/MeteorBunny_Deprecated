using UnityEngine;
using System.Collections;

public class GameConstants : MonoBehaviour {
	public bool hasMaxVelocity = false;
	public float maxVelocity = 500;
	
	public float increaseFactor = 1.0f;
	public float horizontalVelocity = 10.0f;
	public float gravityAcceleration = 4.9f;
	
	public void printToConsole(){
		print ("Increase Factor: " + increaseFactor);	
		print ("Horizontal Velocity: " + horizontalVelocity);	
		print ("Gravity: " + gravityAcceleration);	
	}
}

