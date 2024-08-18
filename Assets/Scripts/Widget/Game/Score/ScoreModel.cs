using UniRx;

/// <summary>
/// スコアのデータを管理する
/// </summary>
public class ScoreModel
{
    /// <summary>
    /// スコア
    /// </summary>
    public IReactiveProperty<int> ScoreProp => _scoreProperty;
    private IntReactiveProperty _scoreProperty;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ScoreModel()
    {
        _scoreProperty = new IntReactiveProperty(0);
    }

    /// <summary>
    /// スコアを加算
    /// </summary>
    public void SetScore(int score)
    {
        _scoreProperty.Value = score;
    }

    /// <summary>
    /// スコアを返す
    /// </summary>
    /// <returns>スコア</returns>
    public int GetScore()
    {
        return _scoreProperty.Value;
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void Reset()
    {
        _scoreProperty.Value = 0;
    }
}