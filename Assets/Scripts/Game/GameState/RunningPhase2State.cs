using UnityEngine;
using System.Collections;

public class RunningPhase2State : IGameState {
	
	private GameObject meteor;
	private GameObject planet;
	
	private MeteorController meteorController;
	private tk2dTextMesh velocityTextMesh;
	private GameObject velocityTextMeshGO;
	
	public RunningPhase2State(MeteorController meteorController, GameObject meteor, GameObject planet, tk2dTextMesh velocityTextMesh, GameObject velocityTextMeshGO){
		this.meteorController = meteorController;
		this.meteor = meteor;
		this.planet = planet;
		this.velocityTextMesh = velocityTextMesh;
		this.velocityTextMeshGO = velocityTextMeshGO;
	}
	
	public void enterState () {
		velocityTextMeshGO.SetActive(true);
		Time.timeScale = 1;
	}
	
	public void update () {
		meteorController.ApplyController();
		meteorController.ApplyGravity();
		
		velocityTextMesh.text = "Velocity: " + meteorController.getVerticalVelocity();
		velocityTextMesh.Commit();
	}
	
	public void exitState () {
		velocityTextMesh.enabled = false;
		velocityTextMeshGO.SetActive(false);
		Time.timeScale = 1;
	}
	
	public bool isStateFinished() {		
		bool isFinished = meteor.transform.position.y < planet.transform.position.y;
		return isFinished;
	}
	
	public IGameState getNextGameState(){
		GameStateManager gameStateManager = GameStateManager.getSingleton();
		
		return gameStateManager.finishState;
	}
}
