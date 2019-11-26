using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
[DisallowMultipleComponent]
public class BoardManager : Singleton<BoardManager>
{
    #region Fields

    /// <summary>
    /// Field of the boards of game.
    /// </summary>
    [SerializeField]
    private List<Board> availableBoards;

    /// <summary>
    /// Property of the boards of game.
    /// </summary>
    public List<Board> AvailableBoards
    {
        get { return this.availableBoards; }
        set { this.availableBoards = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Board currentBoard;

    /// <summary>
    /// 
    /// </summary>
    public Board CurrentBoard
    {
        get { return this.currentBoard; }
        set { this.currentBoard = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private List<Row> rowsWillBeCleared = new List<Row>();

    /// <summary>
    /// 
    /// </summary>
    public List<Row> RowsWillBeCleared
    {
        get { return this.rowsWillBeCleared; }
        set { this.rowsWillBeCleared = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private List<Column> columnsWillBeCleared = new List<Column>();

    /// <summary>
    /// 
    /// </summary>
    public List<Column> ColumnsWillBeCleared
    {
        get { return this.columnsWillBeCleared; }
        set { this.columnsWillBeCleared = value; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="board"></param>
    private void SetCurrentBoard(Board board)
    {
        BoardManager.Instance.currentBoard = board;
    }

    /// <summary>
    /// 
    /// </summary>
    public void InitializeBoard(Board board)
    {
        BoardManager.Instance.SetCurrentBoard(board);
        BoardManager.Instance.SetBoardSize(BoardManager.Instance.currentBoard);
        BoardManager.Instance.FindTiles(BoardManager.Instance.currentBoard);
        BoardManager.Instance.FindRows(BoardManager.Instance.currentBoard);
        BoardManager.Instance.FindColumns(BoardManager.Instance.currentBoard);
        board.gameObject.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="board"></param>
    private void FindTiles(Board board)
    {
        board.Tiles =new Tile[board.ColumnCount,board.RowCount];
        foreach (Transform tileTransform in BoardManager.Instance.CurrentBoard.transform.GetChild(1).transform)
        {
            Tile tile  = tileTransform.GetComponent<Tile>();
            board.Tiles[tile.YCoordinate-1, tile.XCoordinate-1] = tile;
        }
    }

    /// <summary>
    /// Creates a row with the specified row X Coordinate number,
    /// finds the tiles of the row and adds them to the row.
    /// </summary>
    /// <param name="RowNumber">X coordinate number of the row.</param>
    /// <returns>Row.</returns>
    private Row FindRow(int RowNumber)
    {
        Row row = new Row();
        foreach (Tile tile in BoardManager.Instance.CurrentBoard.Tiles)
        {
            if (!tile.YCoordinate.Equals(RowNumber))
            {
                continue;
            }
            row.Tiles.Add(tile);
        }
        return row;
    }

    /// <summary>
    /// Creates a column with the specified column Y Coordinate number,
    /// finds the tiles of the column and adds them to the column.
    /// </summary>
    /// <param name="ColumnNumber">Y coordinate number of the column.</param>
    /// <returns>Column.</returns>
    private Column FindColumn(int ColumnNumber)
    {
        Column column = new Column();
        foreach (Tile tile in BoardManager.Instance.CurrentBoard.Tiles)
        {
            if (!tile.XCoordinate.Equals(ColumnNumber))
            {
                continue;
            }
            column.Tiles.Add(tile);
        }
        return column;
    }

    /// <summary>
    /// Finds the rows of the board and adds them to the board.
    /// </summary>
    private void FindRows(Board board)
    {
        for (int rowNumber = 1; rowNumber <= board.RowCount; rowNumber++)
        {
            board.Rows.Add(BoardManager.Instance.FindRow(rowNumber));
        }
    }

    /// <summary>
    /// Finds the columns of the board and adds them to the columns which is type of List.
    /// </summary>
    private void FindColumns(Board board)
    {
        for (int columnNumber = 1; columnNumber <= board.RowCount; columnNumber++)
        {
            board.Columns.Add(BoardManager.Instance.FindColumn(columnNumber));
        }
    }

    /// <summary>
    /// Checks whether the row filled or not.
    /// </summary>
    /// <param name="column">Column that will be checked.</param>
    public bool IsColumnFilled(Column column)
    {
        int filledTileCount = 0;
        foreach (Tile tile in column.Tiles)
        {
            if (!tile.IsEmpty)
            {
                filledTileCount++;
            }
        }
        if (filledTileCount == 9)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks whether the row filled or not.
    /// </summary>
    /// <param name="row">Row that will be checked.</param>
    public bool IsRowFilled(Row row)
    {
        int filledTileCount = 0;
        foreach (Tile tile in row.Tiles)
        {
            if (!tile.IsEmpty)
            {
                filledTileCount++;
            }
        }
        if (filledTileCount == 9)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="board"></param>
    private void SetBoardSize(Board board)
    {
        board.Tiles = new Tile[board.RowCount, board.ColumnCount];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="board"></param>
    public void ClearBoard(Board board)
    {
        foreach (Tile tile in board.Tiles)
        {
            if (tile.transform.childCount > 0)
            {
                Destroy(tile.transform.GetChild(0).gameObject);
            }
            tile.IsEmpty = true;
            TileManager.Instance.UnHighlightTile(tile);
        }
    }

    #endregion
}