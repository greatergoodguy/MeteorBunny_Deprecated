using UnityEngine;
using System.Collections;

public class StartState : IGameState {

	private const float timeLimitInSeconds = 10.0f;
	
	private float timer;
	
	public StartState(){
		timer = 0;
	}
	
	public void enterState () {
		timer = 0;
	}
	
	public void update () {
		timer += Time.deltaTime;
		Debug.Log ("timer: " + timer);
	}
	
	public void exitState () {
		
	}
	
	public bool isStateFinished() {
		if(timer > timeLimitInSeconds)
			return true;
		
		return false;
	}
}
