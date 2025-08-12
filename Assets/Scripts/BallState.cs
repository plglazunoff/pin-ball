using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BallState : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        PauseManager.OnGamePaused += StopBallMovement;
        PauseManager.OnGameResumed += ResumeBallMovement;
    }

    private void StopBallMovement()
    {
        _rigidbody.isKinematic = true;
    }

    private void ResumeBallMovement()
    {
        _rigidbody.isKinematic = false;
    }

    private void OnDestroy()
    {
        PauseManager.OnGamePaused -= StopBallMovement;
        PauseManager.OnGameResumed -= ResumeBallMovement;
    }

    private void FixBallDirection()
    {
        float minYvelocity = 0.5f;
        Vector3 direction = _rigidbody.velocity;
        if(MathF.Abs(direction.y) < _rigidbody.velocity.y)
        {
            direction.y = direction.y > 0 ? minYvelocity : -minYvelocity;
            _rigidbody.velocity = direction.normalized * 5;
        }
    }
}
