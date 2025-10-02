using UnityEngine;

public enum SoundType
{
    BumperType,
    PlungerType,
    FlipperType,
    SlingshotType,
    ButtonType
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

    private static float _bumperPercentVolume = 1;
    private static float _plungerPercentVolume = 1;
    private static float _flipperPercentVolume = 1;
    private static float _slingshotPercentVolume = 1;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if (Instance == null)
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
                _audioSource.PlayOneShot(BumperHitSound, _bumperPercentVolume);
                break;

            case SoundType.FlipperType:
                _audioSource.PlayOneShot(FlipperHitSound, _flipperPercentVolume);
                break;

            case SoundType.PlungerType:
                _audioSource.PlayOneShot(PlungerHitSound, _plungerPercentVolume);
                break;

            case SoundType.SlingshotType:
                _audioSource.PlayOneShot(SlingshotHitSound, _slingshotPercentVolume);
                break;

            case SoundType.ButtonType:
                _audioSource.PlayOneShot(ButtonClickSound, 1);
                break;
        }
    }

    public float GetVolume(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.BumperType: return _bumperPercentVolume;
            case SoundType.FlipperType: return _flipperPercentVolume;
            case SoundType.PlungerType: return _plungerPercentVolume;
            case SoundType.SlingshotType: return _slingshotPercentVolume;
            default: return 1;
        }
    }

    public void SetVolume(SoundType _soundType, float _value)
    {
        switch (_soundType)
        {
            case SoundType.BumperType: _bumperPercentVolume = _value; break;
            case SoundType.FlipperType: _flipperPercentVolume = _value; break;
            case SoundType.PlungerType: _plungerPercentVolume = _value; break;
            case SoundType.SlingshotType: _slingshotPercentVolume = _value; break;
        }
    }
}
