using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SmoothRandomColor : MonoBehaviour
{
    private List<Light> _flashLights;
    private float _transitionDuration = 0.1f;
    private float _delayBetweenLights = 0.1f;
    private Coroutine _changeColor;

    private void Awake()
    {
        PauseManager.OnGamePaused += TurnOffLight;
        PauseManager.OnGameResumed += TurnOnLight;

    }

    private void Start()
    {
        List<Light> filteredLights = new List<Light>();
        List<Light> allLight = FindObjectsOfType<Light>().ToList();
        foreach (Light light in allLight)
        {
            if (light.gameObject.TryGetComponent<DecorLight>(out var decor))
            {
                filteredLights.Add(light);
            }
        }
        _flashLights = filteredLights;
        if (_flashLights.Count == 0)
        {
            return;
        }

        _changeColor = StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            foreach (Light flashLight in _flashLights)
            {

                Color startColor = flashLight.color;
                float newHue = Random.value;
                float newSaturation = 0.7f + Random.value * 0.3f;
                float newValue = 0.7f + Random.value * 0.3f;
                Color targetColor = Color.HSVToRGB(newHue, newSaturation, newValue);
                float elapsed = 0;
                while (elapsed < _transitionDuration)
                {
                    elapsed += Time.deltaTime;
                    flashLight.color = Color.Lerp(startColor, targetColor, elapsed / _transitionDuration);
                    yield return null;
                }
                flashLight.color = targetColor;
                yield return new WaitForSeconds(_delayBetweenLights);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void TurnOffLight()
    {
        StopCoroutine(_changeColor);
    }

    private void TurnOnLight()
    {
        StartCoroutine(ChangeColor());
    }

    private void OnDestroy()
    {
        PauseManager.OnGamePaused -= TurnOffLight;
        PauseManager.OnGameResumed -= TurnOnLight;
    }
}
