using UnityEngine;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Manages the blocks of game.
/// </summary>
[DisallowMultipleComponent]
public class BlockManager : Singleton<BlockManager>
{
    #region Fields

    /// <summary>
    /// Field of the available blocks of game.
    /// </summary>
    [Space(5f), Header("Properties"), SerializeField]
    private List<Block> availableBlocks = new List<Block>();

    /// <summary>
    /// Property of the available blocks of game.
    /// </summary>
    public List<Block> AvailableBlocks
    {
        get {
            return BlockManager.Instance.availableBlocks; 
        }
        private set { BlockManager.Instance.availableBlocks = value; }
    }

    /// <summary>
    /// Field of the available blocks of game.
    /// </summary>
    [Space(5f), Header("Properties"), SerializeField]
    private List<Block> curAvailableBlocks = new List<Block>();

    /// <summary>
    /// Property of the cur available blocks of game.
    /// </summary>
    public List<Block> CurAvailableBlocks
    {
        get { return BlockManager.Instance.curAvailableBlocks; }
        private set { BlockManager.Instance.curAvailableBlocks = value; }
    }

    /// <summary>
    /// Field of the level easy blocks of game.
    /// </summary>
    [Space(5f), Header("Properties"), SerializeField]
    private List<Block> levelEasyBlocks = new List<Block>();

    /// <summary>
    /// Property of the available blocks of game.
    /// </summary>
    public List<Block> LevelEasyBlocks
    {
        get { return BlockManager.Instance.levelEasyBlocks; }
        private set { BlockManager.Instance.levelEasyBlocks = value; }
    }

    /// <summary>
    /// Field of the level normal blocks of game.
    /// </summary>
    [Space(5f), Header("Properties"), SerializeField]
    private List<Block> levelNormalBlocks = new List<Block>();

    /// <summary>
    /// Property of the available blocks of game.
    /// </summary>
    public List<Block> LevelNormalBlocks
    {
        get { return BlockManager.Instance.levelNormalBlocks; }
        private set { BlockManager.Instance.levelNormalBlocks = value; }
    }

    internal void InitSet()
    {
        if (SetManager.Instance.LevelSet == 1)
        {
            BlockManager.Instance.curAvailableBlocks = BlockManager.Instance.levelEasyBlocks;
        }
        if (SetManager.Instance.LevelSet == 2)
        {
            BlockManager.Instance.curAvailableBlocks = BlockManager.Instance.levelNormalBlocks;
        }
        if (SetManager.Instance.LevelSet == 3)
        {
            BlockManager.Instance.curAvailableBlocks = BlockManager.Instance.AvailableBlocks;
        }
    }

    /// <summary>
    /// Field of the list of queued blocks.
    /// </summary>
    [SerializeField]
    private List<Block> queuedBlocks = new List<Block>();

