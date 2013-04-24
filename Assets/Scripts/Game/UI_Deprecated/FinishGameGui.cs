using UnityEngine;
using System.Collections;

public class FinishGameGui : MonoBehaviour {

	public Texture bgTexture;
	public Texture replayTexture;
	public Texture quitTexture;

	private int menuWidth = 700;
	private int menuHeight = 1200;

	private int buttonWidth = 400;
	private int buttonHeight  = 200;
	private int spacing = 20;

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, menuWidth, menuHeight), bgTexture);
		
		if(GUILayout.Button(replayTexture, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight))){
			Application.LoadLevel("Game");
		}
		GUILayout.Space(spacing);
	
		if(GUILayout.Button(quitTexture, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight))){
			Application.LoadLevel("MainMenu");
		}
		GUILayout.EndArea();
	}
}
