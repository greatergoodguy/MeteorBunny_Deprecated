using UnityEngine;
using System.Collections;

public class DummyState : IGameState {
	
	private static DummyState singleton = new DummyState();
	
	private DummyState(){}
	
	public void enterState() {Application.Quit();}
	public void update(){}
	public void exitState(){}
	public bool isStateFinished() 	{return false;}
	
	public IGameState getNextGameState(){
		return GameStateManager.getSingleton().mainMenuState;
	}
	
	public static DummyState getSingleton(){
		return singleton;	
	}
}