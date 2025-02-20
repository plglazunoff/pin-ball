using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    private GameManager _gameManager;
    private const string _slingshotLayer = "slingshot";

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    [SerializeField] private int _pointsPerHit;
    public int PointsPerHit => _pointsPerHit;

    private void OnCollisionEnter(Collision collision)
    {
        _gameManager.GameScore += _pointsPerHit;

        if (collision.gameObject.CompareTag("sling"))
        {
            Debug.Log("Slingshot collision");
            _gameManager.GameScore += 5000;
        }
    }
}
