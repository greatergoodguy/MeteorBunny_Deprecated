using UnityEngine;
using System.Collections;

public class RedBalloonAI : MonoBehaviour {
	
	const float FLOAT_RATE = 1.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3 (0, FLOAT_RATE, 0) * Time.deltaTime;
		transform.position += movement;
	}
}
