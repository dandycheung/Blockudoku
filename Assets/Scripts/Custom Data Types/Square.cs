using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Square data type for the columns of game.
/// </summary>
[System.Serializable]
public class Square
{
    /// <summary>
    /// Field of the tiles of square.
    /// </summary>
    [SerializeField]
    private List<Tile> tiles = new List<Tile>();
    
    /// <summary>
    /// Property of the tiles of square.
    /// </summary>
    public List<Tile> Tiles
    {
        get { return this.tiles; }
        set { this.tiles = value; }
    }
}
