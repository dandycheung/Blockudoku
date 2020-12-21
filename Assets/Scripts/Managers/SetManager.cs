using UnityEngine;

/// <summary>
/// Manages the set of game.
/// </summary>
public class SetManager : Singleton<SetManager>
{
    /// <summary>
    /// �Ѷȵȼ���1,2,3  ��ֵԽ��Խ��
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