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
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        SceneManager.Instance.LoadScene(SceneName: "Main Menu");
        SetGameState(GameState.MainMenu);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        if (this.gameState == GameState.MainMenu && !SceneManager.Instance.IsCurrentScene("Main Menu"))
        {
            SceneManager.Instance.LoadScene("Main Menu");
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
}