using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Custom data type for the Blocks of game.
/// </summary>
[DisallowMultipleComponent, RequireComponent(typeof(Draggable),typeof(CanvasGroup))]
public class Block : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// Field of RectTransform component of the block.
    /// </summary>
    [Space(5f), Header("References"), SerializeField]
    private RectTransform rectTransform;

    /// <summary>
    /// Property of RectTransform component of the block.
    /// </summary>
    public RectTransform RectTransform
    {
        get { return this.rectTransform; }
        set { this.rectTransform = value; }
    }

    /// <summary>
    /// Field of the transform of slot of block.
    /// </summary>
    [SerializeField]
    private Transform startParent;

    /// <summary>
    /// Property of the transform of slot of block.
    /// </summary>
    public Transform StartParent
    {
        get { return this.startParent; }
        set { this.startParent = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private List<BlockPiece> blockPieces = new List<BlockPiece>();

    /// <summary>
    /// 
    /// </summary>
    public List<BlockPiece> BlockPieces
    {
        get { return this.blockPieces; }
        set { this.blockPieces = value; }
    }
    
    /// <summary>
    /// Field of the speed of duration when scaling.
    /// </summary>
    [Space(5f), Header("Configuration"), SerializeField, Range(1f, 10f)]
    private float scaleSpeed = 7.5f;

    /// <summary>
    /// Property of the speed of duration when scaling.
    /// </summary>
    public float ScaleSpeed
    {
        get { return this.scaleSpeed; }
        set { this.scaleSpeed = value; }
    }

    /// <summary>
    /// Field of the speed of duration when positioning.
    /// </summary>
    [SerializeField, Range(1f, 10f)]
    private float positioningSpeed = 5f;

    /// <summary>
    /// Property of the speed of duration when positioning.
    /// </summary>
    public float PositioningSpeed
    {
        get { return this.positioningSpeed; }
        set { this.positioningSpeed = value; }
    }

    /// <summary>
    /// Field of tile count on the x coordinate the block.
    /// </summary>
    [SerializeField, Range(1, 5)]
    private int xTileCount;

    /// <summary>
    /// Property of tile count on the x coordinate the block.
    /// </summary>
    public int XTileCount
    {
        get { return this.xTileCount; }
        set { this.xTileCount = value; }
    }

    /// <summary>
    /// Field of tile count on the y coordinate the block.
    /// </summary>
    [SerializeField, Range(1, 5)]
    private int yTileCount;

    /// <summary>
    /// Property of tile count on the y coordinate the block.
    /// </summary>
    public int YTileCount
    {
        get { return this.yTileCount; }
        set { this.yTileCount = value; }
    }

    /// <summary>
    /// Field of the positions of the child blocks.
    /// </summary>
    [SerializeField]
    private bool[,] childPositions;

    /// <summary>
    /// Property of the positions of the child blocks.
    /// </summary>
    public bool[,] ChildPositions
    {
        get { return this.childPositions; }
        set { this.childPositions = value; }
    }

    /// <summary>
    /// Field of the type of block.
    /// </summary>
    [Space(5f), Header("Properties"), SerializeField]
    private BlockType blockType;

    /// <summary>
    /// Property of the type of block.
    /// </summary>
    public BlockType BlockType
    {
        get { return this.blockType; }
        private set { this.blockType = value; }
    }

    /// <summary>
    /// Field of the original size of block.
    /// </summary>
    [SerializeField]
    private Vector3 scaledSize = new Vector3(2, 2, 1);

    /// <summary>
    /// Property of the original size of block.
    /// </summary>
    public Vector3 ScaledSize
    {
        get { return this.scaledSize; }
        set { this.scaledSize = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Vector3 offset;

    /// <summary>
    /// 
    /// </summary>
    public Vector3 Offset
    {
        get { return this.offset; }
        set { this.offset = value; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    private List<Tile> castedTiles = new List<Tile>();

    /// <summary>
    /// 
    /// </summary>
    public List<Tile> CastedTiles
    {
        get { return this.castedTiles; }
        set { this.castedTiles = value; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Finds the initial components to the field of them.
    /// </summary>
    private void FindComponentReferences()
    {
        this.rectTransform = this.gameObject.GetComponent<RectTransform>();
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        this.FindComponentReferences();
        this.blockPieces = BlockManager.Instance.GetBlockPieces(this);
        this.childPositions = BlockInformations.GetChildPositionData(this.blockType);
    }

    #endregion
}