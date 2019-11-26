using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Custom data type for the rows of game.
/// </summary>
[System.Serializable]
public class Row
{
    /// <summary>
    /// Field of the tiles of row.
    /// </summary>
    [SerializeField]
    private List<Tile> tiles = new List<Tile>();

    /// <summary>
    /// Property of the tiles of game.
    /// </summary>
    public List<Tile> Tiles
    {
        get { return this.tiles; }
        set { this.tiles = value; }
    }
}