using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static event Action OnGamePaused;
    public static event Action OnGameResumed;

    public Button HideLeaderboardButton;
    public Button ShowLeaderboardButton;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private CanvasGroup _leaderboardPanel;

    private RectTransform _pausePanelTransform;

    private void Awake()
    {
        GameManager.OnGameEnded += GameEnded;
        _pausePanelTransform = _pausePanel.GetComponent<RectTransform>();

        _pauseButton.onClick.AddListener(PauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
        _menuButton.onClick.AddListener(OpenMenu);

        HideLeaderboardButton.onClick.AddListener(HideLeaderboardPanel);
        ShowLeaderboardButton.onClick.AddListener(ShowLeaderboardPanel);
    }

    public void ShowLeaderboardPanel()
    {
        //SoundManager.Instance.PlaySound(SoundType.ButtonType);
        _leaderboardPanel.gameObject.SetActive(true);
        _leaderboardPanel.alpha = 0;
        _leaderboardPanel.DOFade(1, 1);
        ShowLeaderboardButton.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 10, 1);
    }

    public void HideLeaderboardPanel()
    {
        //SoundManager.Instance.PlaySound(SoundType.ButtonType);
        _leaderboardPanel.DOFade(0, 1f).OnComplete(() => _leaderboardPanel.gameObject.SetActive(false));
        HideLeaderboardButton.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 10, 1);
    }

    private void PauseGame()
    {
        //SoundManager.Instance.PlaySound(SoundType.ButtonType);
        OnGamePaused?.Invoke();
        Vector3 movePosition = new Vector3(-Screen.width, _pausePanelTransform.anchoredPosition.y, 0);
        _pausePanelTransform.anchoredPosition = movePosition;
        _pausePanelTransform.DOAnchorPos(Vector3.zero, 1);
        _pausePanel.SetActive(true);
        _pauseButton.interactable = false;
    }

    private void ResumeGame()
    {
        //SoundManager.Instance.PlaySound(SoundType.ButtonType);
        OnGameResumed?.Invoke();
        Vector3 movePosition = new Vector3(-Screen.width, _pausePanelTransform.anchoredPosition.y, 0);
        _pausePanelTransform.DOAnchorPos(movePosition, 1).OnComplete(() => _pausePanel.SetActive(false));
        _pauseButton.interactable = true;
        
        //_pausePanelTransform.anchoredPosition = startPosition;
    }

    private void OpenMenu()
    {
        //SoundManager.Instance.PlaySound(SoundType.ButtonType);
        SceneManager.LoadScene("MainMenu");

    }

    private void GameEnded()
    {
        _pauseButton.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.OnGameEnded -= GameEnded;
    }
    
}
