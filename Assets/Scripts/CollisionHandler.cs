using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public ScoreManager ScoreManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<HitPoints>(out var hitPoints))
        {
            int points = hitPoints.PointsPerHit;
            Vector3 hitPosition = collision.contacts[0].point;
            ScoreManager.ShowScore(points, hitPosition);
        }
    }
}
