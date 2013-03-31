using UnityEngine;
using System.Collections;

interface IGameState {
	void enterState();
	void update();
	void exitState();
	
	bool isStateFinished();
}
