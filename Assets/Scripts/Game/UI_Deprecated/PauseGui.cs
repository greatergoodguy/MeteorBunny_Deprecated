using UnityEngine;
using System.Collections;

public class PauseGui : MonoBehaviour {
	
	public Texture bgTexture;
	public Texture playTexture;
	public Texture quitTexture;

	private int menuWidth = 700;
	private int menuHeight = 1200;

	private int buttonWidth = 400;
	private int buttonHeight = 200;
	private int spacing = 20;
	
	private bool isFirstButtonPressed_b = false;
	private bool isSecondButtonPressed_b = false;
	private bool isReady_b = false;
	
	void Start() {
		reset();
	}
	
	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, menuWidth, menuHeight), bgTexture);
		if(GUILayout.Button(playTexture, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight))){
			//Application.LoadLevel("Game");
			
			isFirstButtonPressed_b = true;
			isSecondButtonPressed_b = false;
			isReady_b = true;
		}
		GUILayout.Space(spacing);
	
		if(GUILayout.Button(quitTexture, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight))){
			//Application.Quit();
			
			isFirstButtonPressed_b = false;
			isSecondButtonPressed_b = true;
			isReady_b = true;
		}
		GUILayout.EndArea();
	}
	
	public bool isResumeButtonPressed(){
		return isFirstButtonPressed_b;
	}
	
	public bool isQuitButtonPressed(){
		return isSecondButtonPressed_b;
	}
	
	public bool isReady(){
		return isReady_b;
	}
	
	public void reset(){
		isFirstButtonPressed_b = false;
		isSecondButtonPressed_b = false;
		isReady_b = false;
	}
}
