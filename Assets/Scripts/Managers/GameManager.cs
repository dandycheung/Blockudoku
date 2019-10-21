using UnityEngine;

/// <summary>
/// Manages the loop of game.
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
        SceneManager.Instance.LoadScene(SceneName: "Main Menu");
        GameManager.Instance.SetGameState(GameState.MainMenu);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (this.gameState == GameState.MainMenu && !SceneManager.Instance.IsCurrentScene("Main Menu"))
        {
            SceneManager.Instance.LoadScene("Main Menu");
            return;
        }

        if (this.gameState == GameState.Gameplay && !SceneManager.Instance.IsCurrentScene("Game"))
        {
            SceneManager.Instance.LoadScene("Game");
            return;
        }

        if (this.gameState == GameState.Pause && SceneManager.Instance.IsCurrentScene("Game"))
        {
            GameManager.Instance.PauseGame();
            return;
        }

        if (this.gameState == GameState.Gameplay && SceneManager .Instance.IsCurrentScene("Game"))
        {
            GameManager.Instance.ResumeGame();
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