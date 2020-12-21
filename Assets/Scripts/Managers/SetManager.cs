using UnityEngine;

/// <summary>
/// Manages the set of game.
/// </summary>
public class SetManager : Singleton<SetManager>
{
    /// <summary>
    /// 难度等级：1,2,3  数值越大越难
    /// </summary>
    [Space(5f), Header("Configuration"), SerializeField , Range(1,3)]
    private int levelSet = 1;

    /// <summary>
    /// 
    /// </summary>
    public int LevelSet
    {
        get { return this.levelSet; }
        set { this.levelSet = value; }
    }
}