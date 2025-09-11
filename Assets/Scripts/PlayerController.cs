using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _leftFlipper;
    [SerializeField] private Animator _rightFlipper;
    [SerializeField] private Animator _plunger;

    private bool _canMove = true;

    private void Awake()
    {
        PauseManager.OnGamePaused += PauseGame;
        PauseManager.OnGameResumed += ResumeGame;
    }

    private void Update()
    {
        if (_canMove)
        {
            ActivateFlipper();
            ActivatePlungerAnim();
        }
    }

    private void ActivateFlipper()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SoundManager.Instance.PlaySound(SoundType.FlipperType);
            _leftFlipper.SetTrigger("Hit");
        }
            
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SoundManager.Instance.PlaySound(SoundType.FlipperType);
        _rightFlipper.SetTrigger("Hit");
        }
    }

    private void ActivatePlungerAnim()
    {
        AnimatorStateInfo stateInfo = _plunger.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKey(KeyCode.Space))
        {
            if (stateInfo.normalizedTime < 0)
            {
                _plunger.SetFloat("Direction", 0);
            }
            else
            {
                _plunger.SetFloat("Direction", -1);
            }
        }
        else
        {
            if (stateInfo.normalizedTime > 1)
            {
                _plunger.SetFloat("Direction", 0);
            }
            else
            {
                _plunger.SetFloat("Direction", 1);
            }
        }
    }

    private void PauseGame()
    {
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
        _canMove = false;
    }

    private void ResumeGame()
    {
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
        _canMove = true;
    }

    private void OnDestroy()
    {
        PauseManager.OnGamePaused -= PauseGame;
        PauseManager.OnGameResumed -= ResumeGame;
    }
}
