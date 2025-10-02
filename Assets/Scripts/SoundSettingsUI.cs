using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettingsUI : MonoBehaviour
{
    public Slider Flipper;
    public Slider Bumper;
    public Slider Slingshot;
    public Slider Plunger;

    public TMP_Text FlipperTextPercent;
    public TMP_Text BumperTextPercent;
    public TMP_Text SlingshotTextPercent;
    public TMP_Text PlungerTextPercent;

    private float minSliderValue = 0.1f;
    private float maxSliderValue = 1;

    private void Start()
    {
        SetUpSlider(Flipper, SoundType.FlipperType, FlipperTextPercent);
        SetUpSlider(Bumper, SoundType.BumperType, BumperTextPercent);
        SetUpSlider(Slingshot, SoundType.SlingshotType, SlingshotTextPercent);
        SetUpSlider(Plunger, SoundType.PlungerType, PlungerTextPercent);
    }

   private void SetUpSlider(Slider slider, SoundType soundType, TMP_Text text)
    {
        slider.minValue = minSliderValue;
        slider.maxValue = maxSliderValue;
        float currentValue = SoundManager.Instance.GetVolume(soundType);
        slider.value = currentValue;
        text.text = $"{Mathf.RoundToInt(currentValue * 100)}%";
        slider.onValueChanged.AddListener((value) =>
        {
            SoundManager.Instance.SetVolume(soundType, value);
            text.text = $"{Mathf.RoundToInt(value * 100)}%";
        });
    }
}
