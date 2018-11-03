using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { INTRO, MAIN_MENU, GAME, EXIT }
public delegate void OnStateChangeHandler();
public class SimpleGameManager : MonoBehaviour
{
    public bool Quest1 = false;
    public bool Quest2 = false;
    public bool Quest3 = false;
    protected SimpleGameManager() { }
    private static SimpleGameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }
    public static SimpleGameManager Instance
    {
        get
        {
		if (SimpleGameManager.instance == null)
            {
				SimpleGameManager.instance = FindObjectOfType<SimpleGameManager>();
				if (SimpleGameManager.instance == null){
					GameObject go = new GameObject();
					go.name = "SimpleGameManager";
					SimpleGameManager.instance = go.AddComponent<SimpleGameManager>();
	                DontDestroyOnLoad(go);
				}
            }
            return SimpleGameManager.instance;
        }

    }
    void Awake()
    {
        if (instance == null){
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			Destroy(gameObject);
		}
    }
    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }
    public void OnApplicationQuit()
    {
        SimpleGameManager.instance = null;
    }
    public void FinishQuest1()
    {
        Quest1 = true;
		Debug.Log ("Killed Dummie 1");
		if (AreQuestsFinished()) OpenTheGate();
    }
    public void FinishQuest2()
    {
        Quest2 = true;
		Debug.Log ("Killed Dummie 2");
		if (AreQuestsFinished()) OpenTheGate();
    }
    public void FinishQuest3()
    {
        Quest3 = true;
		Debug.Log ("Killed Dummie 3");
		if (AreQuestsFinished()) OpenTheGate();
    }
    bool AreQuestsFinished()
    {
		Debug.Log ("Are Quests Finished? " + (Quest1 && Quest2 && Quest3));
		Debug.Log ("Quest1: " + Quest1);
		Debug.Log ("Quest2: " + Quest2);
		Debug.Log ("Quest3: " + Quest3);
        return Quest1 && Quest2 && Quest3;
    }
	void OpenTheGate(){
		GameObject[] gates;
		gates = GameObject.FindGameObjectsWithTag("EndWall");
		Debug.Log ("Got " + gates.Length + " gates");
		foreach (GameObject gate in gates)
		{
			Destroy(gate);
		}
	}
}	
