using UnityEngine;
using System;

public class CameraController : MonoBehaviour {
	// Public variables.  These will be visible and editable from the Unity GUI.
	public float xOffset = 10.0f;
	public float yOffset = 0.5f;
	public float zOffset = 20.0f;
	public float transitionSpeed = 4.0f;
	public float transitionAcceleration = 0.5f;
	public float MaximumFallLead = 5.0f;
	
	public IBBCameraTarget target;
	
	private Vector3 targetOffset;
	
	/**
	 * Sets <code>targetPosition</code> to the desired value.
	 * <p>
	 * Will set the <code>targetPosition</code> either left or right of the target <code>character</code>
	 * based on <code>controller.GetDirection()</code>.
	 */
	private Vector3 GetTargetPosition () {
		Vector3 targetPosition = target.getPosition () + targetOffset;
		targetPosition.x *= target.getVelocity ().x;
		return targetPosition;
	}
	
	/**
	 * Moves this camera towards the destination by a certain distance.
	 * <p>
	 * Moves smoothly towards position.  Moves quickly when far away from the target position,
	 * and slows down as it gets closer.
	 * <p>
	 * Based on the target's movement, will move side to side when the player is moving, and
	 * will center out as they hold still
	 */
	private void Move () {
		// Total distance to move along all axises
		// Vector3 movementToTarget = GetTargetPosition() - transform.position;
		
		// Move towards the target, limited by deltaTime and the transitionSpeed
		// Vector3 movementVelocity = transitionSpeed * Time.deltaTime * movementToTarget;
		
		// Adjust for player movement
		// movementVelocity += Time.deltaTime * target.getVelocity ();
		
		// This line moves the camera more based on how far the camera is from the target position
		// movementVelocity += Time.deltaTime * Time.deltaTime * transitionAcceleration * movementToTarget;

    // Vector3 finalPosition = transform.position + movementVelocity;
	
		// Actually applies the movement
    // transform.position = finalPosition;

    transform.position = GetTargetPosition();

	}
	
	/**
	 * Start up the camera
	 * If a target isn't given, we just assume it's the meteor
	 */
	void Start () {
		if (target == null) {
			target = (IBBCameraTarget) GameObject.Find("Meteor").GetComponent("MeteorController");
		}
		targetOffset = new Vector3(xOffset, yOffset, -1 * zOffset);
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}
}
