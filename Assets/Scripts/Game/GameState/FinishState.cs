using UnityEngine;
using System.Collections;

public class FinishState : IGameState {
	
	private FinishGameGui finishGameGui;
	
	public FinishState(FinishGameGui finishGameGui){
		this.finishGameGui = finishGameGui;
	}
	
	public void enterState () {
		finishGameGui.enabled = true;
	}
	
	public void update () {
	
	}
	
	public void exitState () {
		
	}
	
	public bool isStateFinished() {
		return false;
	}
}
