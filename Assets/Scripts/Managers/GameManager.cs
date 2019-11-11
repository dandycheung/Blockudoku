using System.Collections;
using UnityEngine;

/// <summary>
/// Manages the game according to game states.
/// </summary>
[DisallowMultipleComponent]
public class GameManager : Singleton<GameManager>
{
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

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        /*GameManager.Instance.SetGameState(GameState.SplashScreen);*/
        GameplayManager.Instance.SetGameplayState(GameplayState.None);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        switch (GameManager.Instance.gameState)
        {
            case GameState.SplashScreen:
                GameManager.Instance.SetGameState(GameState.None);
                if (!SceneManager.Instance.IsCurrentScene("Splash Screen"))
                {
                    SceneManager.Instance.LoadScene("Splash Screen");
                }
                this.StartCoroutine(GameManager.Instance.SetGameStateWithWaiting(GameState.Gameplay,3f));
                break;
        
            case GameState.MainMenu:
                SceneManager.Instance.LoadScene("Main Menu");
                break;
            
            case GameState.Gameplay when !SceneManager.Instance.IsCurrentScene("Game"):
                SceneManager.Instance.LoadScene("Game");
                break;
            
            case GameState.Pause:
                GameManager.Instance.PauseGame();
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
    public IEnumerator SetGameStateWithWaiting(GameState state , float duration)
    {
        yield return new WaitForSeconds(duration);
        GameManager.Instance.gameState = state;
    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Resumes the games.
    /// </summary>
    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}