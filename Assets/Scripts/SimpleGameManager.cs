using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {INTRO, MAIN_MENU, GAME, EXIT}
public delegate void OnStateChangeHandler();
public class SimpleGameManager : Object {
	public bool Quest1 = false;
	public bool Quest2 = false;
	public bool Quest3 = false;
	protected SimpleGameManager(){}
	private static SimpleGameManager instance = null;
	public event OnStateChangeHandler OnStateChange;
	public GameState gameState { get; private set;}
	public static SimpleGameManager Instance{
		get {
			if (SimpleGameManager.instance == null) {
				SimpleGameManager.instance = new SimpleGameManager();
			}
			return SimpleGameManager.instance;
		}

	}
	void Awake() {
		Debug.Log("SimpleGameManager: " + SimpleGameManager.instance.gameState);
		DontDestroyOnLoad(SimpleGameManager.instance);
	}
	public void SetGameState(GameState state){
		this.gameState = state;
		OnStateChange();
	}
	public void OnApplicationQuit() {
		SimpleGameManager.instance = null;
	}
}
