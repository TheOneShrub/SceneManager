/*******************************************************************
* COPYRIGHT       : Year
* PROJECT         : CSG general libraries
* FILE NAME       : GameManager.cs
* DESCRIPTION     : game manager
*
* REVISION HISTORY:
* Date            Author                  Comments
* ---------------------------------------------------------------------------
* 2025/02/04      Blaine Grimes             Created class
*
*
/******************************************************************/

//namespace CSG.General 

using System.Collections;
using System.Collections.Generic;
using CSG.General;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState CurrentState;
    
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentState = GameState.MainMenu;
    }//end Start()

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        ManageGameState();

        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
#endif
        
    }//end Update()

    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void ManageGameState()
    {
        switch (CurrentState)
        {
            case GameState.MainMenu:
                //Debug.Log("Main Menu");
                break;
            case GameState.Playing:
                break;
            case GameState.Paused:
                break;
            case GameState.GameOver:
                break;
        }
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;
    }
}