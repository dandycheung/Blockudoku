using UnityEngine;
using UnityEditor;

/// <summary>
/// Creates tile in the board 9x9.
/// </summary>
public class CreateTileEditorExtension : MonoBehaviour
{
    /// <summary>
    /// Field of board 9x9.
    /// </summary>
    private static GameObject board;
    
    /// <summary>
    /// Field of last tile number of the board 9x9.
    /// </summary>
    private static int lastTileNumber = 0;

    /// <summary>
    /// Field of current tile number of the board 9x9.
    /// </summary>
    private static int tileNumber = 0;

    /// <summary>
    /// Field of x offset from center of the board.
    /// </summary>
    private static float xOffset;
    
    /// <summary>
    /// Field of y offset from center of the board.
    /// </summary>
    private static float yOffset;

    /// <summary>
    /// 
    /// </summary>
    private static float distanceBetweenTiles = 110f;
    
    /// <summary>
    /// Finds the last tile number and updates it.
    /// </summary>
    /// <returns>Integer.</returns>
    private static int FindLastTileNumber()
    {
        board = GameObject.Find("Board 9x9");
        return board.transform.childCount;
    }

    /// <summary>
    /// Sets the default values of rect transform.
    /// </summary>
    private static void SetInitialValues(GameObject tile)
    {
        RectTransform rTransform = tile.GetComponent<RectTransform>();
        rTransform.localScale = Vector3.one;
        rTransform.sizeDelta = new Vector2(105,105);
        rTransform.gameObject.AddComponent<Tile>();
        rTransform.gameObject.GetComponent<Tile>().IsEmpty = true;
    }
    
    /// <summary>
    /// Sets the tile's position according to its number.
    /// </summary>
    /// <param name="tile">Tile that will be positioned.</param>
    private static void SetTilePosition(GameObject tile)
    {
        if (tileNumber>81)
        {
            return;
        }
        
        xOffset = -440f;
        yOffset = 440f;
        int yCoordinateNumber = 1;
        int xCoordinateNumber = 1;
     
        for (int tIndex = 0; tIndex < tileNumber; tIndex++)
        {
            
            if (tIndex != 0 && tIndex % 9 == 0)
            {
                yOffset -= distanceBetweenTiles;
                xOffset = -440f;
                yCoordinateNumber += 1;
            }

            if ( (tIndex!= 0) && (tIndex % 9 ==0))
            {
                xCoordinateNumber = 1;
            }

            tile.GetComponent<Tile>().XCoordinate = xCoordinateNumber;
            tile.GetComponent<Tile>().YCoordinate = yCoordinateNumber;
            tile.transform.localPosition = Vector3.zero+new Vector3(xOffset,yOffset,0);
            xOffset += distanceBetweenTiles;
            xCoordinateNumber += 1;
        }
    }
    
    /// <summary>
    /// Adds new tile to the board 9x9.
    /// </summary>
    [MenuItem("GameObject/Blockudoku/Create Tile", false, 10)]
    public static void AddTileToBoard()
    {
        lastTileNumber = FindLastTileNumber();
        tileNumber = lastTileNumber + 1;
        GameObject tile = new GameObject("Tile " + tileNumber);
        /*GameObject tile = Instantiate(Resources.Load("Tile") as GameObject);*/
        tile.AddComponent<RectTransform>();
        tile.transform.parent = GameObject.Find("Board 9x9").transform;
        SetInitialValues(tile);
        SetTilePosition(tile);
    }

    /// <summary>
    /// Adds tiles to the board 9x9.
    /// </summary>
    [MenuItem("GameObject/Blockudoku/Create Board Tiles",false)]
    public static void FillBoardWithTiles()
    {
        for (int i = 0; i < 81; i++)
        {
            lastTileNumber = FindLastTileNumber();
            tileNumber = lastTileNumber + 1;
            GameObject tile = Instantiate(Resources.Load("Tile") as GameObject);
            tile.name = "Tile " + tileNumber;
            tile.transform.SetParent(GameObject.Find("Board 9x9").transform.GetChild(1));
            /*SetInitialValues(tile);*/
            SetTilePosition(tile);
        }
    }
}