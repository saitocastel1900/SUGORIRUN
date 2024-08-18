using System;
using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// リザルトを管理する
/// </summary>
public class ResultWidgetController : MonoBehaviour
{
    /// <summary>
    /// クリックされたときに呼ばれる
    /// </summary>
    public IObservable<Unit> OnClickGameRestartButton => _restartButton.OnClickAsObservable;
    
    /// <summary>
    /// クリックされたときに呼ばれる
    /// </summary>
    public IObservable<Unit> OnClickReturnToTitleButton => _returnToTitleButton.OnClickAsObservable;
    
    /// <summary>
    /// Canvas
    /// </summary>
    [SerializeField] private Canvas _resultWidget;
   
    /// <summary>
    /// ResultScoreWidget
    /// </summary>
    [SerializeField] private ResultScoreWidget _resultScoreWidget;
    
    /// <summary>
    /// スコア
    /// </summary>
    [SerializeField] private ScorePresenter _score;
    
    /// <summary>
    /// GameRestartButtonWidget
    /// </summary>
    [SerializeField] private GameRestartButtonWidget _restartButton;
    
    /// <summary>
    /// ReturnToTitleButtonWidget
    /// </summary>
    [SerializeField] private ReturnToTitleButtonWidget _returnToTitleButton;

    /// <summary>
    /// AudioManager
    /// </summary>
    [Inject] private AudioManager _audioManager;
    
    private void Start()
    {
        //ボタンがクリックされたら、音を流す
        _restartButton
            .OnClickAsObservable
            .Subscribe(_=>_audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.WidgetClick1))
            .AddTo(this.gameObject);
        
        _returnToTitleButton
            .OnClickAsObservable
            .Subscribe(_=>_audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.WidgetClick2))
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// 表示
    /// </summary>
    public void Show()
    {
        _resultWidget.enabled = true;
        _resultScoreWidget.Set(_score.GetScore());
    }

    /// <summary>
    /// 非表示
    /// </summary>
    public void Hide()
    {
        _resultWidget.enabled = false;
    }
}
