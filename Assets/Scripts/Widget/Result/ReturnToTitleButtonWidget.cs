using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトルに戻すボタンを管理する
/// </summary>
public class ReturnToTitleButtonWidget : MonoBehaviour
{
    /// <summary>
    /// ゲームの開始ボタンを管理する
    /// </summary>
    [SerializeField] private Button _returnToTitleButton;
    
    /// <summary>
    /// クリックされた時に呼ばれる
    /// </summary>
    public IObservable<Unit> OnClickAsObservable => _returnToTitleButton.OnClickAsObservable();
}
