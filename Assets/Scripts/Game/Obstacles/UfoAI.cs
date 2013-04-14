using UnityEngine;
using System.Collections;

public class UfoAI : MonoBehaviour {

	public float FLOAT_RATE = 1.0f;
	
	void Start () {
	
	}
	
	void Update () {
		Vector3 movement = new Vector3 (-FLOAT_RATE, 0, 0) * Time.deltaTime;
		transform.position += movement;
	}
}
