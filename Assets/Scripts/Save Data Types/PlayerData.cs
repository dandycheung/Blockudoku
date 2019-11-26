using System;

/// <summary>
/// 
/// </summary>
[Serializable]
public class PlayerData
{
    /// <summary>
    /// 
    /// </summary>
    private int highScore;

    /// <summary>
    /// 
    /// </summary>
    public int HighScore
    {
        get { return this.highScore; }
        set
        {
            if (value >= 0)
            {
                this.highScore = value;
            }
        }
    }
}
