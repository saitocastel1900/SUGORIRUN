using UniRx;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーのアクティブを管理する
/// </summary>
public class PlayerVisibility : MonoBehaviour
{
    /// <summary>
    /// プレイヤー
    /// </summary>
    [SerializeField] private PlayerCore _core;
    
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
