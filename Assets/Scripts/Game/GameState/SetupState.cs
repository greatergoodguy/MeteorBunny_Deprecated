using UnityEngine;
using System.Collections;

public class SetupState : IGameState {
	
	ArrayList obstacleList;
	
	public SetupState(GameObject challenges){
		obstacleList = new ArrayList();
		
	}
	
	public void enterState () {}
	
	public void update () {
	}
	
	public void exitState () {}
	
	public bool isStateFinished() {		
		return true;
	}
	
	public IGameState getNextGameState(){
		GameStateManager gameStateManager = GameStateManager.getSingleton();
		
		return gameStateManager.finishState;
	}
}
