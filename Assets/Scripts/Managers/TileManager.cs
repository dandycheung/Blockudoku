using UnityEngine;
using System.Collections;

/// <summary>
/// Manages the tiles of game.
/// </summary>
[DisallowMultipleComponent]
public class TileManager : Singleton<TileManager>
{ 
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float tileClearSpeed = 2.5f;

    /// <summary>
    /// 
    /// </summary>
    public float TileClearSpeed
    {
        get { return this.tileClearSpeed; }
        set { this.tileClearSpeed = value; }
    }
    
    /// <summary>
    /// Clears the specified tile.
    /// </summary>
    /// <param name="tile"></param>
    private IEnumerator ClearTile(Tile tile)
    {
        tile.IsEmpty = true;
        tile.ImageComponent.color = tile.InitialColor;
        TileManager.Instance.UnFlagTile(tile);
        if (tile.transform.childCount>0)
        {
            yield return StartCoroutine(tile.transform.GetChild(0).transform.ScaleWithLerp(
                Vector3.one, Vector3.zero,1f / TileManager.Instance.tileClearSpeed));
            Destroy(tile.transform.GetChild(0).gameObject);
        }
    }
    
    /// <summary>
    ///  
    /// </summary>
    public void SetTileAsFilled(Tile tile)
    { 
        tile.IsEmpty = false;
        TileManager.Instance.UnHighlightTile(tile);
    }
    
    /// <summary>
    /// Highlights the specified tile according to its emptiness status. 
    /// </summary>
    public void HighlightTileAsEmpty(Tile tile)
    {
        tile.IsHighlighted = true;
        tile.ImageComponent.color = tile.EmptyHighlightColor;
    }

    /// <summary>
    /// 
    /// </summary>
    public void HighlightTileAsFilled(Tile tile)
    {
        tile.IsHighlighted = true;
        tile.ImageComponent.color = tile.FilledHighlightColor;
    }
    
    /// <summary>
    /// Unhighlights the specified tile
    /// </summary>
    public void UnHighlightTile(Tile tile)
    {
        tile.IsHighlighted = false;
        tile.ImageComponent.color = tile.InitialColor;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool AreCastedTilesEmpty(Block block)
    {
        foreach (BlockPiece blockPiece in block.BlockPieces)
        {
            if (!blockPiece.IsCastedTileEmpty())
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tile"></param>
    private void FlagTile(Tile tile)
    {
        tile.IsFlagged = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tile"></param>
    private void UnFlagTile(Tile tile)
    {
        tile.IsFlagged = false;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="row"></param>
    public void FlagTilesOfRow(Row row)
    {
        foreach (Tile tile in row.Tiles)
        {
            if (!tile.IsFlagged)
            {
                TileManager.Instance.FlagTile(tile);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="column"></param>
    public void FlagTilesOfColumn(Column column)
    {
        foreach (Tile tile in column.Tiles)
        {
            if (!tile.IsFlagged)
            {
                TileManager.Instance.FlagTile(tile);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="square"></param>
    public void FlagTilesOfSquare(Square square)
    {
        foreach (Tile tile in square.Tiles)
        {
            if (!tile.IsFlagged)
            {
                TileManager.Instance.FlagTile(tile);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="row"></param>
    public void ClearFlaggedTilesOfRow(Row row)
    {
        foreach (Tile tile in row.Tiles)
        {
            this.StartCoroutine(TileManager.Instance.ClearTile(tile));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="column"></param>
    public void ClearFlaggedTilesOfColumn(Column column)
    {
        foreach (Tile tile in column.Tiles)
        {
            this.StartCoroutine(TileManager.Instance.ClearTile(tile));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="square"></param>
    public void ClearFlaggedTilesOfSquare(Square square)
    {
        foreach (Tile tile in square.Tiles)
        {
            this.StartCoroutine(TileManager.Instance.ClearTile(tile));
        }
    }
}