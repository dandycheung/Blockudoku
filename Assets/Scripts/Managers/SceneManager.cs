using UnityEngine;

/// <summary>
/// Manages the scene of the game.
/// </summary>
[DisallowMultipleComponent]
public class SceneManager : Singleton<SceneManager>
{
    /// <summary>
    /// Loads the specified scene.
    /// </summary>
    /// <param name="SceneName">Scene name as string.</param>
    public void LoadScene(string SceneName)
    {
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
}