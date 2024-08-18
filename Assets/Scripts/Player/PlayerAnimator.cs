using UnityEngine;
using UniRx;

/// <summary>
/// プレイヤーのアニメーションを管理する
/// </summary>
public class PlayerAnimator : MonoBehaviour
{
    /// <summary>
    /// プレイヤー
    /// </summary>
    [SerializeField] private PlayerCore _core;
    
    /// <summary>
    /// プレイヤーの動き
    /// </summary>
    [SerializeField] private PlayerMover _mover;
    
    /// <summary>
    /// Animator
    /// </summary>
    [SerializeField] private Animator _animator;
    
    private void Start()
    {
        //死んだら、死亡アニメーションを流す
        _core
            .IsAlive
            .Subscribe(x=>_animator.SetBool("IsAlive",x))
            .AddTo(this.gameObject);
       
        //動きに応じて、移動アニメーションを流す
        _mover
           .IsRightRunning
           .Subscribe(x=> _animator.SetBool("IsRightRunning", x));
      
        _mover
           .IsLeftRunning
           .Subscribe(x=> _animator.SetBool("IsLeftRunning", x));
    }
}
