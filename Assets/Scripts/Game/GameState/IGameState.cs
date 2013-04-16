using UnityEngine;
using System.Collections;

public interface IGameState {
	void enterState();
	void update();
	void exitState();
	
	bool isStateFinished();
	IGameState getNextGameState();
}
