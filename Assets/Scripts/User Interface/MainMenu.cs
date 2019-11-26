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
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void CloseSettingsPanel()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void OpenScorePanel()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void CloseScorePanel()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void OpenMainMenuPanel()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void CloseMainMenuPanel()
    {
        
    }
}

