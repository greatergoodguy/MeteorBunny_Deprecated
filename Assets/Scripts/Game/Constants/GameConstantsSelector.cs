using UnityEngine;
using System.Collections;

public class GameConstantsSelector : MonoBehaviour {
	public enum Person {Kris, Tom}
	public Person person = Person.Kris;
	
	private GameConstants gameConstants;
	
	void Awake () {
		switch(person){
		case Person.Kris:
			gameConstants = GameObject.Find("GameConstantsKris").GetComponent<GameConstants>();
			break;
		case Person.Tom:
			gameConstants = GameObject.Find("GameConstantsTom").GetComponent<GameConstants>();
			break;
		default:
			gameConstants = GameObject.Find("GameConstantsKris").GetComponent<GameConstants>();
			break;
		}
		
		gameConstants.printToConsole();
		
		DebugUtils.Assert(gameConstants != null);
	}
	
	void Start () {
	}
	
	void Update () { }
	
	public GameConstants getGameConstants(){
		return gameConstants;	
	}
}
