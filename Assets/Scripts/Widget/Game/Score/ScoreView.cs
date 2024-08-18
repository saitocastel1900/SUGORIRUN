using DG.Tweening;
using TMPro;
using UnityEngine;

/// <summary>
/// スコアの見た目を管理する
/// </summary>
public class ScoreView : MonoBehaviour
{
    /// <summary>
    /// TextMeshProUGUI
    /// </summary>
    [SerializeField] private TextMeshProUGUI _scoreText;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        _scoreText.text = "";
    }

    /// <summary>
    /// スコアを設定する
    /// </summary>
    /// <param name="score">スコア</param>
    public void SetScore(int score)
    {
        _scoreText.text = "スコア：" + score.ToString();
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void Reset()
    {
        _scoreText.text = "";
    }

    /// <summary>
    /// 表示
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
        _scoreText.DOFade(1f, 0.3f);
    }

    /// <summary>
    /// 非表示
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}