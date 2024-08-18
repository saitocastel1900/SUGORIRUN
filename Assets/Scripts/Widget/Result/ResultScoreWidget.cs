using TMPro;
using UnityEngine;

/// <summary>
/// リザルトで表示するスコアを管理する
/// </summary>
public class ResultScoreWidget : MonoBehaviour
{
    /// <summary>
    /// TextMeshProUGUI
    /// </summary>
    [SerializeField] private TextMeshProUGUI _scoreText;

    /// <summary>
    /// スコアを設定する
    /// </summary>
    /// <param name="score">スコア</param>
    public void Set(int score)
    {
        _scoreText.text = score.ToString();
    }
}
