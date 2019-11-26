using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        this.animator = this.gameObject.GetComponent<Animator>();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Close()
    {
        StartCoroutine(CloseCoroutine());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator CloseCoroutine()
    {
        this.animator.SetTrigger("Close");
        yield return new WaitForSeconds(.25f);
        this.gameObject.SetActive(false);
    }
}
