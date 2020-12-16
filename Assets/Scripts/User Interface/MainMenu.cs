using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [Space(5f) , Header("Main Menu References") , SerializeField]
    private Button PlayButton;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Button settingsButton;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Button scoreButton;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Button exitButton;

    /// <summary>
    /// 
    /// </summary>
    public void Play()
    {
        GameManager.Instance.SetGameState(GameState.Gameplay);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OpenSettingsPanel()
    {
        GameManager.Instance.SetGameState(GameState.SettingsMenu);
    }

    /// <summary>
    /// 
    /// </summary>
    public void CloseSettingsPanel()
    {
        GameManager.Instance.SetGameState(GameState.MainMenu);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OpenScorePanel()
    {
        GameManager.Instance.SetGameState(GameState.ScoreMenu);
    }

    /// <summary>
    /// 
    /// </summary>
    public void CloseScorePanel()
    {
        GameManager.Instance.SetGameState(GameState.MainMenu);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OpenMainMenuPanel()
    {
        GameManager.Instance.SetGameState(GameState.MainMenu);
    }

    /// <summary>
    /// 
    /// </summary>
    public void CloseMainMenuPanel()
    {
        GameManager.Instance.SetGameState(GameState.MainMenu);
    }
}

