using UnityEngine;
using System.Collections;

public class PauseState : IGameState {
	private GameObject pauseGuiGO;
	private PauseGui pauseGui;
	
	public PauseState(GameObject pauseGuiGO){
		this.pauseGuiGO = pauseGuiGO;
		pauseGuiGO.SetActive(false);
		
		pauseGui = pauseGuiGO.GetComponent<PauseGui>();
	}
	
	public void enterState() {
		pauseGuiGO.SetActive(true);
		pauseGui.reset();
		
		Time.timeScale = 0;
	}
	
	public void update(){}
	
	public void exitState(){
		pauseGuiGO.SetActive(false);
		Time.timeScale = 1;
	}
	
	public bool isStateFinished() 	{return pauseGui.isReady();}
	
	public IGameState getNextGameState(){
		GameStateManager gameStateManager = GameStateManager.getSingleton();
		
		if(pauseGui.isButton1Down())
			return gameStateManager.runningPhase1State;
		else if(pauseGui.isButton2Down())
			return gameStateManager.setupState;
		else if(pauseGui.isButton3Down())
			return gameStateManager.mainMenuState;
		else
			return gameStateManager.setupState;	
	}
}
