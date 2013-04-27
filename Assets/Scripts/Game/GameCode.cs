using UnityEngine;
using System.Collections;
using System.Collections.Generic;
	
public class GameCode : MonoBehaviour {
	
	private GameStateManager gameStateManager = GameStateManager.getSingleton();
	
	public GameObject meteor;
	public GameObject planet;
	
	private MeteorController meteorController;
	
	private IGameState activeState;
	private IInput input;
	
	void Awake () {
		DebugUtils.Assert(meteor != null);
		DebugUtils.Assert(planet != null);
		
		# if UNITY_EDITOR
		input = new KeyboardInput();
		# elif UNITY_ANDROID
		input = new AndroidInput();
		# else
		input = new KeyboardInput();
		# endif
		
		FinishGameGui finishGameGui = GameObject.Find("FinishGameGui").GetComponent<FinishGameGui>();
		GameObject mainMenuGuiGO = GameObject.Find("Main Camera/MainMenuGui");
		//PauseGui pauseGui = GameObject.Find("PauseGui").GetComponent<PauseGui>();
		GameObject pauseGuiGO = GameObject.Find("Main Camera/PauseGui");
		
		GameConstantsSelector gameConstantsSelector = GameObject.Find("GameConstantsSelector").GetComponent<GameConstantsSelector>();
		GameConstants gameConstants = gameConstantsSelector.getGameConstants();
		GameObject velocityTextMeshGO = GameObject.Find ("Main Camera/VelocityText");
		tk2dTextMesh velocityTextMesh = GameObject.Find("Main Camera/VelocityText").GetComponent<tk2dTextMesh>();
		velocityTextMeshGO.SetActive(false);
		
		GameObject challenges = GameObject.Find("Challenges");
	
		meteorController = new MeteorController(meteor, input, gameConstants);
		
		// Here is where all the game states should be defined
		gameStateManager.mainMenuState = new MainMenuState(mainMenuGuiGO);
		gameStateManager.setupState = new SetupState(challenges, meteorController, velocityTextMeshGO);
		gameStateManager.startState = new StartState();
		gameStateManager.runningPhase1State = new RunningPhase1State(meteorController, meteor, planet, velocityTextMesh, velocityTextMeshGO);
		gameStateManager.runningPhase2State = new RunningPhase2State(meteorController, meteor, planet, velocityTextMesh, velocityTextMeshGO);
		gameStateManager.finishState = new FinishState(finishGameGui);
		gameStateManager.pauseState = new PauseState(pauseGuiGO);
		
		activeState = gameStateManager.mainMenuState;	
		activeState.enterState();
		
		print (activeState.GetType().Name);
	}
	
	void Start () {}
	
	void Update () {
		activeState.update();
		
		if(activeState.isStateFinished()){
			changeGameState(activeState.getNextGameState());
		}
		
		if(input.isBackButtonDown()){
			if(activeState == gameStateManager.runningPhase1State){
				changeGameState(gameStateManager.pauseState);	  
			}
		}
	}
	
	void changeGameState(IGameState newGameState){
		activeState.exitState();
		
		activeState = newGameState;
		activeState.enterState();
		
		print (activeState.GetType().Name);
	}
	
	public MeteorController getMeteorController(){
		DebugUtils.Assert(meteorController != null);
		
		return meteorController;
	}
	
}
