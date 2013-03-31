using UnityEngine;
using System.Collections;

public class FinishState : IGameState {
	
	private MeteorController meteorController;
	
	public FinishState(MeteorController meteorController){
		this.meteorController = meteorController;
	}
	
	public void enterState () {
	
	}
	
	public void update () {
	
	}
	
	public void exitState () {
		
	}
	
	public bool isStateFinished() {
		return false;
	}
}