    /// <summary>
    /// Property of the list of queued blocks.
    /// </summary>
    public List<Block> QueuedBlocks
    {
        get { return BlockManager.Instance.queuedBlocks; }
        private set { BlockManager.Instance.queuedBlocks = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField, Range(1f,10f)]
    private float alignSpeed = 5f;

    /// <summary>
    /// 
    /// </summary>
    public float AlignSpeed
    {
        get { return this.alignSpeed; }
        set { this.alignSpeed = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    private BlockType curClickBlockType = 0;

    /// <summary>
    /// 
    /// </summary>
    public BlockType CurClickBlockType
    {
        get { return this.curClickBlockType; }
        set { this.curClickBlockType = value; }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Gets a block with the index and returns it.
    /// </summary>
    /// <param name="BlockIndex">Index of the block in blocks.</param>
    /// <returns>Block.</returns>
    private Block GetBlock(int BlockIndex)
    {
        Block block = Instantiate(BlockManager.Instance.curAvailableBlocks[BlockIndex]);
        return block;
    }

    /// <summary>
    /// Gets a block with the index and returns it.
    /// </summary>
    /// <param name="BlockIndex">Index of the block in blocks.</param>
    /// <returns>Block.</returns>
    private Block GetBlock(Block b)
    {
        Block block = Instantiate(b);
        return block;

    }

    /// <summary>
    /// Gets a random block and returns it.
    /// </summary>
    /// <returns>Block.</returns>
    public Block GetRandomBlock()
    {
        // 根据难度等级，分别从对应的数组中随机补充方块
        int RandomIndex = Random.Range(0, BlockManager.Instance.CurAvailableBlocks.Count);
        // RandomIndex = 12;
        return BlockManager.Instance.GetBlock(RandomIndex);
    }

    /// <summary>
    /// Gets a rotate block type and returns it.
    /// </summary>
    /// <returns>BlockType.</returns>
    public BlockType GetRotatedBlockType(BlockType curBlockType)
    {
        BlockType rotatedBlockType = curBlockType;

        switch (curBlockType)
        {
            case BlockType.Z1T01:
            case BlockType.Z4T07:
            case BlockType.Z5T17:
            case BlockType.Z5T14:
                break;
            case BlockType.Z2T01A0:
                rotatedBlockType = BlockType.Z2T01A90;
                break;
            case BlockType.Z2T01A90:
                rotatedBlockType = BlockType.Z2T01A0;
                break;
            case BlockType.Z3T01A0:
                rotatedBlockType = BlockType.Z3T01A90;
                break;
            case BlockType.Z3T01A90:
                rotatedBlockType = BlockType.Z3T01A0;
                break;
            case BlockType.Z4T01A0:
                rotatedBlockType = BlockType.Z4T01A90;
                break;
            case BlockType.Z4T01A90:
                rotatedBlockType = BlockType.Z4T01A0;
                break;
            case BlockType.Z5T01A0:
                rotatedBlockType = BlockType.Z5T01A90;
                break;
            case BlockType.Z5T01A90:
                rotatedBlockType = BlockType.Z5T01A0;
                break;
            case BlockType.Z3T02A0:
                rotatedBlockType = BlockType.Z3T02A90;
                break;
            case BlockType.Z3T02A90:
                rotatedBlockType = BlockType.Z3T02A180;
                break;
            case BlockType.Z3T02A180:
                rotatedBlockType = BlockType.Z3T02A270;
                break;
            case BlockType.Z3T02A270:
                rotatedBlockType = BlockType.Z3T02A0;
                break;
            case BlockType.Z5T16A0:
                rotatedBlockType = BlockType.Z5T16A90;
                break;
            case BlockType.Z5T16A90:
                rotatedBlockType = BlockType.Z5T16A180;
                break;
            case BlockType.Z5T16A180:
                rotatedBlockType = BlockType.Z5T16A270;
                break;
            case BlockType.Z5T16A270:
                rotatedBlockType = BlockType.Z5T16A0;
                break;
            case BlockType.Z4T03A0:
                rotatedBlockType = BlockType.Z4T03A90;
                break;
            case BlockType.Z4T03A90:
                rotatedBlockType = BlockType.Z4T03A180;
                break;
            case BlockType.Z4T03A180:
                rotatedBlockType = BlockType.Z4T03A270;
                break;
            case BlockType.Z4T03A270:
                rotatedBlockType = BlockType.Z4T03A0;
                break;
            case BlockType.Z4T05A0:
                rotatedBlockType = BlockType.Z4T05A90;
                break;
            case BlockType.Z4T05A90:
                rotatedBlockType = BlockType.Z4T05A0;
                break;
            case BlockType.Z4T06A0:
                rotatedBlockType = BlockType.Z4T06A90;
                break;
            case BlockType.Z4T06A90:
                rotatedBlockType = BlockType.Z4T06A0;
                break;
            case BlockType.Z5T09A0:
                rotatedBlockType = BlockType.Z5T09A90;
                break;
            case BlockType.Z5T09A90:
                rotatedBlockType = BlockType.Z5T09A180;
                break;
            case BlockType.Z5T09A180:
                rotatedBlockType = BlockType.Z5T09A270;
                break;
            case BlockType.Z5T09A270:
                rotatedBlockType = BlockType.Z5T09A0;
                break;
            case BlockType.Z2T02A0:
                rotatedBlockType = BlockType.Z2T02A90;
                break;
            case BlockType.Z2T02A90:
                rotatedBlockType = BlockType.Z2T02A0;
                break;
            case BlockType.Z4T04A0:
                rotatedBlockType = BlockType.Z4T04A90;
                break;
            case BlockType.Z4T04A90:
                rotatedBlockType = BlockType.Z4T04A180;
                break;
            case BlockType.Z4T04A180:
                rotatedBlockType = BlockType.Z4T04A270;
                break;
            case BlockType.Z4T04A270:
                rotatedBlockType = BlockType.Z4T04A0;
                break;
            case BlockType.Z4T02A0:
                rotatedBlockType = BlockType.Z4T02A90;
                break;
            case BlockType.Z4T02A90:
                rotatedBlockType = BlockType.Z4T02A180;
                break;
            case BlockType.Z4T02A180:
                rotatedBlockType = BlockType.Z4T02A270;
                break;
            case BlockType.Z4T02A270:
                rotatedBlockType = BlockType.Z4T02A0;
                break;
            case BlockType.Z5T02A0:
                rotatedBlockType = BlockType.Z5T02A90;
                break;
            case BlockType.Z5T02A90:
                rotatedBlockType = BlockType.Z5T02A180;
                break;
            case BlockType.Z5T02A180:
                rotatedBlockType = BlockType.Z5T02A270;
                break;
            case BlockType.Z5T02A270:
                rotatedBlockType = BlockType.Z5T02A0;
                break;
            case BlockType.Z5T03A0:
                rotatedBlockType = BlockType.Z5T03A90;
                break;
            case BlockType.Z5T03A90:
                rotatedBlockType = BlockType.Z5T03A180;
                break;
            case BlockType.Z5T03A180:
                rotatedBlockType = BlockType.Z5T03A270;
                break;
            case BlockType.Z5T03A270:
                rotatedBlockType = BlockType.Z5T03A0;
                break;
            case BlockType.Z5T04A0:
                rotatedBlockType = BlockType.Z5T04A90;
                break;
            case BlockType.Z5T04A90:
                rotatedBlockType = BlockType.Z5T04A180;
                break;
            case BlockType.Z5T04A180:
                rotatedBlockType = BlockType.Z5T04A270;
                break;
            case BlockType.Z5T04A270:
                rotatedBlockType = BlockType.Z5T04A0;
                break;
            case BlockType.Z5T05A0:
                rotatedBlockType = BlockType.Z5T05A90;
                break;
            case BlockType.Z5T05A90:
                rotatedBlockType = BlockType.Z5T05A180;
                break;
            case BlockType.Z5T05A180:
                rotatedBlockType = BlockType.Z5T05A270;
                break;
            case BlockType.Z5T05A270:
                rotatedBlockType = BlockType.Z5T05A0;
                break;
            case BlockType.Z5T06A0:
                rotatedBlockType = BlockType.Z5T06A90;
                break;
            case BlockType.Z5T06A90:
                rotatedBlockType = BlockType.Z5T06A180;
                break;
            case BlockType.Z5T06A180:
                rotatedBlockType = BlockType.Z5T06A270;
                break;
            case BlockType.Z5T06A270:
                rotatedBlockType = BlockType.Z5T06A0;
                break;
            case BlockType.Z5T07A0:
                rotatedBlockType = BlockType.Z5T07A90;
                break;
            case BlockType.Z5T07A90:
                rotatedBlockType = BlockType.Z5T07A180;
                break;
            case BlockType.Z5T07A180:
                rotatedBlockType = BlockType.Z5T07A270;
                break;
            case BlockType.Z5T07A270:
                rotatedBlockType = BlockType.Z5T07A0;
                break;
            case BlockType.Z5T08A0:
                rotatedBlockType = BlockType.Z5T08A90;
                break;
            case BlockType.Z5T08A90:
                rotatedBlockType = BlockType.Z5T08A180;
                break;
            case BlockType.Z5T08A180:
                rotatedBlockType = BlockType.Z5T08A270;
                break;
            case BlockType.Z5T08A270:
                rotatedBlockType = BlockType.Z5T08A0;
                break;
            case BlockType.Z5T10A0:
                rotatedBlockType = BlockType.Z5T10A90;
                break;
            case BlockType.Z5T10A90:
                rotatedBlockType = BlockType.Z5T10A180;
                break;
            case BlockType.Z5T10A180:
                rotatedBlockType = BlockType.Z5T10A270;
                break;
            case BlockType.Z5T10A270:
                rotatedBlockType = BlockType.Z5T10A0;
                break;
            case BlockType.Z5T11A0:
                rotatedBlockType = BlockType.Z5T11A90;
                break;
            case BlockType.Z5T11A90:
                rotatedBlockType = BlockType.Z5T11A0;
                break;
            case BlockType.Z5T12A0:
                rotatedBlockType = BlockType.Z5T12A90;
                break;
            case BlockType.Z5T12A90:
                rotatedBlockType = BlockType.Z5T12A0;
                break;
            case BlockType.Z5T13A0:
                rotatedBlockType = BlockType.Z5T13A90;
                break;
            case BlockType.Z5T13A90:
                rotatedBlockType = BlockType.Z5T13A180;
                break;
            case BlockType.Z5T13A180:
                rotatedBlockType = BlockType.Z5T13A270;
                break;
            case BlockType.Z5T13A270:
                rotatedBlockType = BlockType.Z5T13A0;
                break;
            case BlockType.Z5T15A0:
                rotatedBlockType = BlockType.Z5T15A90;
                break;
            case BlockType.Z5T15A90:
                rotatedBlockType = BlockType.Z5T15A180;
                break;
            case BlockType.Z5T15A180:
                rotatedBlockType = BlockType.Z5T15A270;
                break;
            case BlockType.Z5T15A270:
                rotatedBlockType = BlockType.Z5T15A0;
                break;
            case BlockType.Z5T18A0:
                rotatedBlockType = BlockType.Z5T18A90;
                break;
            case BlockType.Z5T18A90:
                rotatedBlockType = BlockType.Z5T18A180;
                break;
            case BlockType.Z5T18A180:
                rotatedBlockType = BlockType.Z5T18A270;
                break;
            case BlockType.Z5T18A270:
                rotatedBlockType = BlockType.Z5T18A0;
                break;
            case BlockType.Z5T19A0:
                rotatedBlockType = BlockType.Z5T19A90;
                break;
            case BlockType.Z5T19A90:
                rotatedBlockType = BlockType.Z5T19A180;
                break;
            case BlockType.Z5T19A180:
                rotatedBlockType = BlockType.Z5T19A270;
                break;
            case BlockType.Z5T19A270:
                rotatedBlockType = BlockType.Z5T19A0;
                break;
        }

        return rotatedBlockType;
    }

    /// <summary>
    /// 根据BlockType获取Block
    /// </summary>
    /// <param name="blockType"></param>
    /// <returns></returns>
    public Block getBlockByBlockType(BlockType blockType)
    {
        foreach (Block block in BlockManager.Instance.CurAvailableBlocks)
        {
            if (block.BlockType.Equals(blockType))
            {
                return GetBlock(block);
            }
        }
        // 不应该会执行到这里，属于异常情况
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Gets a rotate block and returns it.
    /// </summary>
    /// <returns>Block.</returns>
    public Block GetCurClickRotatedBlock()
    {
        BlockType rotatedBlockType = GetRotatedBlockType(curClickBlockType);
        return getBlockByBlockType(rotatedBlockType);
    }

    /// <summary>
    /// Spawns new block set according to slot count;
    /// </summary>
    public void SpawnNewBlockSet()
    {
        foreach (Slot slot in SlotManager.Instance.Slots)
        {
            Block block = BlockManager.Instance.GetRandomBlock();
            block.transform.SetParent(slot.transform);
            BlockManager.Instance.SetInitialTransformValues(block);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="block"></param>
    private void AlignBlock(Block block)
    {
        foreach (BlockPiece blockPiece in block.BlockPieces)
        {
            blockPiece.GetComponent<BlockPiece>().SetParentAsCastedTile();
            blockPiece.AlignToTile();
            TileManager.Instance.SetTileAsFilled(blockPiece.CastedTile);
            blockPiece.ImageComponent.color = blockPiece.InitialColor;
        }
    }

    /// <summary>
    /// 更换Block
    /// </summary>
    /// <param name="oldBlock"></param>
    /// <param name="newBlock"></param>
    public void ChangeBlock(Block block)
    {
        if (ScoreManager.Instance.CurrentScore > ScoreManager.Instance.LineDeleteScore)
        {
            SlotManager.Instance.FindSlotOfBlock(block).IsEmpty = true;
            ScoreManager.Instance.DecreaseScore(ScoreManager.Instance.LineDeleteScore);
            UiManager.Instance.GameplayMenu.UpdateCurrentScore();
            BlockManager.Instance.queuedBlocks.Remove(block);
            SlotManager.Instance.FindSlotOfBlock(block).gameObject.SetActive(false);
            Destroy(Draggable.block.gameObject);

            SoundManager.Instance.PlayClip("Drop");
            GameplayManager.Instance.SetGameplayState(GameplayState.OnBlockChange);
        }
        else
        {
            // 提示成绩不足，不能消除
            UiManager.Instance.TipsMenu.Open();
        }
    }

    /// <summary>
    /// 更换Block
    /// </summary>
    /// <param name="oldBlock"></param>
    /// <param name="newBlock"></param>
    public void RotateBlock(Block block)
    {
        BlockType rotatedBlockType = GetRotatedBlockType(block.BlockType);
        if (rotatedBlockType != block.BlockType)
        {
            // 如果当前方块旋转有区别，先从槽中删除，然后再生成一个旋转后的方块放入
            curClickBlockType = block.BlockType;
            SlotManager.Instance.FindSlotOfBlock(block).IsEmpty = true;
            BlockManager.Instance.queuedBlocks.Remove(block);
            SlotManager.Instance.FindSlotOfBlock(block).gameObject.SetActive(false);
            Destroy(Draggable.block.gameObject);
            SoundManager.Instance.PlayClip("Drop");

            // 异步执行生成旋转后图形放入空槽
            GameplayManager.Instance.SetGameplayState(GameplayState.OnBlockRotate);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="block"></param>
    public void DropBlock(Block block)
    {
        SlotManager.Instance.FindSlotOfBlock(block).IsEmpty = true;
        ScoreManager.Instance.IncreseScore(ScoreManager.Instance.BlockDropScore);
        ScoreManager.Instance.UpdateHighScore();
        UiManager.Instance.GameplayMenu.UpdateCurrentScore();
        UiManager.Instance.GameplayMenu.UpdateHighScore();
        BlockManager.Instance.queuedBlocks.Remove(block);
        BlockManager.Instance.AlignBlock(block);
        SlotManager.Instance.FindSlotOfBlock(block).gameObject.SetActive(false);
        Destroy(Draggable.block.gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<BlockPiece> GetBlockPieces(Block block)
    {
        List<BlockPiece> blockPieces = new List<BlockPiece>();
        foreach (Transform childTransform in block.transform)
        {
            blockPieces.Add(childTransform.GetComponent<BlockPiece>());
        }

        return blockPieces;
    }

    /// <summary>
    /// Adds rect transform to the gameObject and sets its initial values.
    /// </summary>
    public void SetInitialTransformValues(Block block)
    {
        block.RectTransform.localScale = Vector3.one;
        block.RectTransform.localPosition = Vector3.zero;
        block.RectTransform.sizeDelta = new Vector2(250, 250);
        block.ScaledSize = new Vector3(2,2,1);
        block.Offset = BlockManager.Instance.EvaluateOffset(block);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool AreBlockPiecesCastToTile(Block block)
    {
        foreach (BlockPiece blockPiece in block.BlockPieces)
        {
            if (!blockPiece.IsCastsToTile())
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 是否可以放入面板
    /// </summary>
    /// <returns></returns>
    public bool IsBlockDroppable(Block block)
    {
        if (BlockManager.Instance.AreBlockPiecesCastToTile(block))
        {
            foreach (BlockPiece blockPiece in block.BlockPieces)
            {
                if (!blockPiece.CastedTile.IsEmpty)
                {
                    return false;
                }
            }

            if (!block.RectTransform.localScale.Equals(block.ScaledSize))
            {
                return false;
            }

            if (!BlockManager.Instance.AreCastedTilesUnique(block))
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Scales block up with lerp.
    /// </summary>
    /// <param name="block"></param>
    /// <param name="duration"></param>
    public void ScaleBlockUp(Block block, float duration)
    {
        StartCoroutine(block.transform.ScaleWithLerp(Vector3.one, block.ScaledSize, duration));
    }

    /// <summary>
    /// Scales block down with lerp. 
    /// </summary>
    /// <param name="block"></param>
    /// <param name="duration"></param>
    public void ScaleBlockDown(Block block, float duration)
    {
        StartCoroutine(block.transform.ScaleWithLerp(block.ScaledSize, Vector3.one, duration));
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetChildPositions(Block block)
    {
        block.ChildPositions = BlockInformations.GetChildPositionData(block.BlockType);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="block"></param>
    public bool AreCastedTilesUnique(Block block)
    {
        List<Tile> castedTiles = new List<Tile>();
        foreach (BlockPiece blockPiece in block.BlockPieces)
        {
            castedTiles.Add(blockPiece.CastedTile);
        }
        return castedTiles.Count == castedTiles.Distinct().Count();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="block"></param>
    /// <returns></returns>
    private Vector3 EvaluateOffset(Block block)
    {
        return new Vector3(0,((block.YTileCount / 2f) * 55f) + 27.5f,0);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="block"></param>
    /// <returns></returns>
    public bool IsBlockFitsToBoard(Block block)
    {
        for (int row = 0; row <= ( BoardManager.Instance.CurrentBoard.RowCount - block.YTileCount); row++)
        {
            for (int column = 0; column <= (BoardManager.Instance.CurrentBoard.ColumnCount-block.XTileCount); column++)
            {
                bool IsFit = true;
                for (int blockRow = 0; blockRow < block.YTileCount; blockRow++)
                {
                    for (int blockColumn = 0; blockColumn < block.XTileCount; blockColumn++)
                    {
                        if (BoardManager.Instance.CurrentBoard.Tiles[row + blockRow, column + blockColumn].IsEmpty ||
                            !block.ChildPositions[blockRow, blockColumn]) continue;
                        IsFit = false;
                    }
                }
                if (IsFit)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    #endregion
}