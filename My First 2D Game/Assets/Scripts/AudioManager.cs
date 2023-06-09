using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �������֡���Ч
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// ����ָ����Ч
    /// </summary>
    /// <param name="clip"></param>
    public void AudioPlay(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
