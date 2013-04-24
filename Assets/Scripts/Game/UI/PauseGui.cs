using UnityEngine;
using System.Collections;

public class PauseGui : MonoBehaviour {
	
	private bool isButton1Down_ = false;
	private bool isButton2Down_ = false;
	private bool isButton3Down_ = false;
	private bool isReady_ = false;
	
	void Start() {
		reset();
	}
	
	public void pressButton1(){
		isButton1Down_ = !isButton1Down_;
		isReady_ = true;
	}
	
	public void pressButton2(){
		isButton2Down_ = !isButton2Down_;
		isReady_ = true;
	}
	
	public void pressButton3(){
		isButton3Down_ = !isButton3Down_;
		isReady_ = true;
	}
	
	public bool isButton1Down(){
		return isButton1Down_;
	}
	
	public bool isButton2Down(){
		return isButton2Down_;
	}
	
	public bool isButton3Down(){
		return isButton3Down_;
	}
	
	public bool isReady(){
		return isReady_;
	}
	
	public void reset(){
		isButton1Down_ = false;
		isButton2Down_ = false;
		isButton3Down_ = false;
		isReady_ = false;
	}
}
