using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/// <summary>
/// Custom data type for the boards of game.
/// </summary>
[DisallowMultipleComponent]
public class Board : MonoBehaviour, IDropHandler
{
    /// <summary>
    /// 
    /// </summary>
    private Tile[,] tiles;
    
    /// <summary>
    /// 
    /// </summary>
    public Tile[,] Tiles
    {
        get { return this.tiles; }
        set { this.tiles = value; }
    }

    /// <summary>
    /// Field of the rows of board.
    /// </summary>
    [Space(5f), Header("Configuration") , SerializeField]
    private List<Row> rows =  new List<Row>();

    /// <summary>
    /// Property of the rows of board.
    /// </summary>
    public List<Row> Rows
    {
        get { return this.rows; }
        set { this.rows = value; }
    }

    /// <summary>
    /// Field of the columns of board.
    /// </summary>
    [SerializeField]
    private List<Column> columns = new List<Column>();

    /// <summary>
    /// Property of the columns of board.
    /// </summary>
    public List<Column> Columns
    {
        get { return this.columns; }
        set { this.columns = value; }
    }
    
    /// <summary>
    /// Field of count of rows that the board has. 
    /// </summary>
    [Space(5f), Header("Properties"), SerializeField,Range(1,9)] 
    private int rowCount;

    /// <summary>
    /// Property of count of rows that the board has.
    /// </summary>
    public int RowCount
    {
        get { return this.rowCount; }
        
        private set
        {
            if (value>= 1 && value <= 9)
            {
                this.rowCount = value;
            }
        }
    }

    /// <summary>
    /// Field of count of columns that the board has.
    /// </summary>
    [SerializeField,Range(1,9)] 
    private int columnCount;

    /// <summary>
    /// Property of count of columns that the board has.
    /// </summary>
    public int ColumnCount
    {
        get { return this.columnCount; }
        
        private set
        {
            if (value>= 1 && value <= 9)
            {
                this.columnCount = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        if (BlockManager.Instance.IsBlockDroppable(Draggable.block))
        {
            BlockManager.Instance.DropBlock(Draggable.block);
            SoundManager.Instance.PlayClip("Drop");
            GameplayManager.Instance.SetGameplayState(GameplayState.OnBlockDrop);
        }
    }
}
