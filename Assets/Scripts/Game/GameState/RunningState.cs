using UnityEngine;
using System.Collections;

public class RunningState : IGameState {
	private MeteorController meteorController;
	private GUIText velocityText;
	
	public RunningState(MeteorController meteorController, GUIText velocityText){
		this.meteorController = meteorController;
		this.velocityText = velocityText;
	}
	
	public void enterState () {
	
	}
	
	public void update () {
		meteorController.ApplyController();
		meteorController.ApplyGravity();
		
		velocityText.text = "Velocity: " + meteorController.getVerticalVelocity();
	}
	
	public void exitState () {
		
	}
	
	public bool isStateFinished() {
		bool isFinished = meteorController.isGroundLevel();
		return isFinished;
	}
}
