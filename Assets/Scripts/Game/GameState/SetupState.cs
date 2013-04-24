using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetupState : IGameState {
	
	List<IObstacleAI> obstacles;
	MeteorController meteorController;
	GameObject velocityTextMeshGO;
	
	public SetupState(GameObject challenges, MeteorController meteorController, GameObject velocityTextMeshGO){
		DebugUtils.Assert(challenges != null);
		
		this.meteorController = meteorController;
		obstacles = new List<IObstacleAI>();
		
		this.velocityTextMeshGO = velocityTextMeshGO;
		
		GameObject[] obstaclesGOs = GameObject.FindGameObjectsWithTag("ObstacleAI");
		foreach (GameObject obstacleGO in obstaclesGOs){
			IObstacleAI obstacleAI = null;
			
			if(obstacleGO.name == "Cloud1"){							obstacleAI = obstacleGO.GetComponent<CloudAI>();}
			else if(obstacleGO.name == "RedBalloonActivationBound"){	obstacleAI = obstacleGO.GetComponent<RedBalloonActivatorAI>();}
			else if(obstacleGO.name == "RedBalloonSprite"){				obstacleAI = obstacleGO.GetComponent<RedBalloonAI>();}
			else if(obstacleGO.name == "SatelliteActivationBound"){		obstacleAI = obstacleGO.GetComponent<SatelliteActivatorAI>();}
			else if(obstacleGO.name == "SatelliteAnim"){				obstacleAI = obstacleGO.GetComponent<SatelliteAI>();}
			else if(obstacleGO.name == "UfoActivationBound"){			obstacleAI = obstacleGO.GetComponent<UfoActivatorAI>();}
			else if(obstacleGO.name == "UfoAnim"){						obstacleAI = obstacleGO.GetComponent<UfoAI>();}
			
			DebugUtils.Assert(obstacleAI != null);
			obstacles.Add(obstacleAI);
		}
	}
	
	public void enterState () {
		foreach(IObstacleAI obstacleAI in obstacles)
			obstacleAI.reset();
		
		meteorController.reset();
		velocityTextMeshGO.SetActive(true);
	}
	
	public void update () {
	}
	
	public void exitState () {}
	
	public bool isStateFinished() {		
		return true;
	}
	
	public IGameState getNextGameState(){
		GameStateManager gameStateManager = GameStateManager.getSingleton();
		
		return gameStateManager.startState;
	}
}
