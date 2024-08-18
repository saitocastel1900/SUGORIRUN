using UniRx;
using UnityEngine;

/// <summary>
/// スコアのデータと見た目の橋渡しをする
/// </summary>
public class ScorePresenter : MonoBehaviour
{
    /// <summary>
    /// Model
    /// </summary>
    private ScoreModel _model;

    /// <summary>
    /// View
    /// </summary>
    [SerializeField] private ScoreView _view;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize()
    {
        _model = new ScoreModel();
        _view.Initialize();

        Bind();
    }

    /// <summary>
    /// Bind
    /// </summary>
    private void Bind()
    {
        // スコアが変更された表示も変更
        _model
            .ScoreProp
            .Subscribe(_view.SetScore)
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// スコアを加算
    /// </summary>
    public void SetScore(int score)
    {
        _model.SetScore(score);
    }

    /// <summary>
    /// 現在のスコアを返す
    /// </summary>
    /// <returns>スコア</returns>
    public int GetScore()
    {
        return _model.GetScore();
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void Reset()
    {
        _model.Reset();
    }
}