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
	private float anchorX;
	
	/**
	 * Start up the camera
	 * If a target isn't given, we just assume it's the meteor
	 */
	void Start () {
		if (target == null) {
			target = (IBBCameraTarget) GameObject.Find("Meteor").GetComponent("MeteorController");
		}
		
		targetOffset = new Vector3(xOffset, yOffset, -1 * zOffset);
		anchorX = target.getPosition().x;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
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
		
		Vector3 targetPosition = target.getPosition() + targetOffset;
		targetPosition.x = anchorX;
		
 	    transform.position = targetPosition;
	}
}
