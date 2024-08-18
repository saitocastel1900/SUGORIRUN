using UniRx;
using UnityEngine;

/// <summary>
/// HUDを管理する
/// </summary>
public class HUDWidgetController : MonoBehaviour
{
    /// <summary>
    /// スコア
    /// </summary>
    [SerializeField] private ScorePresenter _score;
    
    /// <summary>
    /// TimerManager
    /// </summary>
    [SerializeField] private TimerManager _timer;
    
    /// <summary>
    /// スコアの倍率
    /// </summary>
    [SerializeField] private int _scoreMultiplier;
    
    private void Start()
    {
        _score.Initialize();
        
        //時間経過に応じて、スコアを更新する
        _timer
            .CurrentTime
            .Select(time=>time*_scoreMultiplier)
            .Subscribe(_score.SetScore)
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void Reset()
    {
        _score.Reset();
    }
}
