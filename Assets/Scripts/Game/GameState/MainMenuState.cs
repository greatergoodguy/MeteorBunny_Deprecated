using UnityEngine;
using System.Collections;

public class MainMenuState : IGameState {
	private GameObject mainMenuGuiGO;
	private MainMenuGui mainMenuGui;
	
	public MainMenuState(GameObject mainMenuGuiGO){
		this.mainMenuGuiGO = mainMenuGuiGO;
		mainMenuGuiGO.SetActive(false);
		
		mainMenuGui = mainMenuGuiGO.GetComponent<MainMenuGui>();
	}
	
	public void enterState() {
		mainMenuGuiGO.SetActive(true);
		mainMenuGui.reset();
	}
	
	public void update(){}
	
	public void exitState(){
		mainMenuGuiGO.SetActive(false);
	}
	
	public bool isStateFinished() 	{return mainMenuGui.isReady();}
	
	public IGameState getNextGameState(){
		GameStateManager gameStateManager = GameStateManager.getSingleton();
		
		if(mainMenuGui.isPlayButtonPressed())
			return gameStateManager.setupState;
		else if(mainMenuGui.isQuitButtonPressed())
			Application.Quit();
		
		return gameStateManager.setupState;	
	}
}
