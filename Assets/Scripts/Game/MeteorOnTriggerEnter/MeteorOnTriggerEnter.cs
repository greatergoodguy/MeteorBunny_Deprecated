using UnityEngine;
using System.Collections;

public class MeteorOnTriggerEnter : MonoBehaviour {
	
	private MeteorController meteorController;
	
	void Start (){
		GameObject code = GameObject.Find("Code");
		GameCode gameCode = code.GetComponent<GameCode>();
		
		meteorController = gameCode.getMeteorController();
	}
}
