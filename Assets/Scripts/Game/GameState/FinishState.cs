using UnityEngine;
using System.Collections;

public class FinishState : IGameState {
	
	private FinishGameGui finishGameGui;
	
	public FinishState(FinishGameGui finishGameGui){
		this.finishGameGui = finishGameGui;
		finishGameGui.enabled = false;
	}
	
	public void enterState() {
		finishGameGui.enabled = true;
	}
	
	public void update(){}
	public void exitState(){}
	
	public bool isStateFinished() 	{return false;}
	
	public IGameState getNextGameState(){
		GameStateManager gameStateManager = GameStateManager.getSingleton();
		
		return gameStateManager.startState;
	}
}
