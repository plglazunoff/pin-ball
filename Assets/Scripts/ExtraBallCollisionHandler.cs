using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBallCollisionHandler : MonoBehaviour
{
    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<HitPoints>(out var hitPoints))
        {
            int points = hitPoints.PointsPerHit;
            Vector3 hitPosition = collision.contacts[0].point;
            _scoreManager.ShowScore(points, hitPosition);
        }
    }
}
