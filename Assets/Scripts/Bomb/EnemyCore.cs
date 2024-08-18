using UniRx;
using UniRx.Triggers;
using UnityEngine;

/// <summary>
/// 敵のプロパティを管理
/// </summary>
public class EnemyCore : MonoBehaviour
{
    /// <summary>
    /// 初期化したか
    /// </summary>
    public IReactiveProperty<bool> IsInitialized => _isInitialized;
    private readonly BoolReactiveProperty _isInitialized = new BoolReactiveProperty(false);
    
    /// <summary>
    ///　生きているか
    /// </summary>
    public IReadOnlyReactiveProperty<bool> IsAlive => _isAlive;
    private ReactiveProperty<bool> _isAlive = new BoolReactiveProperty(false);

    /// <summary>
    /// 再生成する時に閾値のY座標
    /// </summary>
    public float LimitY => _limitY;
    private float _limitY;
    
    /// <summary>
    /// 再生成するときのX座標
    /// </summary>
    public float RecycleDistanceX => _recycleDistanceX;
    private float _recycleDistanceX;
    
    /// <summary>
    /// 再生成するときのY座標
    /// </summary>
    public float RecycleDistanceY => _recycleDistanceY;
    private float _recycleDistanceY;
    
    private void Awake()
    {
        //接触したオブジェクトがIDieableを持っていたらKillを呼び、自身を殺す
        _isInitialized
            .Where(x=>x==true)
            .Subscribe(_ =>
        {
            this.OnTriggerEnter2DAsObservable()
                .Subscribe(hit =>
                {
                    var dieable = hit.gameObject.GetComponent<IDieable>();
                    if (dieable != null)
                    {
                        dieable.Kill();
                        _isAlive.Value = false;
                    }
                }).AddTo(this);
        }).AddTo(this.gameObject);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void InitializeEnemy(float limitY,float recycleDistanceX,float recycleDistanceY)
    {
        _limitY=limitY;
        _recycleDistanceX = recycleDistanceX;
        _recycleDistanceY = recycleDistanceY;
        
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
