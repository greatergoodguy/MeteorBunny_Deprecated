using UnityEngine;
using System.Collections;

public class PauseState : IGameState {
	private PauseGui pauseGui;
	
	public PauseState(PauseGui pauseGui){
		this.pauseGui = pauseGui;
		pauseGui.enabled = false;
	}
	
	public void enterState() {
		pauseGui.enabled = true;
		pauseGui.reset ();
	}
	
	public void update(){}
	
	public void exitState(){
		pauseGui.enabled = false;
	}
	
	public bool isStateFinished() 	{return pauseGui.isReady();}
	
	public IGameState getNextGameState(){
		GameStateManager gameStateManager = GameStateManager.getSingleton();
		
		if(pauseGui.isResumeButtonPressed())
			return gameStateManager.runningState;
		else if(pauseGui.isQuitButtonPressed())
			return gameStateManager.mainMenuState;
		else
			return gameStateManager.mainMenuState;	
	}
}
