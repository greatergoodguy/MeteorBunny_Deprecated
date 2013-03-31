using UnityEngine;
using System.Collections;

public class GameCode : MonoBehaviour {
	
	public GameObject meteor;
	public GameObject planet;
	
	private MeteorController meteorController;
	
	private IGameState runningState;
	private IGameState finishState;
	
	private IGameState activeState;
	
	void Start () {
		DebugUtils.Assert(meteor != null);
		DebugUtils.Assert(planet != null);
		
		meteorController = new MeteorController(meteor, planet);
		
		runningState = new RunningState(meteorController);
		finishState = new FinishState(meteorController);
		
		activeState = runningState;
		
		activeState.enterState();
	}
	
	void Update () {
		activeState.update();
		
		if(activeState.isStateFinished()){
			changeGameState(finishState);
		}
	}
	
	void changeGameState(IGameState newGameState){
		activeState.exitState();
		
		activeState = newGameState;
		activeState.enterState();
	}
}
