using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Bumper : MonoBehaviour
{
    private Light _pointLight;
    private Vector3 _startScale;
    private Vector3 _targetScale;
    private float _scaleMultiplier = 1.2f;

    private void Awake()
    {
        _pointLight = GetComponentInChildren<Light>();
        _startScale = transform.localScale;
        _targetScale = _startScale * _scaleMultiplier;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //SoundManager.Instance.PlaySound(SoundType.BumperType);
        _pointLight.color = new Color(Random.value, Random.value, Random.value);

        transform.localScale = _targetScale;
    }
    private void OnCollisionExit(Collision collision)
    {
        transform.localScale = _startScale;
    }
    


}
