using UnityEngine;

/// <summary>
/// Manages the scores of game.
/// </summary>
public class ScoreManager : Singleton<ScoreManager>
{
    /// <summary>
    /// 
    /// </summary>
    [Space(5f), Header("Configuration"), SerializeField , Range(1,100)]
    private int blockDropScore = 10;

    /// <summary>
    /// 
    /// </summary>
    public int BlockDropScore
    {
        get { return this.blockDropScore; }
        set { this.blockDropScore = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField,Range(1,250)]
    private int lineDeleteScore = 100;

    /// <summary>
    /// 
    /// </summary>
    public int LineDeleteScore
    {
        get { return this.lineDeleteScore; }
        set { this.lineDeleteScore = value; }
    }

    /// <summary>
    /// Field of the score of game.
    /// </summary>
    [Space(5f), Header("Properties"), SerializeField]
    private int currentScore = 0;
    
    /// <summary>
    /// Property of the score of game.
    /// </summary>
    public int CurrentScore
    {
        get { return this.currentScore; }
        set
        {
            if (value >= 0 )
            {
                this.currentScore = value;
            }
            else
            {
                this.currentScore = 0;
            }
        }
    }

    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private int highScore = 0;

    public int HighScore
    {
        get { return this.highScore; }
        set
        {
            if (value >= 0)
            {
                this.highScore = value;
            }
            else
            {
                this.highScore = 0;
            }
        }
    }
    
    /// <summary>
    /// Increases the score with the specified amount.
    /// </summary>
    /// <param name="ScoreIncrement"></param>
    public void IncreseScore(int ScoreIncrement)
    {
        this.currentScore += ScoreIncrement;
    }

    /// <summary>
    /// Decrease the score with the specified amount.
    /// </summary>
    /// <param name="ScoreIncrement"></param>
    public void DecreaseScore(int ScoreDecrease)
    {
        this.currentScore -= ScoreDecrease;
    }


    /// <summary>
    /// 
    /// </summary>
    public void ResetCurrentScore()
    {
        ScoreManager.Instance.currentScore = 0;
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateHighScore()
    {
        if (ScoreManager.Instance.currentScore > ScoreManager.Instance.highScore)
        {
            ScoreManager.Instance.highScore = ScoreManager.Instance.currentScore;
        }
    }
}