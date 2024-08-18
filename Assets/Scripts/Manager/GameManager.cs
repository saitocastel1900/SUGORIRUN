using System.Collections;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

/// <summary>
/// ゲームの進行を管理する
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 現在のゲームの状態
    /// </summary>
    public IReactiveProperty<GameEnum.State> CurrentStateProp => _currentState;
    private ReactiveProperty<GameEnum.State> _currentState = new ReactiveProperty<GameEnum.State>
        (GameEnum.State.None);
    
    /// <summary>
    /// プレイヤー
    /// </summary>
    [SerializeField] private PlayerCore _player;
    
    /// <summary>
    /// EnemyProvider
    /// </summary>
    [SerializeField] private EnemyProvider _enemyProvider;
    
    /// <summary>
    /// StageManager
    /// </summary>
    [SerializeField] private StageManager _stageManager;
    
    /// <summary>
    /// TimerManager
    /// </summary>
    [SerializeField] private TimerManager _timerManager;
    
    /// <summary>
    /// TitleWidgetController
    /// </summary>
    [SerializeField] private TitleWidgetController _titleWidget;
   
    /// <summary>
    /// HUDWidgetController
    /// </summary>
    [SerializeField] private HUDWidgetController _hudWidge;
    
    /// <summary>
    /// ResultWidgetController
    /// </summary>
    [SerializeField] private ResultWidgetController _resultWidget;

    /// <summary>
    /// AudioManager
    /// </summary>
    [Inject] private AudioManager _audioManager;
    
    private void Start()
    {
        _audioManager.PlayBGM(BgmData.BGM.Battle);
        
        //タイトル画面のスタートボタンが押されたら、ゲームの状態を初期化に変更する
        _titleWidget
            .OnClickGameStartButton
            .Subscribe(_ => _currentState.Value = GameEnum.State.Initializing)
            .AddTo(this.gameObject);
        
        _currentState
            .DistinctUntilChanged()
            .Subscribe(OnStateChanged)
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator InitializeCoroutine()
    {
        _player.InitializePlayer();

        //敵の生成
        for (int i = 0; i < _stageManager.GetEnemyCount(); i++)
        { 
            _enemyProvider.CreateEnemy(_stageManager.GetX(i), _stageManager.GetRandomY(), 
                _stageManager.GetLimitY(), _stageManager.GetRecycleDistanceY(),i);
        }

        _timerManager.StartTimer();

        yield return null;

        _currentState.Value = GameEnum.State.Play;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Play()
    {
        //プレイヤーが死んだら、ゲームの状態をリザルトに変更する
        _player
            .IsAlive
            .SkipLatestValueOnSubscribe()
            .Where(x => x == false)
            .Subscribe(_ => _currentState.Value = GameEnum.State.Result)
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Result()
    {
        _resultWidget.Show();
        _audioManager.PlaySoundEffect(SoundEffectData.SoundEffect.GameClear1);

        //リザルト画面のリスタートボタンが押されたら、ゲームの状態をリスタートに変更する
        _resultWidget
            .OnClickGameRestartButton
            .Subscribe(_ => _currentState.Value = GameEnum.State.Restart)
            .AddTo(this.gameObject);

        //リザルト画面のタイトルに戻るボタンが押されたら、ゲームの状態をリセットに変更する
        _resultWidget
            .OnClickReturnToTitleButton
            .Subscribe(_ => _currentState.Value = GameEnum.State.Reset)
            .AddTo(this.gameObject);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator RestartCoroutine()
    {
        _resultWidget.Hide();

        _player.Reset();
        _enemyProvider.Enemies.ToList().ForEach(x=>x.Value.Reset());
        _timerManager.Reset();
        _hudWidge.Reset();

        yield return null;

        _currentState.Value = GameEnum.State.Initializing;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator ResetCoroutine()
    {
        _resultWidget.Hide();
        
        _player.Reset();
        _enemyProvider.Enemies.ToList().ForEach(x=>x.Value.Reset());
        _timerManager.Reset();
        _hudWidge.Reset();
        
        _titleWidget.Show();
        
        yield return null;

        _currentState.Value = GameEnum.State.None;
    }
    
    /// <summary>
    /// 状態が変化した時に呼ばれる
    /// </summary>
    /// <param name="currentState">現在の状態</param>
    private void OnStateChanged(GameEnum.State currentState)
    {
        switch (currentState)
        {
            case GameEnum.State.Initializing:
                StartCoroutine(InitializeCoroutine());
                break;
            case GameEnum.State.Play:
                Play();
                break;
            case GameEnum.State.Result:
                Result();
                break;
            case GameEnum.State.Restart:
                StartCoroutine(RestartCoroutine());
                break;
            case GameEnum.State.Reset:
                StartCoroutine(ResetCoroutine());
                break;
            default:
                break;
        }
    }
}