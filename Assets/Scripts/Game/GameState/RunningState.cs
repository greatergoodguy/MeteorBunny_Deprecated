using UnityEngine;
using System.Collections;

public class RunningState : IGameState {
	
	private GameObject meteor;
	private GameObject planet;
	
	private MeteorController meteorController;
	private GUIText velocityText;
	
	public RunningState(MeteorController meteorController, GameObject meteor, GameObject planet, GUIText velocityText){
		this.meteorController = meteorController;
		this.meteor = meteor;
		this.planet = planet;
		this.velocityText = velocityText;
	}
	
	public void enterState () {}
	
	public void update () {
		meteorController.ApplyController();
		meteorController.ApplyGravity();
		
		velocityText.text = "Velocity: " + meteorController.getVerticalVelocity();
	}
	
	public void exitState () {}
	
	public bool isStateFinished() {		
		bool isFinished = meteor.transform.position.y < planet.transform.position.y;
		return isFinished;
	}
	
	public IGameState getNextGameState(){
		GameStateManager gameStateManager = GameStateManager.getSingleton();
		
		return gameStateManager.finishState;
	}
}
