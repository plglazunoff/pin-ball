using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _leftFlipper;
    [SerializeField] private Animator _rightFlipper;
    [SerializeField] private Animator _plunger;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _leftFlipper.SetTrigger("Hit");

        if (Input.GetKeyDown(KeyCode.Mouse1))
            _rightFlipper.SetTrigger("Hit");
        ActivatePlungerAnim();
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
            if(stateInfo.normalizedTime > 1)
            {
                _plunger.SetFloat("Direction", 0); 
            }
            else
            {
                _plunger.SetFloat("Direction", 1);
            }
        }
    }
}
