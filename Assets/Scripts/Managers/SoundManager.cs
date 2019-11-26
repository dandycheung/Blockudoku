using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class SoundManager : Singleton<SoundManager>
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private List<Sound> sounds;

    /// <summary>
    /// 
    /// </summary>
    public List<Sound> Sounds
    {
        get { return this.sounds; }
        set { this.sounds = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        SoundManager.Instance.InitializeSounds();
    }

    /// <summary>
    /// 
    /// </summary>
    private void InitializeSounds()
    {
        foreach (Sound sound in SoundManager.Instance.sounds)
        {
            sound.AudioSourceComponent = SoundManager.Instance.gameObject.AddComponent<AudioSource>();
            sound.AudioSourceComponent.clip = sound.Clip;
            sound.AudioSourceComponent.volume = sound.Volume;
            sound.AudioSourceComponent.pitch = sound.Pitch;
            sound.AudioSourceComponent.loop = sound.Loop;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Name"></param>
    public void PlayClip(string Name)
    {
        foreach (Sound sound in SoundManager.Instance.sounds)
        {
            if (sound.Name.Equals(Name))
            {
                sound.AudioSourceComponent.Play();
                return;
            }
        }
    }
    
}
