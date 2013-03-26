using UnityEngine;
using System.Collections;

public interface IBBCameraTarget {
	// Velocity
	Vector3 getVelocity();
	
	// Position
	Vector3 getPosition();
}
