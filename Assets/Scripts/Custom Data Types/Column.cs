using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Custom data type for the columns of game.
/// </summary>
[System.Serializable]
public class Column
{
    /// <summary>
    /// Field of the tiles of column.
    /// </summary>
    [SerializeField]
    private List<Tile> tiles = new List<Tile>();
    
    /// <summary>
    /// Property of the tiles of column.
    /// </summary>
    public List<Tile> Tiles
    {
        get { return this.tiles; }
        set { this.tiles = value; }
    }
}
