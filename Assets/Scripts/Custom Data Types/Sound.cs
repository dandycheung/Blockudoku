using System;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[Serializable]
public class Sound
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private AudioSource audioSourceComponent;

    /// <summary>
    /// 
    /// </summary>
    public AudioSource AudioSourceComponent
    {
        get { return this.audioSourceComponent; }
        set { this.audioSourceComponent = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private string name;

    /// <summary>
    /// 
    /// </summary>
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private AudioClip clip;

    /// <summary>
    /// 
    /// </summary>
    public AudioClip Clip
    {
        get { return this.clip; }
        set { this.clip = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Range(0f, 1f), SerializeField]
    private float volume;

    /// <summary>
    /// 
    /// </summary>
    public float Volume
    {
        get { return this.volume; }
        set { this.volume = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Range(0f, 1f), SerializeField]
    private float pitch;

    /// <summary>
    /// 
    /// </summary>
    public float Pitch
    {
        get { return this.pitch; }
        set { this.pitch = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private bool loop;

    /// <summary>
    /// 
    /// </summary>
    public bool Loop
    {
        get { return this.loop; }
        set { this.loop = value; }
    }
}