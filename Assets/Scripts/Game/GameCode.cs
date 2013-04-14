using UnityEngine;
using System.Collections;
using System.Collections.Generic;
	
public class GameCode : MonoBehaviour {
	
	public GameObject meteor;
	public GameObject planet;
	
	private MeteorController meteorController;
	
	private List<IGameState> gameStates;
	private int gameStateIndex;
	private IGameState activeState;
	
	void Awake () {
		DebugUtils.Assert(meteor != null);
		DebugUtils.Assert(planet != null);
		
		IInput input;
		
		# if UNITY_EDITOR
		input = new KeyboardInput();
		# elif UNITY_ANDROID
		input = new AndroidInput();
		# else
		input = new KeyboardInput();
		# endif
		
		FinishGameGui finishGameGui = GameObject.Find("FinishGameGui").GetComponent<FinishGameGui>();
		finishGameGui.enabled = false;
		
		GameConstants gameConstants = GameObject.Find("GameConstants").GetComponent<GameConstants>();
		GUIText velocityText = GameObject.Find("TextVelocity").GetComponent<GUIText>();
		
		meteorController = new MeteorController(meteor, input, gameConstants);
		gameStates = new List<IGameState>();
		gameStateIndex = 0;
		
		gameStates.Add(new StartState());
		gameStates.Add(new RunningState(meteorController, meteor, planet, velocityText));
		gameStates.Add(new FinishState(finishGameGui));
		
		activeState = gameStates[gameStateIndex];
		
		activeState.enterState();
	}
	
	void Start () {
	}
	
	void Update () {
		activeState.update();
		
		if(activeState.isStateFinished()){
			advaceGameStateList();
		}
	}
	
	void changeGameState(IGameState newGameState){
		activeState.exitState();
		
		activeState = newGameState;
		activeState.enterState();
	}
	
		
	void advaceGameStateList(){
		activeState.exitState();
		
		if(gameStateIndex < gameStates.Count){
			gameStateIndex++;
		}
		else{
			gameStateIndex = gameStates.Count - 1;
		}
		
		
		activeState = gameStates[gameStateIndex];
		activeState.enterState();
	}
	
	public MeteorController getMeteorController(){
		DebugUtils.Assert(meteorController != null);
		
		return meteorController;
	}
}
