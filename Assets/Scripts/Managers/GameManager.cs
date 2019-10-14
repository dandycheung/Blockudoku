using System;
using UnityEngine;

/// <summary>
/// Manages the loop of game.
/// </summary>
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
        SetGameState(GameState.MainMenu);
    }

    /// <summary>
    /// Sets the specified game state to the current game state.
    /// </summary>
    /// <param name="state"></param>
    private void SetGameState(GameState state)
    {
        GameManager.Instance.gameState = state;
    }
}