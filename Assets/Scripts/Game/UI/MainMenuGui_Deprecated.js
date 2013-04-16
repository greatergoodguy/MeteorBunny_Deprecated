public var bgTexture : Texture;
public var playTexture : Texture;
public var quitTexture : Texture;

private var menuWidth : int = 700;
private var menuHeight : int = 1200;

private var buttonWidth : int = 400;
private var buttonHeight : int = 200;
private var spacing : int = 20;

function OnGUI() {
	GUILayout.BeginArea(Rect(0, 0, menuWidth, menuHeight), bgTexture);
	if(GUILayout.Button(playTexture, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight))){
		Application.LoadLevel("Game");
	}
	GUILayout.Space(spacing);
	
	if(GUILayout.Button(quitTexture, GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight))){
		Application.Quit();
	}
	GUILayout.EndArea();
}

function Start () {

}

function Update () {

}