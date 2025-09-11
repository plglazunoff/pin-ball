using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuAnimation : MonoBehaviour
{
    public Button HideLeaderboardButton;
    public Button ShowLeaderboardButton;
    public Button StartButton;
    public Button ExitButton;
    public TMP_Text TitleText;

    [SerializeField] private List<RectTransform> _buttons;
    [SerializeField] private CanvasGroup _leaderboardPanel;
    [SerializeField] private CanvasGroup _menuPanel;

    private bool _playAnim = true;

    private void Awake()
    {
        #region Buttons
        HideLeaderboardButton.onClick.AddListener(HideLeaderboardPanel);
        ShowLeaderboardButton.onClick.AddListener(ShowLeaderboardPanel);
        StartButton.onClick.AddListener(StartGame);
        ExitButton.onClick.AddListener(ExitGame);
        #endregion

        #region Methods
        MenuPanelHandler();
        TitleTextHandler();
        ScaleButtonsHandler();
        #endregion
    }

    private void StartGame()
    {
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
        StartButton.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 10, 1);
        _menuPanel.DOFade(0, 3).OnComplete(() => SceneManager.LoadScene("GameScene"));
    }

    public void ShowLeaderboardPanel()
    {
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
        _leaderboardPanel.gameObject.SetActive(true);
        _leaderboardPanel.alpha = 0;
        _leaderboardPanel.DOFade(1, 1);
        ShowLeaderboardButton.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 10, 1);
    }

    public void HideLeaderboardPanel()
    {
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
        _leaderboardPanel.DOFade(0, 1f).OnComplete(() => _leaderboardPanel.gameObject.SetActive(false));
        HideLeaderboardButton.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 10, 1);
    }

    private void MenuPanelHandler()
    {
        _menuPanel.alpha = 0;
        _menuPanel.DOFade(1, 1);
    }

    private void TitleTextHandler()
    {
        TitleText.DOFade(0.2f, 0.5f).SetLoops(-1, LoopType.Yoyo);

        // Vector2 startPosition = TitleText.rectTransform.anchoredPosition;
        //  TitleText.rectTransform.anchoredPosition = new Vector2(500, TitleText.rectTransform.anchoredPosition.y);
        //TitleText.rectTransform.DOAnchorPos(startPosition, 3).SetEase(Ease.OutElastic);
    }

    private void ScaleButtonsHandler()
    {
        foreach (var button in _buttons)
        {
            button.localScale = Vector3.zero;
            button.DOScale(1, 0.5f).SetDelay(1f).SetEase(Ease.OutBounce);
        }
    }

    private void ExitGame()
    {
        SoundManager.Instance.PlaySound(SoundType.ButtonType);
        ExitButton.transform.DOKill();
        ExitButton.transform.localScale = Vector3.one;
        ExitButton.transform.DOPunchScale(Vector3.one * 0.2f, 0.3f, 10, 1);
    }
}
