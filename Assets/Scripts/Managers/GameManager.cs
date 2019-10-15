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
    [SerializeField] private GameState gameState;

    /// <summary>
    /// Property of the field of current game state.
    /// </summary>
    public GameState GameState
    {
        get { return this.gameState; }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        SceneManager.Instance.LoadScene(SceneName: "Main Menu");
        SetGameState(GameState.MainMenu);
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
            PauseGame();
        }
    }

    /// <summary>
    /// Sets the specified game state to the current game state.
    /// </summary>
    /// <param name="state">State which will be set to the current game state.</param>
    private static void SetGameState(GameState state)
    {
        GameManager.Instance.gameState = state;
    }

    private static void PauseGame()
    {
        
    }
}