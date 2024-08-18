using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// 敵の音を管理する
/// </summary>
public class EnemyAudio : MonoBehaviour
{
    /// <summary>
    /// 敵
    /// </summary>
    [SerializeField] private EnemyCore _core;
    
    /// <summary>
    /// AudioManager
    /// </summary>
    [Inject] private AudioManager _audioManager;
        
    private　void Start()
    {
        //死んだら、爆発音を流す
        _core
            .IsAlive
            .Where(x => x == false)
            .Subscribe(_=>_audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.Explosion))
            .AddTo(this.gameObject);
    }
}
