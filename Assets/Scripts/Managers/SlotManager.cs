using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Manages the slots of the game.
/// </summary>
[DisallowMultipleComponent]
public class SlotManager : Singleton<SlotManager>
{
    #region Fields

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Slot slotReference;

    /// <summary>
    /// 
    /// </summary>
    public Slot SlotReference
    {
        get { return this.slotReference; }
        set { this.slotReference = value; }
    }

    /// <summary>
    /// Field of the slots of game.
    /// </summary>
    [SerializeField]
    private List<Slot> slots = new List<Slot>();

    /// <summary>
    /// Property of the slots of game.
    /// </summary>
    public List<Slot> Slots
    {
        get { return SlotManager.Instance.slots; }
        set { SlotManager.Instance.slots = value; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="slot"></param>
    private void ClearSlot(Slot slot)
    {
        if (slot.transform.childCount > 0)
        {
            Destroy(slot.transform.GetChild(0).gameObject);
        }
        slot.IsEmpty = true;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void ClearSlots()
    {
        foreach (Slot slot in SlotManager.Instance.slots)
        {
            SlotManager.Instance.ClearSlot(slot);
            slot.gameObject.SetActive(false);
        }
        BlockManager.Instance.QueuedBlocks.Clear();
    }
    
    /// <summary>
    /// 
    /// </summary>
    private Block SpawnRandomBlockAtSlot(int SlotNumber)
    {
        Block block = BlockManager.Instance.GetRandomBlock();
        block.transform.SetParent(SlotManager.Instance.slots[SlotNumber].transform);
        SlotManager.Instance.slots[SlotNumber].gameObject.SetActive(true);
        BlockManager.Instance.SetInitialTransformValues(block);
        SlotManager.Instance.slots[SlotNumber].IsEmpty = false;
        BlockManager.Instance.QueuedBlocks.Add(block);
        return block;
    }

    /// <summary>
    /// Rotate Block
    /// </summary>
    private Block RotateBlockAtSlot(int SlotNumber)
    {
        Block block = BlockManager.Instance.GetCurClickRotatedBlock();
        block.transform.SetParent(SlotManager.Instance.slots[SlotNumber].transform);
        SlotManager.Instance.slots[SlotNumber].gameObject.SetActive(true);
        BlockManager.Instance.SetInitialTransformValues(block);
        SlotManager.Instance.slots[SlotNumber].IsEmpty = false;
        BlockManager.Instance.QueuedBlocks.Add(block);
        return block;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="SlotNumber"></param>
    /// <param name="blockType"></param>
    public void SpawnBlockAtSlot(int SlotNumber, BlockType blockType)
    {
        foreach (Block block in BlockManager.Instance.CurAvailableBlocks)
        {
            if (block.BlockType.Equals(blockType))
            {
                Block spawnBlock = Instantiate(block, SlotManager.Instance.slots[SlotNumber].transform);
                SlotManager.Instance.slots[SlotNumber].gameObject.SetActive(true);
                BlockManager.Instance.SetInitialTransformValues(spawnBlock);
                SlotManager.Instance.slots[SlotNumber].IsEmpty = false;
                BlockManager.Instance.QueuedBlocks.Add(spawnBlock);
                return;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="slot"></param>
    /// <returns></returns>
    private int GetSlotIndex(Slot slot)
    {
        return SlotManager.Instance.slots.IndexOf(slot);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool AreSlotsEmpty()
    {
        bool IsEmpty = false;
        foreach (Slot slot in SlotManager.Instance.slots)
        {
            if (slot.IsEmpty)
            {
                IsEmpty = true;
                break;
            }
        }
        return IsEmpty;
    }

    /// <summary>
    /// 随机生成3个Block放入可选区
    /// </summary>
    public void SpawnNewBlockSet()
    {
        foreach (Slot slot in SlotManager.Instance.slots)
        {
            if (slot.IsEmpty)
            {
                SlotManager.Instance.SpawnRandomBlockAtSlot(SlotManager.Instance.GetSlotIndex(slot));
            }
        }
        SoundManager.Instance.PlayClip("Spawn");
    }

    /// <summary>
    /// 在空槽放入刚才删除之前旋转后的方块
    /// </summary>
    public void RotateBlock()
    {
        foreach (Slot slot in SlotManager.Instance.slots)
        {
            if (slot.IsEmpty)
            {
                SlotManager.Instance.RotateBlockAtSlot(SlotManager.Instance.GetSlotIndex(slot));
                break;
            }
        }
        SoundManager.Instance.PlayClip("Spawn");
    }

    /// <summary>
    /// 随机更换一个Block
    /// </summary>
    public void RancomChangeBlock(Block oldBlock)
    {
        Slot slot = FindSlotOfBlock(oldBlock);
        int SlotNumber = SlotManager.Instance.GetSlotIndex(slot);

        SpawnRandomBlockAtSlot(SlotNumber);
        //Block newBlock = BlockManager.Instance.GetRandomBlock();
        //SlotManager.Instance.slots[SlotNumber] = newBlock;
        // BlockManager.Instance.DropBlock2(oldBlock);


        //Block newBlock = BlockManager.Instance.GetRandomBlock();
        //newBlock.transform.SetParent(SlotManager.Instance.slots[SlotNumber].transform);
        //SlotManager.Instance.slots[SlotNumber].gameObject.SetActive(true);
        //BlockManager.Instance.SetInitialTransformValues(newBlock);
        //SlotManager.Instance.slots[SlotNumber].IsEmpty = false;
        //BlockManager.Instance.QueuedBlocks.Add(newBlock);

        SoundManager.Instance.PlayClip("Spawn");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="block"></param>
    /// <returns></returns>
    public Slot FindSlotOfBlock(Block block)
    {
        foreach (Slot slot in SlotManager.Instance.slots)
        {
            if (slot.gameObject.transform.childCount == 0)
            {
                continue;
            }

            if (block.transform.Equals(slot.gameObject.transform.GetChild(0)))
            {
                return slot;
            }
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Slot FindSlotWithId(int Id)
    {
        foreach (Slot slot in SlotManager.Instance.Slots)
        {
            if (slot.Id.Equals(Id))
            {
                return slot;
            }
        }

        return null;
    }
    
    #endregion
}