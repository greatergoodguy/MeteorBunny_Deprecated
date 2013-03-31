using UnityEngine;
using System;

public class CameraController : MonoBehaviour {	
	private GameObject target;
	
	void Start () {
		target = GameObject.Find("Meteor");
		
		float targetX = target.transform.position.x;
		
		float anchorX = targetX;
		float anchorZ = transform.position.z;
		
		Vector3 targetPosition = transform.position;
		targetPosition.x = anchorX;
		targetPosition.y = target.transform.position.y;
		targetPosition.z = anchorZ;
		
 	    transform.position = targetPosition;
	}
	
	void Update () {
		TrackMeteor();
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
	private void TrackMeteor () {
		Vector3 targetPosition = transform.position;
		targetPosition.y = target.transform.position.y;
 	    transform.position = targetPosition;
	}
}
