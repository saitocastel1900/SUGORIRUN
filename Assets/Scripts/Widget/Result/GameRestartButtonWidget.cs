using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲームのリスタートボタンを管理する
/// </summary>
public class GameRestartButtonWidget : MonoBehaviour
{
    /// <summary>
    /// Button
    /// </summary>
    [SerializeField] private Button _gameRestartButton;
    
    /// <summary>
    /// クリックされたとき呼ばれる
    /// </summary>
    public IObservable<Unit> OnClickAsObservable => _gameRestartButton.OnClickAsObservable();
}
