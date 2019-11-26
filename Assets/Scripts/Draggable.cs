using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent , RequireComponent(typeof(CanvasGroup),typeof(Block))]
public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    /// <summary>
    /// 
    /// </summary>
    public static Block block;
    
    /// <summary>
    /// 
    /// </summary>
    private static CanvasGroup canvasGroup;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.GameState.Equals(GameState.Gameplay)) return;
        if (GameplayManager.Instance.GameplayState.Equals(GameplayState.GameOver)) return;
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount != 1) return;
            if (Input.touches[0].phase.Equals(TouchPhase.Moved) || Input.touches[0].phase.Equals(TouchPhase.Stationary)){}
            else
            {
                return;
            }
        }

        GameplayManager.Instance.SetGameplayState(GameplayState.OnBlockDrag);
        block = this.gameObject.GetComponent<Block>();
        SlotManager.Instance.FindSlotOfBlock(Draggable.block).RectTransform.SetAsLastSibling();
        canvasGroup = block.gameObject.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
        if (SlotManager.Instance.FindSlotOfBlock(Draggable.block))
        {
            block.StartParent = SlotManager.Instance.FindSlotOfBlock(Draggable.block).transform;
        }

        BlockManager.Instance.ScaleBlockUp(block, ((1f / block.ScaleSpeed)));
        foreach (BlockPiece blockPiece in Draggable.block.BlockPieces)
        {
            if (blockPiece.gameObject.activeInHierarchy)
            {
                blockPiece.ImageComponent.color = blockPiece.OnDragColor;
                blockPiece.transform.localPosition += Draggable.block.Offset;
            }
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.GameState.Equals(GameState.Gameplay)) return;
        if (GameplayManager.Instance.GameplayState.Equals(GameplayState.GameOver)) return;
        #if UNITY_EDITOR
            block.transform.position = Input.mousePosition;
        #endif
     
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount == 1)
            {
                block.transform.position = Input.touches[0].position;
            }
        }

        if (BlockManager.Instance.AreBlockPiecesCastToTile(Draggable.block))
        {
            if (BlockManager.Instance.AreCastedTilesUnique(Draggable.block))
            {
                if (TileManager.Instance.AreCastedTilesEmpty(Draggable.block))
                { 
                    this.HighlightCastedTilesAsEmpty();
                    return;
                }
                this.HighlightCastedTilesAsFilled(); 
                return;
            }
        }
        this.UnhighlightCastedTiles();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.GameState.Equals(GameState.Gameplay)) return;
        if (GameplayManager.Instance.GameplayState.Equals(GameplayState.GameOver)) return;
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Input.touches[0].phase.Equals(TouchPhase.Ended) && 
                !Input.touchCount.Equals(1)) return;
        }

        if (block.transform.parent.Equals(block.StartParent))
        {
            this.StopAllCoroutines();
            this.StartCoroutine(block.transform.SetPositionWithLerp(
                this.transform.position,
                SlotManager.Instance.FindSlotOfBlock(block).transform.position,
                1 / block.PositioningSpeed));
            BlockManager.Instance.ScaleBlockDown(block, ((1f / block.ScaleSpeed)));
        }

        this.UnhighlightCastedTiles();
        foreach (BlockPiece blockPiece in Draggable.block.BlockPieces)
        {
            blockPiece.ImageComponent.color = blockPiece.InitialColor;
            blockPiece.transform.localPosition -= Draggable.block.Offset;
        }
        canvasGroup.blocksRaycasts = true;
    }


    /// <summary>
    /// 
    /// </summary>
    private void HighlightCastedTilesAsEmpty()
    {
        foreach (BlockPiece blockPiece in Draggable.block.BlockPieces)
        {
            if (blockPiece.CastedTile)
            {
                TileManager.Instance.HighlightTileAsEmpty(blockPiece.CastedTile);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void HighlightCastedTilesAsFilled()
    {
        foreach (BlockPiece blockPiece in Draggable.block.BlockPieces)
        {
            if (blockPiece.CastedTile)
            {
                TileManager.Instance.HighlightTileAsFilled(blockPiece.CastedTile);
            }
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void UnhighlightCastedTiles()
    {
        foreach (BlockPiece blockPiece in Draggable.block.BlockPieces)
        {
            if (blockPiece.CastedTile)
            {
                TileManager.Instance.UnHighlightTile(blockPiece.CastedTile);
            }
        }
    }
}
