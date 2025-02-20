using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBall : MonoBehaviour
{
    public List<Transform> ExtraBallPositions = new List<Transform>();
    public GameObject ExtraBallPrefab;

    private Transform _extraBallInstance;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainBall"))
        {

            Instantiate(ExtraBallPrefab).transform.position = ExtraBallPositions[Random.Range(0, ExtraBallPositions.Count)].position;
            
        }
    }
}
