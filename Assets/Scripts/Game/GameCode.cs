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
		MainMenuGui mainMenuGui = GameObject.Find("MainMenuGui").GetComponent<MainMenuGui>();
		PauseGui pauseGui = GameObject.Find("PauseGui").GetComponent<PauseGui>();
		
		GameConstants gameConstants = GameObject.Find("GameConstants").GetComponent<GameConstants>();
		GUIText velocityText = GameObject.Find("TextVelocity").GetComponent<GUIText>();
		
		GameObject challenges = GameObject.Find("Challenges");
	
		meteorController = new MeteorController(meteor, input, gameConstants);
		
		gameStateManager.mainMenuState = new MainMenuState(mainMenuGui);
		gameStateManager.setupState = new SetupState(challenges);
		gameStateManager.startState = new StartState();
		gameStateManager.runningState = new RunningState(meteorController, meteor, planet, velocityText);
		gameStateManager.finishState = new FinishState(finishGameGui);
		gameStateManager.pauseState = new PauseState(pauseGui);
		
		activeState = gameStateManager.mainMenuState;	
		activeState.enterState();
	}
	
	void Start () {}
	
	void Update () {
		activeState.update();
		
		if(activeState.isStateFinished()){
			changeGameState(activeState.getNextGameState());
		}
		
		if(input.isBackButtonDown()){
			if(activeState == gameStateManager.runningState){
				changeGameState(gameStateManager.pauseState);	  
			}
		}
	}
	
	void changeGameState(IGameState newGameState){
		activeState.exitState();
		
		activeState = newGameState;
		activeState.enterState();
	}
	
	public MeteorController getMeteorController(){
		DebugUtils.Assert(meteorController != null);
		
		return meteorController;
	}
	
}
