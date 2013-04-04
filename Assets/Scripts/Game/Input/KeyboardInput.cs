using UnityEngine;
using System.Collections;

public class KeyboardInput : IInput {
	public float getHorizontalAxis(){
		float horAxis = Input.GetAxis("Horizontal");
		return horAxis;
	}
}
