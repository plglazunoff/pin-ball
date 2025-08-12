using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    BumperType,
    PlungerType,
    FlipperType,
    SlingshotType,
    ButtonType,
    BallType
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip BumperHitSound;
    public AudioClip PlungerHitSound;
    public AudioClip FlipperHitSound;
    public AudioClip SlingshotHitSound;
    public AudioClip ButtonClickSound;
    public AudioClip BallHitSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(SoundType soundType)
    {
       switch (soundType)
        {
            case SoundType.BumperType:
                _audioSource.PlayOneShot(BumperHitSound);
                break;

            case SoundType.FlipperType:
                _audioSource.PlayOneShot(FlipperHitSound);
                break;

            case SoundType.PlungerType:
                _audioSource.PlayOneShot(PlungerHitSound);
                break;

            case SoundType.SlingshotType:
                _audioSource.PlayOneShot(SlingshotHitSound);
                break;

            case SoundType.ButtonType:
                _audioSource.PlayOneShot(ButtonClickSound);
                break;
        }
    }
}
