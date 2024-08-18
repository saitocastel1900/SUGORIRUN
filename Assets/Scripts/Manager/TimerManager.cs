using System;
using UniRx;
using UnityEngine;

/// <summary>
/// 時間を管理する
/// </summary>
public class TimerManager : MonoBehaviour
{
    /// <summary>
    /// 経過時間
    /// </summary>
    public IReactiveProperty<int> CurrentTime => _currentTime;
    private IntReactiveProperty _currentTime = new IntReactiveProperty(0);

    /// <summary>
    /// IDisposable
    /// </summary>
    private IDisposable _disposable;
    
    /// <summary>
    /// 時間を数え始める
    /// </summary>
    public void StartTimer()
    {
        _disposable = Observable
            .Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
            .Select(x => (int)x)
            .Do(x => Debug.Log("Time" + x))
            .Subscribe(x => _currentTime.Value = x);
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void Reset()
    {
        _disposable.Dispose();
        _currentTime.Value = 0;
    }
}