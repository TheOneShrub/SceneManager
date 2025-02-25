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
    using UnityEngine;
    
    
    public class GameManagerOLD : Singleton<GameManager>
    {

        public GameState currentState; 
        // Start is called before the first frame update
        void Start()
        {
            currentState = GameState.MainMenu;
        }//end Start()
    
        // Update is called once per frame
        void Update()
        {
            #if UNITY_EDITOR
            ManageGameState();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame();
            }
            #endif

        }//end Update()

        void QuitGame()
        {
            Application.Quit();
            
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

        void ManageGameState()
        {
            switch (currentState)
            {
                case GameState.MainMenu:
                    Debug.Log("MainMenu");
                    break;
                
                case GameState.Gameplay:
                    Debug.Log("Gameplay");
                    break;
                
                case GameState.Paused:
                    Debug.Log("Paused");
                    break;
                
                case GameState.GameOver:
                    Debug.Log("GameOver");
                    break;
                
                case GameState.Victory:
                    Debug.Log("Victory");
                    break;
            }//emd switch
        }//end managegamestate


        public void ChangeState(GameState newState)
        {
            
        }
        
        
        
        
        
        
        
    }
