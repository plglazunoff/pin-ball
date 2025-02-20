using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAnimation : MonoBehaviour
{
    private Animator _animator;
    private TMP_Text _scoreText;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _scoreText = GetComponent<TMP_Text>();
    }

    public void StartScoreAnim(int points)
    {
        _scoreText.text = $"+{points}";
        _animator.SetTrigger("Play");
    }
}
