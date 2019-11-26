using UnityEngine;

/// <summary>
/// Custom data type for the Slots of game.
/// </summary>
[DisallowMultipleComponent]
public class Slot : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [Space(5f), Header("References"), SerializeField]
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
    [SerializeField]
    private RectTransform rectTransform;

    /// <summary>
    /// 
    /// </summary>
    public RectTransform RectTransform
    {
        get { return this.rectTransform; }
        set { this.rectTransform = value; }
    }
    
    /// <summary>
    /// Field of the status of slot.
    /// </summary>
    [Space(5f) , Header("Properties") , SerializeField]
    private bool isEmpty = true;

    /// <summary>
    /// Property of the status of slot.
    /// </summary>
    public bool IsEmpty
    {
        get { return this.isEmpty; }
        set { this.isEmpty = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    private void FindComponentReferences()
    {
        this.rectTransform = this.gameObject.GetComponent<RectTransform>();
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        this.FindComponentReferences();
    }
}