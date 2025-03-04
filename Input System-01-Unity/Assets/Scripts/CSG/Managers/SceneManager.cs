using UnityEngine;
using CSG.General;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class SceneManager : Singleton<SceneManager>
{
    //Non-Gameplay scene names
    public string mainMenu = "MainMenu";
    public string pauseMenu = "PauseMenu";
    public string gameOver = "GameOver";

    //Gameplay scenes
    public List<string> GameLevels = new List<string>();

    //scene management
    public string gameLevelToLoad = "";
    public int gameLevelIndex = -1;
    private string _currentScene = "";
    private List<string> _loadedScenes = new List<string>();

    LoadSceneMode loadMode;

    private IEnumerator sceneLoadCoroutine;
    private IEnumerator sceneUnloadCoroutine;


    //Handles requests to load scenes. Starts scene load coroutine
    public void OnSceneChangeRequest(string sceneName, bool isAdditive = false)
    {
        if (!_loadedScenes.Contains(sceneName))
        {
            if (isAdditive){
                loadMode = LoadSceneMode.Additive;
            }
            else
            {
                loadMode = LoadSceneMode.Single;
            }
        }
        sceneLoadCoroutine = LoadSceneAsync(sceneName, loadMode);
        StartCoroutine(sceneLoadCoroutine);
    }

    //get new game level name to load
    public string GetGameLevel(string gameLevelName = null)
    {
        //Sequential level loading
        if (gameLevelName == null)
        {
            gameLevelIndex++;
            //if reached end of level list
            if (gameLevelIndex >= GameLevels.Count)
            {
                Debug.Log("Out of levels to load");
                return "";
            }
        }

        //ensure game level exists
        else if (GameLevels.Contains(gameLevelName))
        {
               gameLevelIndex = GameLevels.IndexOf(gameLevelName);
        }
        else
        {
            Debug.Log("Game level not found, defaulting.");
            gameLevelIndex = 0;
        }
        gameLevelToLoad = GameLevels[gameLevelIndex];

        //Request scene change using new level name
        OnSceneChangeRequest(gameLevelToLoad);
        return gameLevelToLoad;
    }

    //Load the requested scene from OnSceneChangeRequest
    private IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode loadMode)
    {
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, loadMode);

        //ensure async operation is functioning
        if (asyncLoad == null)
        {
            Debug.Log("LoadSceneAsync operation failed");
            yield break;
        }
        else if (loadMode == LoadSceneMode.Single && _currentScene != sceneName)
        {
            _loadedScenes.Clear();
            _currentScene = sceneName;
        }

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        _loadedScenes.Add(sceneName);
        Debug.Log(_loadedScenes.ToString());
    }

    //Method to start scene unload coroutine
    public void UnloadScene(string sceneToUnload)
    {
        if (_loadedScenes.Contains(sceneToUnload))
        {
            Debug.Log("Scene to unload found: " + sceneToUnload);
            sceneUnloadCoroutine = UnloadSceneAsync(sceneToUnload);
            StartCoroutine(sceneUnloadCoroutine);
        }
        else { Debug.LogError("Scene to unload not found"); }
    }

    //Coroutine to unload scene asynchronously
    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        Debug.Log("Unloading " + sceneName);
        AsyncOperation asyncUnload = 
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);

        while (!asyncUnload.isDone)
        {
            yield return null;
        }
        _loadedScenes.Remove(sceneName);
    }

    //ought to be self-explanatory
    public void UnloadAllScenes()
    {
        _loadedScenes.Clear();
        gameLevelIndex = -1;
    }

   }