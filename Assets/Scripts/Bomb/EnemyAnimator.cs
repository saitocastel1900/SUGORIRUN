using UniRx;
using UnityEngine;

/// <summary>
/// 敵のAnimatorを管理する
/// </summary>
public class EnemyAnimator : MonoBehaviour
{
    /// <summary>
    /// 敵
    /// </summary>
    [SerializeField] private EnemyCore _core;
    
    /// <summary>
    /// Animator
    /// </summary>
    [SerializeField] private Animator _animator;
        
    private　void Start()
    {
        //死んだら、爆破のアニメーションを流す
        _core
            .IsAlive
            .Select(x=>!x)
            .Subscribe(x=>_animator.SetBool("IsExplosion",x));
    }
}
