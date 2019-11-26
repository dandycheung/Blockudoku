using UnityEngine;

/// <summary>
/// 
/// </summary>
public class UiManager : Singleton<UiManager>
{
    /// <summary>
    /// 
    /// </summary>
    [Space(5f) , Header("User Interface References") , SerializeField]
    private GameplayMenu gameplayMenu;
    
    /// <summary>
    /// 
    /// </summary>
    public GameplayMenu GameplayMenu
    {
        get { return this.gameplayMenu; }
        set { this.gameplayMenu = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameOverMenu gameOverMenu;

    /// <summary>
    /// 
    /// </summary>
    public GameOverMenu GameOverMenu
    {
        get { return this.gameOverMenu; }
        set { this.gameOverMenu = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private PauseMenu pauseMenu;

    /// <summary>
    /// 
    /// </summary>
    public PauseMenu PauseMenu
    {
        get { return this.pauseMenu; }
        set { this.pauseMenu = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ReturnToMainMenu()
    {
        GameManager.Instance.SetGameState(GameState.MainMenu);
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void Exit()
    {
        GameManager.Instance.ExitGame();
    }
}
