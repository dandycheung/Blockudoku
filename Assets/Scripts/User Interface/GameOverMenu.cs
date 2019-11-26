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
    public void UpdateCurrentScoreOnGameover()
    {
        currentScoreTextOnGameOver.text = ScoreManager.Instance.CurrentScore.ToString();
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