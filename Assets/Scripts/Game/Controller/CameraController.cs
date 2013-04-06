using UnityEngine;
using System;

public class CameraController : MonoBehaviour {	
	private GameObject target;
	
	private Vector3 offset;
	private float offsetY;
	
	void Start () {
		target = GameObject.Find("Meteor");
		offset = transform.position - target.transform.position;
	}
	
	void Update () {
		Vector3 tempPosition = transform.position;
		tempPosition.y = target.transform.position.y + offset.y;
		transform.position = tempPosition;
	}
}
