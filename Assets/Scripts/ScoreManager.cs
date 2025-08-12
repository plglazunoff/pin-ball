using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]private GameObject _scoreCanvasPrefab;

    public void ShowScore(int points, Vector3 position)
    {
        GameObject prefab = Instantiate(_scoreCanvasPrefab);
        ScoreAnimation scoreAnimation = prefab.GetComponentInChildren<ScoreAnimation>();
        if(scoreAnimation != null)
        {
            prefab.transform.position = position;
            scoreAnimation.StartScoreAnim(points);
        }
        Destroy(prefab, 1);

    }
}
