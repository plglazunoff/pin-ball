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
                StartCoroutine(_gameManager.FindExtraBalls());
                GameManager.OnGameEnded?.Invoke();
            }
        }
        Destroy(collision.gameObject);
    }
}
