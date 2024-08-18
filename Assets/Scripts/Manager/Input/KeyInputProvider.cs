using System;
using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// キー入力を管理する
/// </summary>
public class KeyInputProvider : IInputEventProvider, IInitializable, IDisposable
{
    /// <summary>
    /// 右入力があったか
    /// </summary>
    public IReactiveProperty<bool> IsInputRight => _isInputRight;
    private BoolReactiveProperty _isInputRight = new BoolReactiveProperty(false);

    /// <summary>
    /// 左入力があったか
    /// </summary>
    public IReactiveProperty<bool> IsInputLeft => _isInputLeft;
    private BoolReactiveProperty _isInputLeft = new BoolReactiveProperty(false);

    /// <summary>
    /// CompositeDisposable
    /// </summary>
    private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

    public void Initialize()
    {
        //ボタンがキー入力に応じて、フラグを立てる
        Observable
            .EveryUpdate()
            .Where(_ => UnityEngine.Input.GetKey(KeyCode.A))
            .Select(_ => true)
            .Subscribe(_isInputLeft.SetValueAndForceNotify)
            .AddTo(_compositeDisposable);
        
        Observable
            .EveryUpdate()
            .Where(_ => UnityEngine.Input.GetKey(KeyCode.D))
            .Select(_ => true)
            .Subscribe(_isInputRight.SetValueAndForceNotify)
            .AddTo(_compositeDisposable);
        
        Observable
            .EveryUpdate()
            .Where(_ => !UnityEngine.Input.GetKey(KeyCode.A))
            .Select(_ => false)
            .Subscribe(isInputLeft => _isInputLeft.Value = isInputLeft)
            .AddTo(_compositeDisposable);
        
        Observable
            .EveryUpdate()
            .Where(_ => !UnityEngine.Input.GetKey(KeyCode.D))
            .Select(_ => false)
            .Subscribe(isInputRight => _isInputRight.Value = isInputRight)
            .AddTo(_compositeDisposable);
    }

    /// <summary>
    /// リソースを開放する
    /// </summary>
    public void Dispose()
    {
        _compositeDisposable.Dispose();
    }
}