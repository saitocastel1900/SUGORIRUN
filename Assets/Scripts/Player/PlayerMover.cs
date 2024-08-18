using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// プレイヤーの移動を管理
/// </summary>
public class PlayerMover : MonoBehaviour
{
    /// <summary>
    /// プレイヤー
    /// </summary>
    [SerializeField] private PlayerCore _core;
    
    /// <summary>
    /// RectTransform
    /// </summary>
    [SerializeField] private RectTransform _transform;
    
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField] private float _speed;
    
    /// <summary>
    /// 入力
    /// </summary>
    [Inject] private IInputEventProvider _input;
    
    /// <summary>
    /// 右に走っているのか
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsRightRunning => _isRightRunning;
    private BoolReactiveProperty _isRightRunning = new BoolReactiveProperty();
    
    /// <summary>
    /// 左に走っているのか
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsLeftRunning => _isLeftRunning;
    private BoolReactiveProperty _isLeftRunning = new BoolReactiveProperty();
    
    private void Start()
    {
        //入力に応じて、移動する
        _input
            .IsInputRight
            .SkipLatestValueOnSubscribe()
            .Where(_=>_core.IsAlive.Value==true)
            .Select(_=>Vector3.right)
            .Subscribe(Move);
        
        _input
            .IsInputLeft
            .SkipLatestValueOnSubscribe()
            .Where(_=>_core.IsAlive.Value==true)
            .Select(_=>Vector3.left)
            .Subscribe(Move);

        //入力におうじて、移動したかのフラグを立てる
        _input.IsInputRight
            .Where(_=>_core.IsAlive.Value==true)
            .Subscribe(_isRightRunning.SetValueAndForceNotify);
        
        _input.IsInputLeft
            .Where(_=>_core.IsAlive.Value==true)
            .Subscribe(_isLeftRunning.SetValueAndForceNotify);
    }

    /// <summary>
    /// 移動する
    /// </summary>
    /// <param name="direction">進行方向</param>
    private void Move(Vector3 direction)
    {
        _transform.position += _speed*direction*Time.deltaTime;
    }
}
