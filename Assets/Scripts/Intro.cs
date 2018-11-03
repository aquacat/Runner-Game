using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    SimpleGameManager GM;
    void Awake()
    {
        GM = SimpleGameManager.Instance;
        GM.OnStateChange += HandleOnStateChange;
        Debug.Log("CurrentGameState When Awake Boi: " + GM.gameState);
    }
    // Use this for initializati
    void Start()
    {
        Debug.Log("CurrentGameState When Startigs Boi: " + GM.gameState);
        GM.SetGameState(GameState.MAIN_MENU);
    }

    public void HandleOnStateChange()
    {
        Debug.Log("Handling State Change To: " + GM.gameState);
        Invoke("Load Level", 3f);
    }
    public void LoadLevel()
    {
        Debug.Log("Invoking Load Level Boi");
        SceneManager.LoadScene("Menu");
    }
}
