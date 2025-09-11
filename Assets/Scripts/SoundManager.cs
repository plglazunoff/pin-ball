using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [Space(30)]
    [Header("Sliders")]
    public Slider BumperSlider;
    public Slider PlungerSlider;
    public Slider FlipperSlider;
    public Slider SlingshotSlider;

    [Space(30)]
    [Header("PercentTexts")]
    public TMP_Text BumperPercentText;
    public TMP_Text PlungerPercentText;
    public TMP_Text FlipperPercentText;
    public TMP_Text SlingshotPercentText;


    private static float _bumperPercentVolume = 1;
    private float _plungerPercentVolume;
    private float _flipperPercentVolume;
    private float _slingshotPercentVolume;

    private float _minValue = 0.1f;
    private float _maxValue = 1f;

    private AudioSource _audioSource;
    private float _soundVolume;

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
        BumperSlider.onValueChanged.AddListener(SetUpSlider);
        DontDestroyOnLoad(BumperSlider);
        DontDestroyOnLoad(BumperPercentText);
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

    private void SetUpSoundVolume(Slider slider, float value, TMP_Text percentText)
    {
        _audioSource.volume = value;

        slider.value = value;
        slider.minValue = _minValue;
        slider.maxValue = _maxValue;
        percentText.text = $"{Mathf.RoundToInt(value * 100)}%";
    }

    private void SetUpSlider(float value)
    {
        _bumperPercentVolume = value;
        SetUpSoundVolume(BumperSlider, _bumperPercentVolume , BumperPercentText);
    }
}
