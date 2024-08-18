using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// プレイヤーの音を管理
/// </summary>
public class PlayerAudio : MonoBehaviour
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
    /// AudioManager
    /// </summary>
    [Inject] private AudioManager _audioManager;
        
    private void Start()
    {
        //動きに応じて、歩く音を再生する
        _mover
            .IsRightRunning
            .Subscribe(_=>_audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.Walk))
            .AddTo(this.gameObject);
        
        _mover
            .IsLeftRunning
            .Subscribe(_=>_audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.Walk))
            .AddTo(this.gameObject);
    }
}
