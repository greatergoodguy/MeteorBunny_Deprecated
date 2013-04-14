using UnityEngine;
using System.Collections;

public class SatelliteAI : MonoBehaviour {
	public float FLOAT_RATE = 1.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3 (FLOAT_RATE, 0, 0) * Time.deltaTime;
		transform.position += movement;
	}
}
