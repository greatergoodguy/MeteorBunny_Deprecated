using UnityEngine;
using System.Collections;

public class MeteorOnTriggerEnter : MonoBehaviour {
	
	private MeteorController meteorController;
	
	private bool phase2Activated;
	
	void Start (){
		GameObject code = GameObject.Find("Code");
		GameCode gameCode = code.GetComponent<GameCode>();
		
		meteorController = gameCode.getMeteorController();
		
		phase2Activated = false;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "RunningStateTrigger"){
			phase2Activated = true;
		}
    }
	
	public bool isPhase2Activated(){
		return phase2Activated;
	}
}
