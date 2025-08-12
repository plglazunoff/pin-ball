using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class ExtraBall : MonoBehaviour
{
    public GameObject ExtraBallInstance
    {
        get
        {
            return _extraBallInstance;
        }
        set
        {
            _extraBallInstance = value;
        }
    }
    public List<Transform> ExtraBallPositions = new List<Transform>();
    public GameObject ExtraBallPrefab;

    private GameObject _extraBallInstance = null;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainBall"))
        {
            if (_extraBallInstance == null)
            {
                _extraBallInstance = Instantiate(ExtraBallPrefab);
                _extraBallInstance.transform.position = ExtraBallPositions[Random.Range(0, ExtraBallPositions.Count)].position;
            }

        }
    }
}
