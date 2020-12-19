using UnityEngine;
using System.Collections;
using System.IO;
using System;

/// <summary>
/// Manages the gameplay sequence of game.
/// </summary>
public class GameplayManager : Singleton<GameplayManager>
{
    #region Fields

    /// <summary>
    /// Field of the state of gameplay status.
    /// </summary>
    [SerializeField]
    private GameplayState gameplayState;

    /// <summary>
    /// Property of the state of gameplay status.
    /// </summary>
    public GameplayState GameplayState
    {
        get { return this.gameplayState; }
        private set { this.gameplayState = value; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        GameplayManager.Instance.SetGameplayState(GameplayState.OnGameplayStart);
    }

    /// <summary>
    /// Sets the specified Gameplay State to the gameplayState field.
    /// </summary>
    /// <param name="state"></param>
    public void SetGameplayState(GameplayState state)
    {
        GameplayManager.Instance.gameplayState = state;
    }

    /// <summary>
    /// Starts the gameplay sequence.
    /// </summary>
    private IEnumerator StartGameplaySequence()
    {
        ScoreManager.Instance.CurrentScore = 0;
        BoardManager.Instance.InitializeBoard(BoardManager.Instance.AvailableBoards[0]);
        SlotManager.Instance.ClearSlots();
        yield return new WaitForSeconds(.25f);
        SlotManager.Instance.SpawnNewBlockSet();
    }

    /// <summary>
    /// 
    /// </summary>
    private void StartGameplay()
    {
        StartCoroutine(GameplayManager.Instance.StartGameplaySequence());
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (!GameManager.Instance.GameState.Equals(GameState.Gameplay)) return;
        if (this.gameplayState.Equals(GameplayState.None)) return;

        switch (GameplayManager.Instance.gameplayState)
        {
            case GameplayState.OnGameplayStart:
                if (SaveManager.Instance.IsTherePlayerData())
                {
                    SaveManager.Instance.LoadPlayerData();
                    UiManager.Instance.GameplayMenu.UpdateHighScore();
                }
                if (SaveManager.Instance.IsThereSave())
                {
                    ScoreManager.Instance.CurrentScore = 0;
                    BoardManager.Instance.InitializeBoard(BoardManager.Instance.AvailableBoards[0]);
                    SlotManager.Instance.ClearSlots();
                    SaveManager.Instance.LoadProgress();
                    SaveManager.Instance.LoadPlayerData();
                    UiManager.Instance.GameplayMenu.UpdateCurrentScore();
                    UiManager.Instance.GameplayMenu.UpdateHighScore();
                }

                GameplayManager.Instance.StartGameplay();
                GameplayManager.Instance.SetGameplayState(GameplayState.None);
                break;

            case GameplayState.OnBlockDrag:

                break;
            case GameplayState.OnBlockChange:
                if (SlotManager.Instance.AreSlotsEmpty())
                {
                    SlotManager.Instance.SpawnNewBlockSet();
                }
                GameplayManager.Instance.SetGameplayState(GameplayState.None);
                break;

            case GameplayState.OnBlockRotate:
                if (SlotManager.Instance.AreSlotsEmpty())
                {
                    SlotManager.Instance.RotateBlock();
                }
                GameplayManager.Instance.SetGameplayState(GameplayState.None);
                break;

            case GameplayState.OnBlockDrop:
                if (SlotManager.Instance.AreSlotsEmpty())
                {
                    SlotManager.Instance.SpawnNewBlockSet();
                }

                // 扫描每一行，满了添加到待清除队列中
                foreach (Row row in BoardManager.Instance.CurrentBoard.Rows)
                {
                    if (BoardManager.Instance.IsRowFilled(row))
                    {
                        TileManager.Instance.FlagTilesOfRow(row);
                        BoardManager.Instance.RowsWillBeCleared.Add(row);
                    }
                }

                // 扫描每一列，满了添加到待清除队列中
                foreach (Column column in BoardManager.Instance.CurrentBoard.Columns)
                {
                    if (BoardManager.Instance.IsColumnFilled(column))
                    {
                        TileManager.Instance.FlagTilesOfColumn(column);
                        BoardManager.Instance.ColumnsWillBeCleared.Add(column);
                    }
                }

                // 扫描每一小块正方形，满了添加到待清除队列中
                foreach (Square square in BoardManager.Instance.CurrentBoard.Squares)
                {
                    if (BoardManager.Instance.IsSquareFilled(square))
                    {
                        TileManager.Instance.FlagTilesOfSquare(square);
                        BoardManager.Instance.SquaresWillBeCleared.Add(square);
                    }
                }

                if (BoardManager.Instance.RowsWillBeCleared.Count > 0 ||
                    BoardManager.Instance.ColumnsWillBeCleared.Count > 0 ||
                    BoardManager.Instance.SquaresWillBeCleared.Count > 0)
                {
                    GameplayManager.Instance.SetGameplayState(GameplayState.OnDelete);
                    return;
                }

                GameplayManager.Instance.SetGameplayState(CheckGameState());
                break;
            case GameplayState.OnDelete:
                // 一次消除多组9个方块，成绩翻倍
                int clearBlockCount = 0;
                if (BoardManager.Instance.RowsWillBeCleared.Count > 0)
                {
                    foreach (Row row in BoardManager.Instance.RowsWillBeCleared)
                    {
                        TileManager.Instance.ClearFlaggedTilesOfRow(row);
                        clearBlockCount++;
                    }
                    BoardManager.Instance.RowsWillBeCleared.Clear();
                }

                if (BoardManager.Instance.ColumnsWillBeCleared.Count > 0)
                {
                    foreach (Column column in BoardManager.Instance.ColumnsWillBeCleared)
                    {
                        TileManager.Instance.ClearFlaggedTilesOfColumn(column);
                        clearBlockCount++;
                    }
                    BoardManager.Instance.ColumnsWillBeCleared.Clear();
                }

                if (BoardManager.Instance.SquaresWillBeCleared.Count > 0)
                {
                    foreach (Square square in BoardManager.Instance.SquaresWillBeCleared)
                    {
                        TileManager.Instance.ClearFlaggedTilesOfSquare(square);
                        clearBlockCount++;
                    }
                    BoardManager.Instance.SquaresWillBeCleared.Clear();
                }

                if (clearBlockCount > 0)
                {
                    float score = ScoreManager.Instance.LineDeleteScore * Mathf.Pow(2, clearBlockCount - 1);
                    ScoreManager.Instance.IncreseScore((int)score);
                    ScoreManager.Instance.UpdateHighScore();
                    UiManager.Instance.GameplayMenu.UpdateCurrentScore();
                    UiManager.Instance.GameplayMenu.UpdateHighScore();
                }

                GameplayManager.Instance.SetGameplayState(CheckGameState());
                break;

            case GameplayState.GameOver:
                GameplayManager.Instance.SetGameplayState(GameplayState.GameOvered);
                UiManager.Instance.GameOverMenu.Open();
                UiManager.Instance.GameOverMenu.UpdateCurrentScore();
                UiManager.Instance.GameOverMenu.UpdateHighScore();
                if (File.Exists(Application.persistentDataPath + "/save.txt"))
                {
                    File.Delete(Application.persistentDataPath + "/save.txt");
                }
                break;
            case GameplayState.ShowTips:
                break;
        }
    }

    /// <summary>
    /// 检查游戏是否结束
    /// </summary>
    /// <returns></returns>
    private GameplayState CheckGameState()
    {
        if (BlockManager.Instance.QueuedBlocks.Count > 0)
        {
            foreach (Block block in BlockManager.Instance.QueuedBlocks)
            {
                if (BlockManager.Instance.IsBlockFitsToBoard(block))
                {
                    return GameplayState.None;
                }

                // 第一次旋转90度，共计旋转90度
                BlockType rotateBlockType90 = BlockManager.Instance.GetRotatedBlockType(block.BlockType);
                if (rotateBlockType90 != block.BlockType)
                {
                    Block rotateBlock90 = BlockManager.Instance.getBlockByBlockType(rotateBlockType90);
                    if (BlockManager.Instance.IsBlockFitsToBoard(rotateBlock90))
                    {
                        return GameplayState.None;
                    }

                    // 第二次旋转90度，共计旋转180度
                    BlockType rotateBlockType180 = BlockManager.Instance.GetRotatedBlockType(block.BlockType);
                    if (rotateBlockType180 != block.BlockType)
                    {
                        Block rotateBlock180 = BlockManager.Instance.getBlockByBlockType(rotateBlockType180);
                        if (BlockManager.Instance.IsBlockFitsToBoard(rotateBlock180))
                        {
                            return GameplayState.None;
                        }

                        // 第三次旋转90度，共计旋转270度
                        BlockType rotateBlockType270 = BlockManager.Instance.GetRotatedBlockType(block.BlockType);
                        if (rotateBlockType270 != block.BlockType)
                        {
                            Block rotateBlock270 = BlockManager.Instance.getBlockByBlockType(rotateBlockType270);
                            if (BlockManager.Instance.IsBlockFitsToBoard(rotateBlock270))
                            {
                                return GameplayState.None;
                            }

                            // 第四次旋转90度，已经旋转360度，无需处理，已经转回原来位置了
                        }
                    }
                }

            }
        }
        return GameplayState.GameOver;
    }

    /// <summary>
    /// 
    /// </summary>
    public void RestartGameplay()
    {
        BoardManager.Instance.ClearBoard(BoardManager.Instance.CurrentBoard);
        SlotManager.Instance.ClearSlots();
        ScoreManager.Instance.ResetCurrentScore();
        UiManager.Instance.GameplayMenu.UpdateCurrentScore();
        GameplayManager.Instance.SetGameplayState(GameplayState.OnGameplayStart);
    }

    /// <summary>
    /// 
    /// </summary>
    public void PauseGameplay()
    {
        GameplayManager.Instance.SetGameplayState(GameplayState.Pause);
    }

    /// <summary>
    /// 
    /// </summary>
    public void ResumeGameplay()
    {
        GameplayManager.Instance.SetGameplayState(GameplayState.None);
    }

    #endregion
}