using UniRx;
using UnityEngine;

/// <summary>
/// 敵の移動を管理する
/// </summary>
public class EnemyMover : MonoBehaviour
{
    /// <summary>
    /// 敵
    /// </summary>
    [SerializeField] private EnemyCore _core;
    
    /// <summary>
    /// RectTransform
    /// </summary>
    [SerializeField] private RectTransform _transform;
    
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField] private float _speed;
    
    private void Start()
    {
        //常に移動し続ける
        Observable
            .EveryFixedUpdate()
            .Subscribe(_=>Move())
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// 移動する
    /// </summary>
    private void Move()
    {
        //画面外にでたら再配置する
        if (_transform.anchoredPosition.y <= _core.LimitY)
        {
            _transform.anchoredPosition = new Vector2(_core.RecycleDistanceX,_core.RecycleDistanceY);
        }
        
        _transform.position += new Vector3(0,-_speed*Time.deltaTime,0);
    }
}
