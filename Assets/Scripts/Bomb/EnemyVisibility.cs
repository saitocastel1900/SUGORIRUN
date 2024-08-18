using UniRx;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 敵のアクティブを管理する
/// </summary>
public class EnemyVisibility : MonoBehaviour
{
    /// <summary>
    /// 敵
    /// </summary>
    [SerializeField] private EnemyCore _core;
    
    /// <summary>
    /// Image
    /// </summary>
    [SerializeField] private Image _image;

    private void Start()
    {
        //初期化したかに応じて、表示・非表示を切り替える
        _core
            .IsInitialized
            .Subscribe(x=>_image.enabled = x)
            .AddTo(this.gameObject);
    }
}
