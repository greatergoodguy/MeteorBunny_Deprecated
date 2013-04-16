using UnityEngine;
using System.Collections;

public class MainMenuState : IGameState {
	private MainMenuGui mainMenuGui;
	
	public MainMenuState(MainMenuGui mainMenuGui){
		this.mainMenuGui = mainMenuGui;
		mainMenuGui.enabled = false;
	}
	
	public void enterState() {
		mainMenuGui.enabled = true;
	}
	
	public void update(){}
	
	public void exitState(){
		mainMenuGui.enabled = false;
	}
	
	public bool isStateFinished() 	{return mainMenuGui.isReady();}
	
	public IGameState getNextGameState(){
		GameStateManager gameStateManager = GameStateManager.getSingleton();
		
		if(mainMenuGui.isFirstButtonPressed()){
			return gameStateManager.startState;
		}
		else if(mainMenuGui.isSecondButtonPressed()){
			Application.Quit();
		}
		else{
			return gameStateManager.startState;	
		}
		
		
		return gameStateManager.startState;
	}
}
