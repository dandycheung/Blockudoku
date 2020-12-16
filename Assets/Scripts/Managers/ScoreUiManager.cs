using UnityEngine;

/// <summary>
/// 
/// </summary>
public class ScoreUiManager : Singleton<ScoreUiManager>
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private ScoreMenu scoreMenu;

    /// <summary>
    /// 
    /// </summary>
    public ScoreMenu ScoreMenu
    {
        get { return this.scoreMenu; }
        set { this.scoreMenu = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ReturnToMainMenu()
    {
        GameManager.Instance.SetGameState(GameState.MainMenu);
    }    
}
