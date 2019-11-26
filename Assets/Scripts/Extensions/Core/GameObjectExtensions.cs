using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Extensions of the gameObjects.
/// </summary>w
public static class GameObjectExtensions
{
    /// <summary>
    /// Adds the specified component to the gameObject by checking whether the component exist
    /// on the gameObject or not.
    /// </summary>
    /// <param name="gameObject">GameObject that component will be added.</param>
    public static void AddComponentByChecking<T>(this GameObject gameObject) where T: Component
    {
        if (gameObject.GetComponent<T>())
        {
            return;
        }
        
        gameObject.AddComponent<T>();
    }

    /// <summary>
    /// Destroys the specified child of the gameobject.
    /// </summary>
    /// <param name="gameObject">GameObject that its child will be removed.</param>
    /// <param name="ChildIndex">Index of the child gameObject in the gameObject.</param>
    public static void DestroyChild(this GameObject gameObject, int ChildIndex)
    {
        Object.Destroy(gameObject.transform.GetChild(ChildIndex).gameObject);
    }
}
