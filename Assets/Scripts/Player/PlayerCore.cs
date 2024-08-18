using UniRx;
using UnityEngine;

/// <summary>
/// プレイヤーのプロパティを管理
/// </summary>
public class PlayerCore : MonoBehaviour, IDieable
{
    /// <summary>
    /// 初期化したか
    /// </summary>
    public IReactiveProperty<bool> IsInitialized => _isInitialized;
    private readonly BoolReactiveProperty _isInitialized = new BoolReactiveProperty(false);

    /// <summary>
    /// 生きているか
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsAlive => _isAlive;
    private ReactiveProperty<bool> _isAlive = new BoolReactiveProperty(false);

    /// <summary>
    /// 倒す
    /// </summary>
    public void Kill()
    {
        _isAlive.Value = false;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void InitializePlayer()
    {
        _isInitialized.Value = true;
        _isAlive.Value = true;
    }

    /// <summary>
    /// リセット
    /// </summary>
    public void Reset()
    {
        _isInitialized.Value = false;
    }
}