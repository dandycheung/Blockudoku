using UnityEngine;
using System.Collections;

public static class TransformExtensions
{
    /// <summary>
    /// Sets transform's local position with lerp.
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="initial"></param>
    /// <param name="final"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    public static IEnumerator SetPositionWithLerp(this Transform transform, Vector3 initial, Vector3 final, float duration)
    {
        float percentage = 0;
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            percentage = timeElapsed / duration;
            transform.position = Vector3.Lerp(initial, final, percentage);
            yield return null;
        }
    }

    /// <summary>
    /// Sets transform's local scale with lerp.
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="initialScale"></param>
    /// <param name="finalScale"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    public static IEnumerator ScaleWithLerp(this Transform transform ,Vector3 initialScale, Vector3 finalScale, float duration)
    {
        float timeElapsed = 0;
        float percentage = 0;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            percentage = timeElapsed / duration;
            transform.localScale = Vector3.Lerp(initialScale, finalScale, percentage);
            yield return null;
        }
    }
}
