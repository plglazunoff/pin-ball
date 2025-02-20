using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drain : MonoBehaviour
{ 
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    [SerializeField] private Transform _ballSpawnPosition;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("MainBall"))
        {
            if (GameManager.BallCount > 0)
            {
                GameManager.BallCount -= 1;
                Instantiate(collision.gameObject).transform.position = _ballSpawnPosition.position;
            }
            else
            {
                _gameManager.OnGameEnded?.Invoke();
            }
        }
        Destroy(collision.gameObject);
    }
}
