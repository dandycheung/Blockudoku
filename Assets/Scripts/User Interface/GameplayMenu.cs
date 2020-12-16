using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the Ui of the game.
/// </summary>
[DisallowMultipleComponent]
public class GameplayMenu : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Text currentScoreText;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Text highScoreText;

    /// <summary>
    /// 
    /// </summary>
    public void UpdateCurrentScore()
    {
        this.currentScoreText.text = ScoreManager.Instance.CurrentScore.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateHighScore()
    {
        this.highScoreText.text = ScoreManager.Instance.HighScore.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Replay()
    {
        GameplayManager.Instance.RestartGameplay();
    }
}