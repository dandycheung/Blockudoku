using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class GameOverMenu : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [Space(5f), Header("Game Over Panel References"), SerializeField]
    private GameObject gameOverPanel;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Text currentScoreTextOnGameOver;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Text highScoreTextOnGameOver;

    /// <summary>
    /// 
    /// </summary>
    public void UpdateCurrentScore()
    {
        currentScoreTextOnGameOver.text = ScoreManager.Instance.CurrentScore.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateHighScore()
    {
        this.highScoreTextOnGameOver.text = ScoreManager.Instance.HighScore.ToString();
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void Open()
    {
        gameOverPanel.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Close()
    {
        gameOverPanel.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Replay()
    {
        GameplayManager.Instance.RestartGameplay();
    }
}