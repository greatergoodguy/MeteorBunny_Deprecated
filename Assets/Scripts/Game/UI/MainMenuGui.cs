using UnityEngine;
using System.Collections;

public class MainMenuGui : MonoBehaviour {
	
	private bool isButton1Down;
	private bool isButton2Down;
	private bool isReady_;
	
	void Start () {
		isButton1Down = false;
		isButton2Down = false;
		isReady_ = false;
	}
	void Update () {}
	
	/*
	 * 	These are the messages that can activated
	 *  using 2dtoolkit's buttons
	 */ 
	public void pressButton1(){
		isButton1Down = !isButton1Down;
		isReady_ = true;
	}
	
	public void pressButton2(){
		isButton2Down = !isButton2Down;
		isReady_ = true;
	}
	
	public bool isPlayButtonPressed(){
		return isButton1Down;
	}
	
	public bool isQuitButtonPressed(){
		return isButton2Down;
	}
	
	public bool isReady(){
		return isReady_;
	}
	
	public void reset(){
		isButton1Down = false;
		isButton2Down = false;
		isReady_ = false;
	}
}
