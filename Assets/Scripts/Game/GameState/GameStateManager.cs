using UnityEngine;
using System.Collections;

public class GameStateManager{
	private static GameStateManager singleton;
	
	public IGameState setupState;
	public IGameState startState;
	public IGameState runningPhase1State;
	public IGameState runningPhase2State;
	public IGameState finishState;
	
	public IGameState mainMenuState;
	public IGameState pauseState;
	public IGameState optionsState;
	
	private GameStateManager(){}
	
   	public static GameStateManager getSingleton(){
		
	    if (singleton == null)
    	    singleton = new GameStateManager();
         	
        return singleton;
		
   	}
}
