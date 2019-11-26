using UnityEngine;

/// <summary>
/// Manages inputs of the game.
/// </summary>
[DisallowMultipleComponent]
public class InputManager : Singleton<InputManager>
{
    /// <summary>
    /// 
    /// </summary>
    [Space(5f) , Header("Input Settings") , SerializeField]
    private bool multiTouchSupport = false;
    
    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        InputManager.Instance.SetMultiTouchSupport();
    }

    /// <summary>
    /// 
    /// </summary>
    private void SetMultiTouchSupport()
    {
        Input.multiTouchEnabled = InputManager.Instance.multiTouchSupport;
    }
}