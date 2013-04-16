using UnityEngine;
using System.Collections;

public class StartState : IGameState {

	private const float timeLimitInSeconds = 2.0f;
	
	private float timer;
	
	public StartState()	{timer = 0;}
	
	public void enterState () 	{timer = 0;}	
	public void update () 		{timer += Time.deltaTime;}
	public void exitState () 	{}
	
	public bool isStateFinished() {
		if(timer > timeLimitInSeconds)
			return true;
		
		return false;
	}
	
	public IGameState getNextGameState(){
		GameStateManager gameStateManager = GameStateManager.getSingleton();
		
		return gameStateManager.runningState;
	}
}
