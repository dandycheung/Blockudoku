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
        get { return BlockManager.Instance.availableBlocks; }
        private set { BlockManager.Instance.availableBlocks = value; }
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
        Block block = Instantiate(BlockManager.Instance.availableBlocks[BlockIndex]);
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
        int RandomIndex = Random.Range(0, BlockManager.Instance.availableBlocks.Count);
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
            case BlockType.Single:
            case BlockType.Square2x2:
            case BlockType.Square3x3:
            case BlockType.Cross3x3:
                break;
            case BlockType.DoubleLine2x1ZeroDegree:
                rotatedBlockType = BlockType.DoubleLine1x2NintyDegree;
                break;
            case BlockType.DoubleLine1x2NintyDegree:
                rotatedBlockType = BlockType.DoubleLine2x1ZeroDegree;
                break;
            case BlockType.TripleLine3x1ZeroDegree:
                rotatedBlockType = BlockType.TripleLine1x3NintyDegree;
                break;
            case BlockType.TripleLine1x3NintyDegree:
                rotatedBlockType = BlockType.TripleLine3x1ZeroDegree;
                break;
            case BlockType.QuadrupleLine4x1ZeroDegree:
                rotatedBlockType = BlockType.QuadrupleLine1x4NintyDegree;
                break;
            case BlockType.QuadrupleLine1x4NintyDegree:
                rotatedBlockType = BlockType.QuadrupleLine4x1ZeroDegree;
                break;
            case BlockType.QuintetLine5x1ZeroDegree:
                rotatedBlockType = BlockType.QuintetLine1x5NintyDegree;
                break;
            case BlockType.QuintetLine1x5NintyDegree:
                rotatedBlockType = BlockType.QuintetLine5x1ZeroDegree;
                break;
            case BlockType.ShortL2x2ZeroDegree:
                rotatedBlockType = BlockType.ShortL2x2NintyDegree;
                break;
            case BlockType.ShortL2x2NintyDegree:
                rotatedBlockType = BlockType.ShortL2x2HundredAndEightyDegree;
                break;
            case BlockType.ShortL2x2HundredAndEightyDegree:
                rotatedBlockType = BlockType.ShortL2x2TwoHundredAndSeventyDegree;
                break;
            case BlockType.ShortL2x2TwoHundredAndSeventyDegree:
                rotatedBlockType = BlockType.ShortL2x2ZeroDegree;
                break;
            case BlockType.LongL3x3ZeroDegree:
                rotatedBlockType = BlockType.LongL3x3NintyDegree;
                break;
            case BlockType.LongL3x3NintyDegree:
                rotatedBlockType = BlockType.LongL3x3HundredAndEightyDegree;
                break;
            case BlockType.LongL3x3HundredAndEightyDegree:
                rotatedBlockType = BlockType.LongL3x3TwoHundredAndSeventyDegree;
                break;
            case BlockType.LongL3x3TwoHundredAndSeventyDegree:
                rotatedBlockType = BlockType.LongL3x3ZeroDegree;
                break;
            case BlockType.ShortT2x3ZeroDegree:
                rotatedBlockType = BlockType.ShortT3x2NintyDegree;
                break;
            case BlockType.ShortT3x2NintyDegree:
                rotatedBlockType = BlockType.ShortT2x3HundredAndEightyDegree;
                break;
            case BlockType.ShortT2x3HundredAndEightyDegree:
                rotatedBlockType = BlockType.ShortT3x2TwoHundredAndSeventyDegree;
                break;
            case BlockType.ShortT3x2TwoHundredAndSeventyDegree:
                rotatedBlockType = BlockType.ShortT2x3ZeroDegree;
                break;
            case BlockType.Shorth2x3ZeroDegree:
                rotatedBlockType = BlockType.Shorth3x2NintyDegree;
                break;
            case BlockType.Shorth3x2NintyDegree:
                rotatedBlockType = BlockType.Shorth2x3ZeroDegree;
                break;
            case BlockType.Shorth2x3HundredAndEightyDegree:
                rotatedBlockType = BlockType.Shorth3x2TwoHundredAndSeventyDegree;
                break;
            case BlockType.Shorth3x2TwoHundredAndSeventyDegree:
                rotatedBlockType = BlockType.Shorth2x3HundredAndEightyDegree;
                break;
            case BlockType.LongT3x3ZeroDegree:
                rotatedBlockType = BlockType.LongT3x3NintyDegree;
                break;
            case BlockType.LongT3x3NintyDegree:
                rotatedBlockType = BlockType.LongT3x3HundredAndEightyDegree;
                break;
            case BlockType.LongT3x3HundredAndEightyDegree:
                rotatedBlockType = BlockType.LongT3x3TwoHundredAndSeventyDegree;
                break;
            case BlockType.LongT3x3TwoHundredAndSeventyDegree:
                rotatedBlockType = BlockType.LongT3x3ZeroDegree;
                break;
            case BlockType.Cross2x2ZeroDegree:
                rotatedBlockType = BlockType.Cross2x2HundredAndEightyDegree;
                break;
            case BlockType.Cross2x2HundredAndEightyDegree:
                rotatedBlockType = BlockType.Cross2x2ZeroDegree;
                break;
            case BlockType.MidL3x3ZeroDegree:
                rotatedBlockType = BlockType.MidL3x3NintyDegree;
                break;
            case BlockType.MidL3x3NintyDegree:
                rotatedBlockType = BlockType.MidL3x3HundredAndEightyDegree;
                break;
            case BlockType.MidL3x3HundredAndEightyDegree:
                rotatedBlockType = BlockType.MidL3x3TwoHundredAndSeventyDegree;
                break;
            case BlockType.MidL3x3TwoHundredAndSeventyDegree:
                rotatedBlockType = BlockType.MidL3x3ZeroDegree;
                break;
            case BlockType.Mid2L3x3ZeroDegree:
                rotatedBlockType = BlockType.Mid2L3x3NintyDegree;
                break;
            case BlockType.Mid2L3x3NintyDegree:
                rotatedBlockType = BlockType.Mid2L3x3HundredAndEightyDegree;
                break;
            case BlockType.Mid2L3x3HundredAndEightyDegree:
                rotatedBlockType = BlockType.Mid2L3x3TwoHundredAndSeventyDegree;
                break;
            case BlockType.Mid2L3x3TwoHundredAndSeventyDegree:
                rotatedBlockType = BlockType.Mid2L3x3ZeroDegree;
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
        foreach (Block block in BlockManager.Instance.AvailableBlocks)
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