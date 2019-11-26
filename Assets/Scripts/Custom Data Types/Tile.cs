using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Custom data type for the tiles of the game.
/// </summary>
[System.Serializable , DisallowMultipleComponent, RequireComponent(typeof(Image))]
public class Tile : MonoBehaviour
{
    /// <summary>
    /// Field of the component of tile that is type of image.
    /// </summary>
    [Space(5f) , Header("References") , SerializeField]
    private Image imageComponent;

    /// <summary>
    /// Property of the component of tile that is type of image.
    /// </summary>
    public Image ImageComponent
    {
        get { return this.imageComponent; }
        set { this.imageComponent = value; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [Space(5f) , Header("Configuration") , SerializeField]
    private Color initialColor;

    /// <summary>
    /// 
    /// </summary>
    public Color InitialColor
    {
        get { return this.initialColor; }
        set { this.initialColor = value; }
    }

    /// <summary>
    /// Field of the color when tile is empty and raycasted.
    /// </summary>
    [SerializeField]
    private Color emptyHighlightColor;

    /// <summary>
    /// Property of the color when tile is empty and raycasted.
    /// </summary>
    public Color EmptyHighlightColor
    {
        get { return this.emptyHighlightColor; }
        set { this.emptyHighlightColor = value; }
    }

    /// <summary>
    /// Field of the color when tile is filled and raycasted.
    /// </summary>
    [SerializeField]
    private Color filledHighlightColor;

    /// <summary>
    /// Property of the color when tile is filled and raycasted.
    /// </summary>
    public Color FilledHighlightColor
    {
        get { return this.filledHighlightColor; }
        set { this.filledHighlightColor = value; }
    }
    
    /// <summary>
    /// Field of tile emptiness status.
    /// </summary>
    [SerializeField , Space(5f) , Header("Properties")]
    private bool isEmpty;

    /// <summary>
    /// Property of the field emptiness status.
    /// </summary>
    public bool IsEmpty
    {
        get { return this.isEmpty; }

        set { this.isEmpty = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private bool isHighlighted = false;

    /// <summary>
    /// 
    /// </summary>
    public bool IsHighlighted
    {
        get { return this.isHighlighted; }
        set { this.isHighlighted = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    private bool isFlagged;

    /// <summary>
    /// 
    /// </summary>
    public bool IsFlagged
    {
        get { return this.isFlagged; }
        set { this.isFlagged = value; }
    }
    
    /// <summary>
    /// Field of x coordinate value of the Tile on the Board;
    /// </summary>
    [SerializeField,Range(1,9)]
    private int xCoordinate;

    /// <summary>
    /// Property of the field x coordinate.
    /// </summary>
    public int XCoordinate
    {
        get { return this.xCoordinate; }
        
        set
        {
            if (value >= 1 && value <= 9)
            {
                this.xCoordinate = value;
            }
        }
    }

    /// <summary>
    /// Y coordinate value of the tile on the board.
    /// </summary>
    [SerializeField,Range(1,9)]
    private int yCoordinate;

    /// <summary>
    /// Property of the field y coordinate.
    /// </summary>
    public int YCoordinate
    {
        get { return this.yCoordinate; }
        set
        {
            if (value >= 1 && value <= 9)
            {
                this.yCoordinate = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void FindComponentReferences()
    {
        this.imageComponent = this.GetComponent<Image>();
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        this.FindComponentReferences();
    }
}