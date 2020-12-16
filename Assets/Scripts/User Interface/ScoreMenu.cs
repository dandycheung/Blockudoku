using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class ScoreMenu : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Text highScoreText;

    /// <summary>
    /// 
    /// </summary>
    public void UpdateHighScore()
    {
        this.highScoreText.text = ScoreManager.Instance.HighScore.ToString();
    }
}