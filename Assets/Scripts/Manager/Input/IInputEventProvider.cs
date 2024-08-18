using UniRx;

/// <summary>
/// 入力を管理する
/// </summary>
public interface IInputEventProvider
{
    /// <summary>
    /// 左入力があったか
    /// </summary>
    public IReactiveProperty<bool> IsInputLeft { get; }
    
    /// <summary>
    /// 右入力があったか
    /// </summary>
    public IReactiveProperty<bool> IsInputRight { get; }
}