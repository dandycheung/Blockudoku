using System;

/// <summary>
/// 
/// </summary>
[Serializable]
public class Slot_Save
{
    /// <summary>
    /// 
    /// </summary>
    private int id;

    /// <summary>
    /// 
    /// </summary>
    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    private bool isEmpty;

    /// <summary>
    /// 
    /// </summary>
    public bool IsEmpty
    {
        get { return this.isEmpty; }
        set { this.isEmpty = value; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    private BlockType block;

    /// <summary>
    /// 
    /// </summary>
    public BlockType Block
    {
        get { return this.block; }
        set { this.block = value; }
    }
}
