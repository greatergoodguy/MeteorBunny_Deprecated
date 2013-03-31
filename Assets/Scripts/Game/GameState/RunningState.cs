using UnityEngine;
using System.Collections;

public class RunningState : IGameState {
	private MeteorController meteorController;
	
	public RunningState(MeteorController meteorController){
		this.meteorController = meteorController;
	}
	
	public void enterState () {
	
	}
	
	public void update () {
		meteorController.ApplyController();
		meteorController.ApplyGravity();
	}
	
	public void exitState () {
		
	}
	
	public bool isStateFinished() {
		bool isFinished = meteorController.isGroundLevel();
		return isFinished;
	}
}
