using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the scene of the game.
/// </summary>
[DisallowMultipleComponent]
public class SceneManager : Singleton<SceneManager>
{
    [SerializeField]
    private List<GameObject> Singletons = new List<GameObject>();
    
    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="SceneName">Scene name as string.</param>
    public void LoadScene(string SceneName)
    {
        /*foreach (GameObject singleton in this.Singletons)
        {
            DontDestroyOnLoad(singleton);
        }*/
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }

    /// <summary>
    /// Loads the specified scene. (Overloads the LoadScene(str)).
    /// </summary>
    /// <param name="SceneBuildIndex">Scene index as int.</param>
    public void LoadScene(int SceneBuildIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneBuildIndex);
    }

    /// <summary>
    /// Checks whether specified scene is the current scene or not.
    /// </summary>
    /// <param name="SceneName">Scene that will be checked.</param>
    /// <returns>True or false.</returns>
    public bool IsCurrentScene(string SceneName)
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals(SceneName);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    public IEnumerator ChangeSceneWithWaiting(string sceneName , float duration )
    {
        yield return new WaitForSeconds(duration);
        SceneManager.Instance.LoadScene(sceneName);
    }
}