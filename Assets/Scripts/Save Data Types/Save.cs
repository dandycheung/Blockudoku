using System;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
[Serializable]
public class Save
{
    /// <summary>
    /// 
    /// </summary>
    private int currentScore;

    /// <summary>
    /// 
    /// </summary>
    public int CurrentScore
    {
        get { return this.currentScore; }
        set { this.currentScore = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    private Tile_Save[,] tiles = new Tile_Save[9,9];

    /// <summary>
    /// 
    /// </summary>
    public Tile_Save[,] Tiles
    {
        get { return this.tiles; }
        set { this.tiles = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    private List<Slot_Save> slots = new List<Slot_Save>();

    /// <summary>
    /// 
    /// </summary>
    public List<Slot_Save> Slots
    {
        get { return this.slots; }
        set { this.slots = value; }
    }
}
