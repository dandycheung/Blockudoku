using UnityEngine;
using System.Collections;

/// <summary>
/// Manages the game according to game states.
/// </summary>
[DisallowMultipleComponent]
public class GameManager : Singleton<GameManager>
{
    #region Fields

    /// <summary>
    /// Field of the current game state of game.
    /// </summary>
    [SerializeField]
    private GameState gameState;

    /// <summary>
    /// Property of the field of current game state.
    /// </summary>
    public GameState GameState
    {
        get { return this.gameState; }
        private set { this.gameState = value; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        GameManager.Instance.SetGameState(GameState.SplashScreen);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (GameManager.Instance.gameState.Equals(GameState.None)) return;
        
        switch (GameManager.Instance.gameState)
        {
            case GameState.SplashScreen:
                if (!SceneManager.Instance.IsCurrentScene("Splash Screen"))
                {
                    DontDestroyOnLoad(GameManager.Instance);
                    SceneManager.Instance.LoadScene("Splash Screen");
                }
                GameManager.Instance.StartCoroutine(GameManager.Instance.SetGameStateWithWaiting(GameState.MainMenu,3f));
                break;
        
            case GameState.MainMenu:
                if (!SceneManager.Instance.IsCurrentScene("Main Menu"))
                {
                    DontDestroyOnLoad(GameManager.Instance);
                    SceneManager.Instance.LoadScene("Main Menu");
                }
                break;
            
            case GameState.Gameplay :
                if (!SceneManager.Instance.IsCurrentScene("Game"))
                {
                    DontDestroyOnLoad(GameManager.Instance);
                    SceneManager.Instance.LoadScene("Game");
                }
                break;

            case GameState.ScoreMenu:
                if (!SceneManager.Instance.IsCurrentScene("Score Menu"))
                {
                    DontDestroyOnLoad(GameManager.Instance);
                    SceneManager.Instance.LoadScene("Score Menu");
                }
                break;

            case GameState.SettingsMenu:
                if (!SceneManager.Instance.IsCurrentScene("Settings Menu"))
                {
                    DontDestroyOnLoad(GameManager.Instance);
                    SceneManager.Instance.LoadScene("Settings Menu");
                }
                break;

            case GameState.None:
                break;
        }
    }

    /// <summary>
    /// Sets the specified game state to the current game state.
    /// </summary>
    /// <param name="state">State which will be set to the current game state.</param>
    public void SetGameState(GameState state)
    {
        GameManager.Instance.gameState = state;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    private IEnumerator SetGameStateWithWaiting(GameState state , float duration)
    {
        GameManager.Instance.SetGameState(GameState.None);
        yield return new WaitForSeconds(duration);
        GameManager.Instance.SetGameState(state);
    }

    /// <summary>
    /// 
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pauseStatus"></param>
    private void OnApplicationPause(bool pauseStatus)
    {
        if (GameManager.Instance.gameState.Equals(GameState.Gameplay) &&
            !GameplayManager.Instance.GameplayState.Equals(GameplayState.GameOvered))
        {
            SaveManager.Instance.SaveProgress(); 
        }
        SaveManager.Instance.CreatePlayerData();
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnApplicationQuit()
    {
        if (GameManager.Instance.gameState.Equals(GameState.Gameplay) &&
            !GameplayManager.Instance.GameplayState.Equals(GameplayState.GameOvered))
        {
            SaveManager.Instance.SaveProgress();
        }
        SaveManager.Instance.CreatePlayerData();
    }

    #endregion
}