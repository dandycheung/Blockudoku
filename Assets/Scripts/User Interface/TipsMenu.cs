using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class TipsMenu : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [Space(5f), Header("Tips Panel References"), SerializeField]
    private GameObject tipsPanel;

    /// <summary>
    /// 
    /// </summary>
    public void Open()
    {
        tipsPanel.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Close()
    {
        tipsPanel.SetActive(false);
    }
}