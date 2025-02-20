using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFlashOnCollision : MonoBehaviour
{
    public float FlashDuration;
    public float FlashIntensity;

    private Color _flashColor;

    private void Start()
    {
        _flashColor = new Color(Random.value, Random.value, Random.value);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject flashLightObject = new GameObject("Otday Bomzhy BablGam(zhvachky(жвачку, pointLight))");
        Light flashLight = flashLightObject.AddComponent<Light>();
        flashLight.range = 1;
        flashLight.intensity = 5;
        flashLight.color = _flashColor;
        flashLight.type = LightType.Point;
        flashLight.renderMode = LightRenderMode.ForcePixel;
        flashLightObject.transform.position = collision.contacts[0].point;
        Destroy(flashLightObject, FlashDuration);
    }
}
