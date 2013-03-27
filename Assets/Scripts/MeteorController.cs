/**
 * This script is to provide control for the meteor (or other falling object).
 * It implements IBBCamera so that it may be the target of a BBCamera script.
 * 
 * @author Taylor McKinney, Bursting Brains
 */

using UnityEngine; 
using System;

public class MeteorController : MonoBehaviour, IBBCameraTarget {

  // Public Members
  public float MaximumFallingSpeed = 20.0f;
  public float FallingRate = 1.0f;
  public float FallingAccelerationRate = 9.80f;
  public float GroundLevel = 0.0f;
	
  public float horizontalSpeed = 10.0f;

  // Private Members
  private Vector3 velocity;
  private Vector3 lastPosition;
  private float RealFallingRate;
  private CharacterController controller;

  // IBBCameraTarget Methods
  // Velocity
  public Vector3 getVelocity() {
    return velocity;
  }

  // Position
  public Vector3 getPosition() {
    return transform.position;
  }

  /**
   * Applys the movement we have so far
   */
  private void ApplyMovement() {
    lastPosition = transform.position;
	
	var horAxis = Input.GetAxis ("Horizontal");
	
	Vector3 tempPosition = transform.position;
	tempPosition.x += horAxis * horizontalSpeed * Time.deltaTime;
	transform.position = tempPosition;
		
    ApplyGravity();

    // Must be at the end
    velocity = (transform.position - lastPosition) / Time.deltaTime;
  }

  /**
   * Adds gravity into the velocity vector
   */
  private void ApplyGravity() {
    RealFallingRate -= FallingAccelerationRate * Time.deltaTime;
    RealFallingRate = Mathf.Min(RealFallingRate, MaximumFallingSpeed);

    float FallingDistance = RealFallingRate * Time.deltaTime;
	float DistanceToGround = GroundLevel - transform.position.y;
	FallingDistance = Mathf.Max(DistanceToGround, FallingDistance);

    controller.Move(new Vector3(0, FallingDistance, 0));
  }

  /**
   * Run when the object is instantiated
   */
	void Start () {
    velocity = new Vector3(0, 0, 0);
    RealFallingRate = FallingRate;
    controller = GetComponent<CharacterController>();
	}
	
	/**
   * Runs every frame
   */
	void Update () {
    ApplyMovement();
	}
}
