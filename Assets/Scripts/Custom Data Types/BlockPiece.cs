using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
[DisallowMultipleComponent,RequireComponent(typeof(Image))]
public class BlockPiece:MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private static GraphicRaycaster graphicRaycaster;
    
    /// <summary>
    /// 
    /// </summary>
    private readonly PointerEventData pointerEventData = new PointerEventData(EventSystem.current);

    /// <summary>
    /// 
    /// </summary>
    private List<RaycastResult> raycastResult = new List<RaycastResult>();
    
    /// <summary>
    /// 
    /// </summary>
    [Space(5f) , Header("References") , SerializeField]
    private Tile castedTile;

    /// <summary>
    /// 
    /// </summary>
    public Tile CastedTile
    {
        get { return this.castedTile; }
        set { this.castedTile = value; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Image imageComponent;

    /// <summary>
    /// 
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
    private Color initialColor = Color.white;

    /// <summary>
    /// 
    /// </summary>
    public Color InitialColor
    {
        get { return this.initialColor; }
        set { this.initialColor = value; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Color onDragColor = Color.gray;

    /// <summary>
    /// 
    /// </summary>
    public Color OnDragColor
    {
        get { return this.onDragColor; }
        set { this.onDragColor = value; }
    }
    
    
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        BlockPiece.graphicRaycaster = FindObjectOfType<GraphicRaycaster>();
        this.imageComponent = this.GetComponent<Image>();
    }

    /// <summary>
    /// 
    /// </summary>
    private void CastRay()
    {
        this.pointerEventData.position = this.transform.position;
        graphicRaycaster.Raycast(this.pointerEventData,this.raycastResult);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private bool IsRaycastResultContainsTile()
    {
        bool contains = false;
        foreach (RaycastResult result in this.raycastResult)
        {
            if (result.gameObject.GetComponent<Tile>())
            {
                contains = true;
                break;
            }
        }

        return contains;
    }
    /// <summary>
    /// 
    /// </summary>
    private void OnCast()
    {
        if (this.raycastResult.Count > 0)
        {
            if (this.IsRaycastResultContainsTile())
            {
                foreach (RaycastResult result in this.raycastResult)
                {
                    if (!result.gameObject.GetComponent<Tile>()) continue;
                    if (this.castedTile)
                    {
                        if (!this.castedTile.Equals(result.gameObject.GetComponent<Tile>()))
                        {
                            TileManager.Instance.UnHighlightTile(this.castedTile);
                            this.castedTile = result.gameObject.GetComponent<Tile>();
                            return;
                        }
                    }
                    else
                    {
                        this.castedTile = result.gameObject.GetComponent<Tile>();
                        return;
                    }
                }
            }
            else if (this.castedTile)
            {
                TileManager.Instance.UnHighlightTile(this.castedTile);
                this.castedTile = null;    
            }
        }
        else
        {
            if (!this.castedTile) return;
            TileManager.Instance.UnHighlightTile(this.castedTile);
            this.castedTile = null;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsCastsToTile()
    {
        this.CastRay();
        this.OnCast();
        this.ClearRaycastResult();
        return this.castedTile;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsCastedTileEmpty()
    {
        return this.castedTile.IsEmpty;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void AlignToTile()
    {
        this.StartCoroutine(this.transform.SetPositionWithLerp(
                this.transform.position,
                this.castedTile.transform.position, 
                1f/BlockManager.Instance.AlignSpeed));
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetParentAsCastedTile()
    {
        this.transform.SetParent(this.castedTile.transform);
    }

    /// <summary>
    /// 
    /// </summary>
    private void ClearRaycastResult()
    {
        this.raycastResult.Clear();
    }
}
